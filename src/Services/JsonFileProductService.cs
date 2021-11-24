using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// Methods for all Product related services 
    /// </summary>
    public class JsonFileProductService
    {
        /// <summary>
        /// WebHostEnvironment knows where the  data file is stored at
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            //create webHostEnvironment
            WebHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// WebHostEnvironment knows where the  data file is stored at
        /// </summary>
        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// specify file path to retrieve from
        /// </summary>
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        /// <summary>
        /// Get all data for products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductModel> GetAllData()
        {
            //jsonfile reader
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                //return data
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Add Rating
        /// 
        /// Take in the product ID and the rating
        /// If the rating does not exist, add it
        /// Save the update
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="rating"></param>
        public bool AddRating(string productId, int rating)
        {
            // If the ProductID is invalid, return
            if (string.IsNullOrEmpty(productId))
            {
                return false;
            }

            //all product data
            var products = GetAllData();

            // Look up the product, if it does not exist, return
            var data = products.FirstOrDefault(x => x.Id.Equals(productId));
            //if no data
            if (data == null)
            {
                return false;
            }

            // Check Rating for boundries, do not allow ratings below 0
            if (rating < 0)
            {
                return false;
            }

            // Check Rating for boundries, do not allow ratings above 5
            if (rating > 5)
            {
                return false;
            }

            // Check to see if the rating exist, if there are none, then create the array
            if (data.Ratings == null)
            {
                data.Ratings = new int[] { };
            }

            // Add the Rating to the Array
            var ratings = data.Ratings.ToList();

            // add rating to list
            ratings.Add(rating);
            
            //convert list to array
            data.Ratings = ratings.ToArray();

            // Save the data back to the data store
            SaveData(products);

            return true;
        }

        /// <summary>
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        public ProductModel UpdateData(ProductModel data)
        {
            //product data
            var products = GetAllData();

            //find specific product
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));

            //if specific product does not exist
            if (productData == null)
            {
                return null;
            }

            // Update the data to the new passed in values
            //title
            productData.Title = data.Title;

            //description
            productData.Description = data.Description.Trim();

            //url
            productData.Url = data.Url;

            //image
            productData.Image = data.Image;

            //quantity
            productData.Quantity = data.Quantity;

            //price
            productData.Price = data.Price;

            //update database
            SaveData(products);

            //return updated database
            return productData;
        }

        /// <summary>
        /// Save All products data to storage
        /// </summary>
        private void SaveData(IEnumerable<ProductModel> products)
        {
            //output stream
            using (var outputStream = File.Create(JsonFileName))
            {
                //serialize product model 
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        //skip validation
                        SkipValidation = true,

                        //indent
                        Indented = true
                    }),
                    //products
                    products
                );
            }
        }

        /// <summary>
        /// Create a new product using default values
        /// After create the user can update to set values
        /// </summary>
        /// <returns></returns>
        public ProductModel CreateData()
        {
            //create new product 
            var data = new ProductModel()
            {
                //id of product
                Id = System.Guid.NewGuid().ToString(),

                //title 
                Title = "Enter Title",

                //product description
                Description = "Enter Description",

                //URL
                Url = "Enter URL",

                //image
                Image = "",
            };

            // Get the current set, and append the new record to it
            // because IEnumerable does not have Add
            var dataSet = GetAllData();

            //add data to set
            dataSet = dataSet.Append(data);

            //update database
            SaveData(dataSet);

            //return updated database
            return data;
        }

        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <returns></returns>
        public ProductModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetAllData();

            //find product via id 
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            //create new dataset
            var newDataSet = GetAllData().Where(m => m.Id.Equals(id) == false);

            //update database
            SaveData(newDataSet);

            //return database
            return data;
        }
    }
}
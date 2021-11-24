using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Model for products 
/// </summary>
namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Model for products, all information is stored here 
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// set and get id for each product
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// set and get for maker 
        /// </summary>
        public string Maker { get; set; }

        /// <summary>
        /// set and get image to describe each product
        /// </summary>
        [JsonPropertyName("img")]
        public string Image { get; set; }

        /// <summary>
        /// get and set url attached to each product
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// title of each product, has max and min length of string
        /// </summary>
        [StringLength(maximumLength: 33, MinimumLength = 1, ErrorMessage = "The Title should have a length of more than {2} and less than {1}")]
        public string Title { get; set; }

        /// <summary>
        /// get and set description of product
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// list of ratings, an int stored for each product
        /// </summary>
        public int[] Ratings { get; set; }

        /// <summary>
        /// set and get of quantity of each product
        /// </summary>
        public string Quantity { get; set; }

        /// <summary>
        /// set and get price of each product, with a max and min range
        /// </summary>
        [Range(-1, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Price { get; set; }
     
    }
}
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using System.Linq;


namespace UnitTests.Services
{
    public class JsonFileProductServiceTests
    {
        #region TestSetup
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        #region AddRating

        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_Invalid_Product_Should_Return_False()
        {
            // Arrange
            

            // Act
            var product_result = TestHelper.ProductService.AddRating("light=house", 2);

            // Assert
            // Do Product Exist ?
            Assert.AreEqual(false, product_result);
        }

        [Test]
        public void Add_InValidRating_ValidProduct_Should_Return_False()
        {
            // Arrange
            string valid_product = "jenlooper-survival";

            // Act
            // Rating Below Zero (rating < 0) 
            var rating_below = TestHelper.ProductService.AddRating(valid_product, -1);

            // Rating Above Five (rating > 5)
            var rating_above = TestHelper.ProductService.AddRating(valid_product, 6);

            // Assert
            // Is Rating Given Not Below Zero ?
            Assert.AreEqual(false, rating_below);

            // Is Rating Given Above Five ?
            Assert.AreEqual(false, rating_above);
        }

        [Test]
        public void AddRating_ValidRating_ValidProduct_Should_Return_True()
        {
            // Assert
            string valid_product = "jenlooper-survival";
            int valid_rating = 4;
            var data = TestHelper.ProductService.GetAllData().First(x => x.Id == valid_product);

            // Act
            var product_rating = TestHelper.ProductService.AddRating(data.Id, valid_rating);

            // Assert
            // Is Data.Rating NUll ?
            Assert.AreEqual(null, data.Ratings);

            // Is Rating Added ?
            Assert.AreEqual(true, product_rating);
        }


        [Test]
        public void AddRating_Valid_Product_Valid_Rating_Valid_Should_Return_True()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        #endregion AddRating

        #region UpdateData
        [Test]
        public void UpdateData_Invalid_ProductModel_Should_Return_Null()
        {
            // Arrange
            string invalidID = "fakeID";
            ProductModel productModel = new ProductModel()
            {
                Id = invalidID,
                Title = "NewUpdate",
                Description = "NewDescription",
                Maker = "MakerTest",
                Image = "Image.png",
                Quantity = "1",
                Price = 40,
                Url = "www.google.com"
            };

            // Act
            var updateResult = TestHelper.ProductService.UpdateData(productModel);

            // Reset

            // Assert
            Assert.AreEqual(null, updateResult);
        }

        [Test]
        public void UpdateData_Valid_ProductModel_Should_Return_ProductModel()
        {
            // Arrange

            string validID = "jenlooper-cactus";
            ProductModel productModel = new ProductModel()
            {
                Id = validID,
                Title = "NewUpdate",
                Description = "NewDescription",
                Maker = "MakerTest",
                Image = "Image.png",
                Quantity = "1",
                Price = 40,
                Url = "www.google.com"
            };

            
            // Act
            var updateResult = TestHelper.ProductService.UpdateData(productModel);

            // Reset
            var findProduct = TestHelper.ProductService.GetAllData().ToList().Find(x => x.Id == validID);

            // Assert

            Assert.AreEqual(true, updateResult.Id == findProduct.Id);
            Assert.AreEqual(true, updateResult.Description == findProduct.Description);
            Assert.AreEqual(true, updateResult.Quantity == findProduct.Quantity);
        }
        #endregion UpdateData

        #region CreateData

        [Test]
        public void CreateData_ValidProduct_Should_Return_ProductModel()
        {
            // Arrange

            // Act

            var getResult = TestHelper.ProductService.CreateData();
            // Reset

            // Assert
            Assert.AreEqual(true, getResult.Description.Equals("Enter Description"));
            Assert.AreEqual(true, getResult.Title.Equals("Enter Title"));
        }

        #endregion CreateData

        #region DeleteData
        [Test]
        public void DeleteData_ValidId_Should_Return_ProductModel()
        {
            // Arrange

            var validId = "jenlooper-light";

            // Act

            var getResult = TestHelper.ProductService.DeleteData(validId);

            // Reset

            // Assert
            Assert.AreEqual(true, getResult.Maker.Equals("jenlooper"));
            Assert.AreEqual(true, getResult.Title.Equals("A beautiful switch-on book light"));


        }
        #endregion DeleteData
    }
}

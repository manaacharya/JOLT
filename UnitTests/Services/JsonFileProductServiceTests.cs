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
        public void Add_ValidRating_ValidProduct_Should_Return_True()
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
    }
}

using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
using System.Linq;

namespace UnitTests.Services
{
    /// <summary>
    /// Test for JsonFileProductServiceTests 
    /// </summary>
    public class JsonFileProductServiceTests
    {
        /// <summary>
        /// Test set up 
        /// </summary>
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        /// <summary>
        /// Test adding rating for an invalid product
        /// </summary>
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

        /// <summary>
        /// Add rating to an invalid product 
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("Coder-Coder", 7);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// test adding an invalid rating below 0  
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_InValid_Rating_Below_0_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("sailorhg-led", -1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// test adding an invalid rating above 5
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_InValid_Rating_Above_5_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("sailorhg-led", 6);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Add new rating creates new list 
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Valid_Rating_When_Existing_Rating_Is_Null_Should_Return_True()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("selinazawacki-soi-shirt", 3);

            // Assert
            Assert.AreEqual(true, result);
        }

        
        /// <summary>
        /// Add rating successfully 
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Valid_Rating_Valid_Should_Return_True()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            //count length of rating list 
            var countOriginal = data.Ratings.Length;

            // Act
            //check adding data 
            var result = TestHelper.ProductService.AddRating(data.Id, 5);

            //check adding to list correct
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);

            //check list length 
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);

            //check last item in list 
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        #endregion AddRating

        /// <summary>
        /// test updating data
        /// </summary>
        #region UpdateData
        [Test]
        public void UpdateData_ValidProductModel_InValidProductID_Should_Return_Null()
        {
            // Arrange

            // Instance of ProductModel
            var product = new ProductModel()
            {
                //id
                Id = "fakeproduct",

                //description 
                Description = "This is a Fake Product"
            };
            // Act

            // Fetch result from Updating Product
            var getResult = TestHelper.ProductService.UpdateData(product);

            // Reset

            // Assert
            //null result 
            Assert.AreEqual(null, getResult);
        }
        #endregion UpdateData
    }
}
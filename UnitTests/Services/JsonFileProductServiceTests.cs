using NUnit.Framework;
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
        public void AddRating_InValid_Product_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("Coder-Coder", 7);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_Valid_Product_InValid_Rating_Below_0_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("sailorhg-led", -1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_Valid_Product_InValid_Rating_Above_5_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("sailorhg-led", 6);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_Valid_Product_Valid_Rating_When_Existing_Rating_Is_Null_Should_Return_True()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("selinazawacki-soi-shirt", 3);

            // Assert
            Assert.AreEqual(true, result);
        }

        // ....

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
        public void UpdateData_ValidProductModel_InValidProductID_Should_Return_Null()
        {
            // Arrange

            // Instance of ProductModel
            var product = new ProductModel()
            {
                Id = "fakeproduct",
                Description = "This is a Fake Product"
            };
            // Act

            // Fetch result from Updating Product
            var getResult = TestHelper.ProductService.UpdateData(product);

            // Reset

            // Assert

            Assert.AreEqual(null, getResult);
        }
        #endregion UpdateData
    }
}
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Read
{
    /// <summary>
    /// Unit test for read products
    /// </summary>
    public class ReadTests
    {
        /// <summary>
        /// set up page model 
        /// </summary>
        #region TestSetup
        public static ReadModel pageModel;

        /// <summary>
        /// Initialize model for testing 
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// Test on get, should return products
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("jenlooper-cactus");

            // Assert
            //model state is valid 
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            //check product via certian title 
            Assert.AreEqual("The Quantified Cactus: An Easy Plant " +
                "Soil Moisture Sensor", pageModel.Product.Title);
        }

        /// <summary>
        /// Test invalid id 
        /// </summary>
        [Test]
        public void OnGet_InValid_Id_Bougs_Should_Return_Products()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet("Bogus") as RedirectToPageResult;

            // Assert
            Assert.AreEqual("./Index", result.PageName);
        }
        #endregion OnGet
    }
}
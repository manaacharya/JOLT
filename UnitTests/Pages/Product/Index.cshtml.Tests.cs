using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Index
{
    /// <summary>
    /// Unit test for index for products
    /// </summary>
    public class IndexTests
    {
        /// <summary>
        /// Test set up for page context
        /// </summary>
        #region TestSetup
        public static PageContext pageContext;

        /// <summary>
        /// page model for IndexModel
        /// </summary>
        public static IndexModel pageModel;

        /// <summary>
        /// Initialize index model
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new IndexModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// test on get to return products in main page
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            //page model is valid 
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            //check products are in list 
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }
        #endregion OnGet
    }
}
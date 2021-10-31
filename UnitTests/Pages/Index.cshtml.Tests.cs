using System.Linq;

using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Index
{
    /// <summary>
    /// IndexTests Class for Index Page
    /// </summary>
    public class IndexTests
    {
        #region TestSetup

        // Index Model static field/attribute
        public static IndexModel PageModel;

        /// <summary>
        /// Test Initialization for Index Page Test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // logging attribute created
            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();

            // Index Model instance created with logging attribute passed in constructor
            PageModel = new IndexModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test for OnGet() Valid Products
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // ----------------- Arrange -----------------

            // ----------------- Act -----------------
            PageModel.OnGet();

            // ----------------- Assert -----------------
            Assert.AreEqual(true, PageModel.ModelState.IsValid);
            Assert.AreEqual(true, PageModel.Products.ToList().Any());
        }
        #endregion OnGet
    }
}
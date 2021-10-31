using System.Linq;

using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Index
{
    public class IndexTests
    {
        #region TestSetup

        public static IndexModel PageModel;

        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();

            PageModel = new IndexModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            PageModel.OnGet();

            // Assert
            Assert.AreEqual(true, PageModel.ModelState.IsValid);
            Assert.AreEqual(true, PageModel.Products.ToList().Any());
        }
        #endregion OnGet
    }
}
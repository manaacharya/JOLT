using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;


namespace UnitTests.Pages.Product.Delete
{
    /// <summary>
    /// Unit tests for delete product
    /// </summary>
    public class DeleteTests
    {
        /// <summary>
        /// Test setup of delete
        /// </summary>
        #region TestSetup
        public static DeleteModel pageModel;

        /// <summary>
        ///Initialize product services 
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new DeleteModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// Test on get 
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("selinazawacki-shirt");

            // Assert
            //model state is valid 
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            //matches product title 
            Assert.AreEqual("Floppy Crop", pageModel.Product.Title);
        }
        #endregion OnGet

        /// <summary>
        /// Check return of products
        /// </summary>
        #region OnPost
        [Test]
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange

            // First Create the product to delete
            //create data 
            pageModel.Product = TestHelper.ProductService.CreateData();

            //title
            pageModel.Product.Title = "Example to Delete";

            //update data
            TestHelper.ProductService.UpdateData(pageModel.Product);

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            //model state valid 
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            //returns to main page 
            Assert.AreEqual(true, result.PageName.Contains("Index"));

            // Confirm the item is deleted
            Assert.AreEqual(null, TestHelper.ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(pageModel.Product.Id)));
        }

        [Test]
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPost
    }
}
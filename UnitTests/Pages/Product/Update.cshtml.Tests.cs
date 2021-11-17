using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.Update
{
    /// <summary>
    /// Unit test for update products
    /// </summary>
    public class UpdateTests
    {
        /// <summary>
        /// create update model for pagemodel 
        /// </summary>
        #region TestSetup
        public static UpdateModel pageModel;

        /// <summary>
        /// initialize for testing
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// Test on get
        /// Should return products 
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("selinazawacki-shirt");

            // Assert
            //model is valid 
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            //compare via product title 
            Assert.AreEqual("Floppy Crop", pageModel.Product.Title);
        }
        #endregion OnGet

        /// <summary>
        /// Test onpost should return products
        /// </summary>
        #region OnPost
        [Test]
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange
            //create new product
            pageModel.Product = new ProductModel
            {
                //product id
                Id = "selinazawacki-moon",

                //title
                Title = "title",

                //description
                Description = "description",

                //url
                Url = "url",

                //image
                Image = "image"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            //model state is valid 
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            //check redirection to main page 
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }

        /// <summary>
        /// Test onpost if invalid return to main page
        /// </summary>
        [Test]
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            //check model state is valid 
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPost
    }
}
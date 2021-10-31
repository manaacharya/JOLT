using System.Diagnostics;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Error
{
    /// <summary>
    /// ErrorTests Class for Error Page
    /// </summary>
    public class ErrorTests
    {
        #region TestSetup
        // Error Model static field/attribute
        public static ErrorModel PageModel;

        /// <summary>
        /// Test Initialization for Error Page Test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // logging attribute created
            var MockLoggerDirect = Mock.Of<ILogger<ErrorModel>>();

            // Error Model instance created with logging attribute passed in constructor
            PageModel = new ErrorModel(MockLoggerDirect)
            {
                // Set the Page Context
                PageContext = TestHelper.PageContext,
                // Set the Temp Data
                TempData = TestHelper.TempData,
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test for OnGet() Valid Activity in Error Page
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            // ----------------- Arrange -----------------

            Activity activity = new Activity("activity");
            activity.Start();

            // ----------------- Act -----------------
            PageModel.OnGet();

            // ----------------- Reset -----------------
            activity.Stop();

            // ----------------- Assert -----------------
            Assert.AreEqual(true, PageModel.ModelState.IsValid);
            Assert.AreEqual(activity.Id, PageModel.RequestId);
        }

        /// <summary>
        /// Test for OnGet() InValid Activity 
        /// </summary>
        [Test]
        public void OnGet_InValid_Activity_Null_Should_Return_TraceIdentifier()
        {
            // ----------------- Arrange -----------------

            // ----------------- Act -----------------
            PageModel.OnGet();

            // ----------------- Reset -----------------

            // ----------------- Assert -----------------
            Assert.AreEqual(true, PageModel.ModelState.IsValid);
            Assert.AreEqual("trace", PageModel.RequestId);
            Assert.AreEqual(true, PageModel.ShowRequestId);
        }
        #endregion OnGet
    }
}
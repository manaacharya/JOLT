using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;

using ContosoCrafts.WebSite.Pages;

using System;
using System.Collections.Generic;
using System.Linq;


using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitTests.Pages.Polls
{   
    /// <summary>
    /// PollPageTest tests all code in PollsPage.cshtml
    /// </summary>
    class PollsPageTest
    {
        #region TestSetup
        //create PollsPagemodel object 
        public static PollsPageModel PageModel;

        /// <summary>
        /// create test logger and PageContect object for testing 
        /// </summary>
        [SetUp] 
        public void TestInitialize()
        {
            //logger object
            var MockLoggerDirect = Mock.Of<ILogger<PollsPageModel>>();

            //assign logger to PageModel 
            PageModel = new PollsPageModel(MockLoggerDirect)
            {
                //create PageContext object 
                PageContext = TestHelper.PageContext
            };
        }
        #endregion TestSetup

        /// <summary>
        /// Test OnPost yields valid results 
        /// </summary>
        [Test]
        #region OnPost
        public void OnPost_Valid()
        {
            // ----------------- Arrange -----------------
            // ----------------- Act -----------------
            // Fetch result from OnPost()
            var result = PageModel.OnPostGuidelines() as RedirectToPageResult;

            // ----------------- Assert -----------------
            //check return null when OnPost
            Assert.AreEqual(null, result);
        }
        #endregion OnPost


    }
}

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
        public static PollsPageModel PageModel;
        
        [SetUp] 
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<PollsPageModel>>();

            PageModel = new PollsPageModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext
            };
        }
        #endregion TestSetup

        [Test]
        #region OnPost
        public void OnPost_Valid()
        {
            // ----------------- Arrange -----------------
            // ----------------- Act -----------------
            // Fetch result from OnPost()
            var result = PageModel.OnPostGuidelines() as RedirectToPageResult;

            // ----------------- Assert -----------------
            // Assert.AreEqual(true, result.PageName.Contains("/PollsPage/GuidelinePage"));
            Assert.AreEqual(null, result);
        }
        #endregion OnPost


    }
}

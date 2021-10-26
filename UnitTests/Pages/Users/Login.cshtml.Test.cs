using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;

using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Users
{
    class LoginTest
    {
        #region TestSetup
        public static ContosoCrafts.WebSite.Pages.LoginModel pageModel;

        [SetUp]

        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<ContosoCrafts.WebSite.Pages.LoginModel>>();

            pageModel = new ContosoCrafts.WebSite.Pages.LoginModel(MockLoggerDirect, TestHelper.UserService)
            {
                PageContext = TestHelper.PageContext
            };

        }
        #endregion TestSetup

        #region OnPost
        [Test]
        public void valid_should_do()
        {
            Assert.AreEqual('2', '2');
        }
        #region OnPost

    }
    
}

using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;

using ContosoCrafts.WebSite.Pages;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitTests.Pages.Users
{
    class LoginWelcomePageTest
    {
        #region
        public static Login_WelcomeModel LoginWelcomeModel;

        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<Login_WelcomeModel>>();

        }
        #endregion
    }
}

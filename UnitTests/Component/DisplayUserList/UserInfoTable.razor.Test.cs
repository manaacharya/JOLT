using Bunit;
using NUnit.Framework;
using ContosoCrafts.WebSite.Component;
using Microsoft.Extensions.DependencyInjection;
using ContosoCrafts.WebSite.Services;
using System.Linq;

namespace UnitTests.Component.DisplayUserList
{
    /// <summary>
    /// Tests UserInfoTable Razor Page
    /// </summary>
    class UserInfoTable : BunitTestContext
    {
        #region TestSetup

        /// <summary>
        /// Test Setup Initialization
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region DefaultTest

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Default_Get_Should_Return_All_Users()
        {
            // Arrange

            // Poll Service Singleton Initiation
            Services.AddSingleton<JsonFilePollService>(TestHelper.PollService);

            // User Service Singleton Initiation
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Act
            // Render Page Component
            var page = RenderComponent<UserInfoTable>();
            var result = page.Markup;

            // Assert

            // Component Checklist
            Assert.Equals(true, result.Contains("Jason"));
        }

        #endregion DefaultTest
    }
}

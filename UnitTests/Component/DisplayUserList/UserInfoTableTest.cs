using Bunit;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Component.DisplayUserList;

namespace UnitTests.Component.DisplayUserList
{
    /// <summary>
    /// Tests UserInfoTable Razor Page
    /// </summary>
    class UserInfoTableTest : BunitTestContext
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

            // User Service Singleton Initiation
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Act
            // Render Page Component
            var page = RenderComponent<UserInfoTable>();
            var result = page.Markup;

            // Assert

            // Component Checklist
            Assert.AreEqual(true, result.Contains("Jason"));
        }

        #endregion DefaultTest
    }
}

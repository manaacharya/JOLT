using Bunit;
using NUnit.Framework;
using ContosoCrafts.WebSite.Component.PollPage;
using Microsoft.Extensions.DependencyInjection;
using ContosoCrafts.WebSite.Services;
using System.Linq;


namespace UnitTests.Component.PollsComponent
{
    class IndexPollsLists:BunitTestContext
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup


        [Test]
        public void PollList_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFilePollService>(TestHelper.PollService);
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Act
            var page = RenderComponent<IndexPollsList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Aerospace company"));
        }

        #region IsLoggedIn

       /* [Test]
        public void IsLoggedIn_*/

        #endregion IsLoggedIn

    }
}

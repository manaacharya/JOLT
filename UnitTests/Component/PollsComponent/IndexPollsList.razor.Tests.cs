using Bunit;
using NUnit.Framework;
using ContosoCrafts.WebSite.Component;
using Microsoft.Extensions.DependencyInjection;
using ContosoCrafts.WebSite.Services;
using System.Linq;


namespace UnitTests.Component.PollsComponent
{
    class IndexPollsList:BunitTestContext
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
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<IndexPollsList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("The Quantified Cactus: An Easy Plant Soil Moisture Sensor"));
        }



    }
}

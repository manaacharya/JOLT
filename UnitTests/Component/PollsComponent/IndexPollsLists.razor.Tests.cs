using Bunit;
using NUnit.Framework;
using ContosoCrafts.WebSite.Component.PollPage;
using Microsoft.Extensions.DependencyInjection;
using ContosoCrafts.WebSite.Services;
using System.Linq;


namespace UnitTests.Component.PollsComponent
{
    class IndexPollsLists : BunitTestContext
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

        #region UpdateOpinionInput

        [Test]
        public void UpdateOpinionInput_Valid_Name_Valid_Id_Should_Update_Values()
        {
            // Arrange
            Services.AddSingleton<JsonFilePollService>(TestHelper.PollService);
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            var page = RenderComponent<IndexPollsList>();

            var radioButtonsList = page.FindAll("input");

            var id = "Boeing";

            // Find one that matches 
            var radios = radioButtonsList.First(m => m.Id.Contains(id));

            // Act
            radios.Change(id);

            // Reset

            // Assert
            var pageMarkup = page.Markup;

            Assert.AreEqual(true, pageMarkup.Contains("Aerospace companies with the best aircrafts"));
        }

        #endregion UpdateOpinionInput


        #region SubmitVote

        [Test]
        public void SubmitVote_Valid_OpinionName_InValid_PollId_Should_Return_False()
        {
            // Arrange
            // Arrange Poll Service
            Services.AddSingleton<JsonFilePollService>(TestHelper.PollService);
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Render components for IndexPollsList
            var page = RenderComponent<IndexPollsList>();

            // List of Buttons with buttons
            var buttonsList = page.FindAll("button");

            // Find the Button for Submitting a Poll once clicked on 
            var button = buttonsList.First(x => x.Id.Contains("voteBtn"));

            // Act
            button.Click();

            // Reset
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Aerospace companies with the best aircrafts"));
        }

        [Test]
        public void SubmitVote_Valid_OpinionName_Valid_Id_Should_Count_Vote()
        {
            // Arrange
            // Arrange Poll Service
            Services.AddSingleton<JsonFilePollService>(TestHelper.PollService);
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Render components for IndexPollsList
            var page = RenderComponent<IndexPollsList>();

            // List of Buttons with buttons
            var buttonsList = page.FindAll("button");

            // Find the Button for Submitting a Poll once clicked on 
            var button = buttonsList.First(x => x.Id.Contains("voteBtn"));

            var radioButtonsList = page.FindAll("input");

            var id = "Boeing";

            var radios = radioButtonsList.First(m => m.Id.Contains(id));

            radios.Change(id);

            // Act
            button.Click();

            // Reset
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Aerospace companies with the best aircrafts"));
        }

        #endregion SubmitVote

    }
}
using Bunit;
using NUnit.Framework;
using ContosoCrafts.WebSite.Component.PollPage;
using Microsoft.Extensions.DependencyInjection;
using ContosoCrafts.WebSite.Services;
using System.Linq;


namespace UnitTests.Component.PollsComponent
{
    /// <summary>
    /// IndexPollsList Class
    /// </summary>
    class IndexPollsLists : BunitTestContext
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

        /// <summary>
        /// Test for Rendering the Polls Content
        /// </summary>
        [Test]
        public void PollList_Default_Should_Return_Content()
        {
            // Arrange

            // Poll Service Singleton Initiation
            Services.AddSingleton<JsonFilePollService>(TestHelper.PollService);
            // User Service Singleton Initiation
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Act

            // Page Component Rendering
            var page = RenderComponent<IndexPollsList>();
            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            
            // Component Checklist
            Assert.AreEqual(true, result.Contains("Aerospace company"));
        }

        #region UpdateOpinionInput

        /// <summary>
        /// Test for Radio Button Selection
        /// </summary>
        [Test]
        public void UpdateOpinionInput_Valid_Name_Valid_Id_Should_Update_Values()
        {
            // Arrange

            // Poll Service Singleton Initiation
            Services.AddSingleton<JsonFilePollService>(TestHelper.PollService);
            // User Service Singleton Initiation
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Page Component Rendering
            var page = RenderComponent<IndexPollsList>();
            // Get all inputs from html
            var inputList = page.FindAll("input");

            // Initialize Id 
            var id = "Boeing";
            // Find one that matches the Id
            var radios = inputList.First(m => m.Id.Contains(id));

            // Act

            // Radio Button Event Action
            radios.Change(id);

            // Reset
            
            // Get the Page markup after radio button event
            var pageMarkup = page.Markup;

            // Assert

            // Component Checklist
            Assert.AreEqual(true, pageMarkup.Contains("Aerospace companies with the best aircrafts"));
        }

        #endregion UpdateOpinionInput


        #region SubmitVote

        /// <summary>
        /// Test for Poll submission with InValid Poll Id and Valid OpinionName
        /// </summary>
        [Test]
        public void SubmitVote_Valid_OpinionName_InValid_PollId_Should_Return_False()
        {
            // Arrange

            // Poll Service Singleton Initiation
            Services.AddSingleton<JsonFilePollService>(TestHelper.PollService);
            // User Service Singleton Initiation
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Page Component Rendering
            var page = RenderComponent<IndexPollsList>();

            // Get all buttons from html
            var buttonsList = page.FindAll("button");

            // Find one that matches the "voteBtn"
            var button = buttonsList.First(x => x.Id.Contains("voteBtn"));

            // Act

            // Button Click Event Action
            button.Click();

            // Reset

            // Get the Page markup after button event
            var pageMarkup = page.Markup;

            // Assert

            // Component Checklist
            Assert.AreEqual(true, pageMarkup.Contains("Aerospace companies with the best aircrafts"));
        }

        /// <summary>
        /// Test for Poll Submission with Valid PollID and Valid OpinionName
        /// </summary>
        [Test]
        public void SubmitVote_Valid_OpinionName_Valid_PollId_Should_Count_Vote()
        {
            // Arrange

            // Poll Service Singleton Initiation
            Services.AddSingleton<JsonFilePollService>(TestHelper.PollService);
            // User Service Singleton Initiation
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Page Component Rendering
            var page = RenderComponent<IndexPollsList>();

            // Get all buttons from html
            var buttonsList = page.FindAll("button");

            // Find one that matches the "voteBtn"
            var button = buttonsList.First(x => x.Id.Contains("voteBtn"));

            // Get all inputs from html
            var inputList = page.FindAll("input");

            // Initialize Id 
            var id = "Boeing";
            // Find one that matches the Id
            var radios = inputList.First(m => m.Id.Contains(id));

            // Radio Button Event Action
            radios.Change(id);

            // Act

            // Button Click Event Action
            button.Click();

            // Reset

            // Get the Page markup after button event
            var pageMarkup = page.Markup;

            // Assert

            // Component Checklist
            Assert.AreEqual(true, pageMarkup.Contains("Aerospace companies with the best aircrafts"));
        }

        #endregion SubmitVote

        // Sample Unit Test

        #region MessagePrototype

        [Test]
        public void AddPoll_Should_Return_PopUp()
        {

            // Poll Service Singleton Initiation
            Services.AddSingleton<JsonFilePollService>(TestHelper.PollService);
            // User Service Singleton Initiation
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Page Component Rendering
            var page = RenderComponent<IndexPollsList>();


            // Modal Button 
            // Get all buttons from html
            var buttonsList = page.FindAll("button");

            // Find one that matches the "voteBtn"
            var button = buttonsList.First(x => x.Id.Contains("AddOpinionsBtn"));


            button.Click();


            //  End Of Modal Button


            // Submiting Opinions
            // Get all buttons from html
            buttonsList = page.FindAll("button");

            var getButton = buttonsList.First(x => x.Id.Equals("submitOpinionsBtn"));


            getButton.Click();

            // End of Submiting Opinions



            // Just some Page MarkUps
            var pageMarkup = page.Markup;

            // Assert

            // Component Checklist
            Assert.AreEqual(true, pageMarkup.Contains("Aerospace company"));


        }

        #endregion MessagePrototype

    }
}
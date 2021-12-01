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
            // Render Cards
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
        public void UpdateOpinionInput_Valid_Name_Valid_Id_Valid_Should_Update_Values()
        {
            // Arrange

            // Poll Service Singleton Initiation
            Services.AddSingleton<JsonFilePollService>(TestHelper.PollService);
            // User Service Singleton Initiation
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Page Component Rendering
            var page = RenderComponent<IndexPollsList>();

            
            // Get all inputs from HTML
            var inputList = page.FindAll("input");

            // Initialize Id 
            var id = "Boeing";
            // Find one that matches the Id
            // var radios = inputList.First(m => m.Id.Contains(id));
            var radios = inputList.ElementAt(1); // hard-coded
            // Act

            // Radio Button Event Action
            radios.Change(id);

            // Reset
            
            // Get the Page markup after radio button event
            var pageMarkup = page.Markup;

            // Assert

            // Component Checklist
            Assert.AreEqual(true, pageMarkup.Contains("Aerospace company"));
        }

        #endregion UpdateOpinionInput


        #region SubmitVote

        /// <summary>
        /// Test for Poll submission with InValid Poll Id and Valid OpinionName
        /// </summary>
        [Test]
        public void SubmitVote_Invalid_OpinionName_Valid_PollId_Invalid_Should_Return_False()
        {
            // Arrange

            // Poll Service Singleton Initiation
            Services.AddSingleton<JsonFilePollService>(TestHelper.PollService);
            // User Service Singleton Initiation
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Page Component Rendering
            var page = RenderComponent<IndexPollsList>();

            // Get all buttons from HTML
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
            Assert.AreEqual(true, pageMarkup.Contains("Aerospace company"));
        }

        /// <summary>
        /// Test for Poll Submission with Valid PollID and Valid OpinionName
        /// </summary>
        [Test]
        public void SubmitVote_Valid_OpinionName_Valid_PollId_Vaild_Should_Count_Vote()
        {
            // Arrange
            // Poll Service Singleton Initiation
            Services.AddSingleton<JsonFilePollService>(TestHelper.PollService);
            // User Service Singleton Initiation
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Page Component Rendering
            var page = RenderComponent<IndexPollsList>();

            // Get all buttons from HTML
            var buttonsList = page.FindAll("button");

            // Find one that matches the "voteBtn"
            var button = buttonsList.First(x => x.Id.Contains("voteBtn"));

            // Get all inputs from HTML
            var inputList = page.FindAll("input");

            // Initialize Id 
            var id = "Boeing";
            // Find one that matches the Id
            // var radios = inputList.First(m => m.Id.Contains(id));
            var radios = inputList.ElementAt(1);

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
            Assert.AreEqual(true, pageMarkup.Contains("Aerospace company"));
        }

        #endregion SubmitVote

        #region AddPoll
        
        /// <summary>
        /// Invalid Opinion Test
        /// </summary>
        [Test]
        public void AddPolls_InValid_Opinions_Invalid_PollId_Valid_Should_Return_Error_Message()
        {
            // Arrange

            // Poll Service Singleton Initiation
            Services.AddSingleton<JsonFilePollService>(TestHelper.PollService);

            // User Service Singleton Initiation
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Page Component Rendering
            var page = RenderComponent<IndexPollsList>();

            // Modal Button 
            // Get all buttons from HTML
            var buttonsList = page.FindAll("button");

            // Find one that matches the "voteBtn"
            var button = buttonsList.First(x => x.Id.Contains("AddOpinionsBtn"));

            // trigger button
            button.Click();

            // Submit Opinions
            // Get all buttons from HTML
            buttonsList = page.FindAll("button");

            // find button
            var getButton = buttonsList.First(x => x.Id.Equals("submitOpinionsBtn"));

            // Act

            // trigger button
            getButton.Click();

            // Reset

            // Get Page MarkUp
            var pageMarkup = page.Markup;

            // Assert
            // page returns correct poll
            Assert.AreEqual(true, pageMarkup.Contains("Aerospace company"));
        }


        /// <summary>
        /// Default Test for Adding a Opinion to a Poll
        /// </summary>
        [Test]
        public void AddPoll_Valid_Opinions_Valid_PollId_Valid_Should_Return_Add_Opinions()
        {
            // Arrange

            // Poll Service Singleton Initiation
            Services.AddSingleton<JsonFilePollService>(TestHelper.PollService);
            // User Service Singleton Initiation
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Page Component Rendering
            var page = RenderComponent<IndexPollsList>();

            // Modal Button 
            // Get all buttons from HTML
            var buttonsList = page.FindAll("button");

            // Find one that matches the "voteBtn"
            var button = buttonsList.First(x => x.Id.Contains("AddOpinionsBtn"));

            // trigger button
            button.Click();

            // Input tag
            var inputList = page.FindAll("input");

            // Find one that matches the Id
            var inputListLen = inputList.Count;

            //index Id
            var inputOneIndex = inputListLen - 2;

            //index Id 
            var inputTwoIndex = inputListLen - 1;

            // var inputOne = inputList.First(m => m.Id.Contains(inputidOne));
            var inputOne = inputList.ElementAt(inputOneIndex);

            // var inputTwo = inputList.First(m => m.Id.Contains(inputidTwo));
            var inputTwo = inputList.ElementAt(inputTwoIndex);

            // Add Values to INputs
            inputOne.Change("Sample");
            inputTwo.Change("Sample2");

            // Submit Opinions
            // Get all buttons from HTML
            buttonsList = page.FindAll("button");

            // find button
            var submitOpinionsButton = buttonsList.First(x => x.Id.Equals("submitOpinionsBtn"));

            // Act

            // trigger button
            submitOpinionsButton.Click();

            // Just some Page MarkUps
            var pageMarkup = page.Markup;

            // Assert

            // Component Checklist
            Assert.AreEqual(true, pageMarkup.Contains("Aerospace company"));
        }

        #endregion AddPoll

        #region FilterPoll

        /// <summary>
        /// Check filtering poll works when everything is valid 
        /// </summary>
        [Test]
        public void FilterPoll_Valid_FilterData_Valid_Should_Return_Filtered_Polls()
        {
            // Arrange

            // Poll Service Singleton Initiation
            Services.AddSingleton<JsonFilePollService>(TestHelper.PollService);

            // User Service Singleton Initiation
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Page Component Rendering
            var page = RenderComponent<IndexPollsList>();

            // Modal Button 
            // Get all buttons from HTML
            var buttonsList = page.FindAll("button");

            // Find one that matches the "voteBtn"
            var enableFilterButton = buttonsList.First(x => x.Id.Contains("enableFilterBtn"));

            // Input tag
            var inputList = page.FindAll("input");

            // Filter Text starting index
            var filterTextInputIndex = 0;

            //filter text 
            var filterTextInput = inputList.ElementAt(filterTextInputIndex);

            // Act

            // Type in key word for filter
            filterTextInput.Change("Company");

            // Click on "Filter"/ Trigger Button
            enableFilterButton.Click();


            // Just some Page MarkUps
            var pageMarkup = page.Markup;

            // Reset 

            // Assert

            // Component Checklist
            Assert.AreEqual(true, pageMarkup.Contains("Aerospace company"));
            //second check 
            Assert.AreEqual(false, pageMarkup.Contains("Telekinesis"));
        }

        /// <summary>
        /// Once filter has been cleared, all polls should be displayed
        /// </summary>
        [Test]
        public void DisableFilter_Valid_FilterData_Valid_Should_Return_All_Polls()
        {
            // Arrange

            // Poll Service Singleton Initiation
            Services.AddSingleton<JsonFilePollService>(TestHelper.PollService);

            // User Service Singleton Initiation
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Page Component Rendering
            var page = RenderComponent<IndexPollsList>();

            // Modal Button 
            // Get all buttons from HTML
            var buttonsList = page.FindAll("button");

            // Find one that matches the "enableFilterBtn"
            var enableFilterButton = buttonsList.First(x => x.Id.Contains("enableFilterBtn"));

            // Find one that matches the "disableFilterBtn"
            var disableFilterButton = buttonsList.First(x => x.Id.Contains("disableFilterBtn"));

            // Input tag
            var inputList = page.FindAll("input");

            // Filter Text index 
            var filterTextInputIndex = 0;

            //filter text 
            var filterTextInput = inputList.ElementAt(filterTextInputIndex);

            // Act

            // Type in key word for filter
            filterTextInput.Change("Company");

            // Click on "Filter" (Trigger Button)
            enableFilterButton.Click();

            // Click on "Clear" (Trigger Button)
            disableFilterButton.Click();

            // Just some Page MarkUps
            var pageMarkup = page.Markup;

            // Reset 

            // Assert

            // Component Checklist
            Assert.AreEqual(true, pageMarkup.Contains("Aerospace company"));
            //second check 
            Assert.AreEqual(true, pageMarkup.Contains("Telekinesis"));
        }

        /// <summary>
        /// Check that invalid data should return no polls 
        /// </summary>
        [Test]
        public void EnableFilter_Invalid_FilterData_Invalid_Should_Return_No_Polls()
        {
            // Arrange

            // Poll Service Singleton Initiation
            Services.AddSingleton<JsonFilePollService>(TestHelper.PollService);

            // User Service Singleton Initiation
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Page Component Rendering
            var page = RenderComponent<IndexPollsList>();

            // Modal Button 
            // Get all buttons from HTML
            var buttonsList = page.FindAll("button");

            // Find one that matches the "enableFilterBtn"
            var enableFilterButton = buttonsList.First(x => x.Id.Contains("enableFilterBtn"));

            // Find one that matches the "disableFilterBtn"
            var disableFilterButton = buttonsList.First(x => x.Id.Contains("disableFilterBtn"));

            // Input tag
            var inputList = page.FindAll("input");

            // Filter Text index 
            var filterTextInputIndex = 0;

            //filter text 
            var filterTextInput = inputList.ElementAt(filterTextInputIndex);

            // Act

            // Type in key word for filter
            filterTextInput.Change("Jason");

            // Click on "Filter" (Trigger Button)
            enableFilterButton.Click();

            // Just some Page MarkUps
            var pageMarkup = page.Markup;

            // Reset 

            // Assert

            // Component Checklist
            Assert.AreEqual(false, pageMarkup.Contains("Aerospace company"));

            //second check
            Assert.AreEqual(false, pageMarkup.Contains("Telekinesis"));
        }
        #endregion FilterRoll

    }
}
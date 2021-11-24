using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Pages.PollsPages;

namespace UnitTests.Pages.Polls
{
    /// <summary>
    /// Unit test for create poll page
    /// </summary>
    class CreatePollPage
    {
        #region TestSetup

        // CreatePollPage Model static field/attribute
        public static CreatePollPageModel PageModel;

        /// <summary>
        /// Test Initialization for ProfilePage
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // logging attribute created
            var MockLoggerDirect = Mock.Of<ILogger<CreatePollPageModel>>();

            // Profile Model instance created with logging attribute passed in constructor
            PageModel = new CreatePollPageModel(MockLoggerDirect,
                TestHelper.UserService, TestHelper.PollService)
            {
                // Set the Page Context
                PageContext = TestHelper.PageContext
            
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// check if OnGet() returns the correct message
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Generate_Welcome_Message()
        {
            // Arrange
           
            // Act
            PageModel.OnGet();

            // Reset

            // Assert

            // check model state is valid 
            Assert.AreEqual(true, PageModel.ModelState.IsValid);

            // check whether message was created
            Assert.AreEqual(true, PageModel.Message.Equals($"Welcome :  Create Your Amazing Poll"));
        }
        #endregion OnGet

        #region OnPost

        /// <summary>
        /// Checks if OnPost() creates a valid poll item
        /// </summary>
        [Test]
        public void OnPost_ValidPollModel_ValidUser_Should_Create_Poll()
        {
            // Arrange

            // Valid Author of Poll

            // Poll Model created with attributes
            PageModel.CreatePoll = new CreatePollModel()
            {
                // Author
                AuthorName = "viner765",

                //title
                CreateTitle = "Valid New Poll",

                //description
                CreateDescription = "What is your favorite Valid Poll",

                //opinion 1
                CreateOpinionOne = "Valid Soccer Teams",

                //opinion 2
                CreateOpinionTwo = "Valid Movies Cinema"
            };

            // Act

            // Fetch result from OnPost
            var pageResult = PageModel.OnPost() as RedirectToPageResult;

            // Reset

            // Assert
                        
            // Confirm Poll is Updated
            Assert.AreEqual(true, PageModel.Message.Equals("Awesome! 'Valid New Poll' Created."));

        }

        /// <summary>
        /// checks if invalid user can create a poll
        /// stays in the same page if the user is invalid
        /// </summary>
        [Test]
        public void OnPost_InValidUser_Should_Return_Message()
        {
            // Arrange

            // Invalid Author of Poll : Author Doesn't Exist any Database

            // Poll Model created with attributes
            PageModel.CreatePoll = new CreatePollModel()
            {
                // Author
                AuthorName = "fakename",

                //title
                CreateTitle = "New Poll",

                //description
                CreateDescription = "What is your favorite Poll",

                //opinion 1
                CreateOpinionOne = "Soccer Teams",

                //opinion 2
                CreateOpinionTwo = "Movies Cinema"
            };

            // Act

            // OnPost
            PageModel.OnPost();

            // Reset

            // Assert

            // Confirm Page Redirection
            Assert.AreEqual(true,
                PageModel.Message.Equals("Must Be Logged In To Create Poll"));
        }

        /// <summary>
        /// check if a valid user can create a duplicate poll
        /// if it happens, a error message is displayed
        /// </summary>
        [Test]
        public void OnPost_ValidExistingPollName_ValidUser_Should_Return_Message()
        {
            // Arrange

            // Poll Model created with attributes
            PageModel.CreatePoll = new CreatePollModel()
            {
                // Author
                AuthorName = "viner765",

                //title
                CreateTitle = "New Poll",

                //description
                CreateDescription = "What is your favorite Poll",

                //opinion 1
                CreateOpinionOne = "Soccer Teams",

                //opinion 2
                CreateOpinionTwo = "Movies Cinema"
            };

            // Get User
            var getUser = TestHelper.UserService.GetUser(PageModel.CreatePoll.AuthorName);

            // Add new Poll
            TestHelper.PollService.CreatePoll(PageModel.CreatePoll, getUser.UserID);

            // Act

            // Fetch result from OnPost after submitting duplicate
            var pageResult = PageModel.OnPost() as RedirectToPageResult;

            // Reset

            // Assert

            // Duplicate Entry Was Caught
            Assert.AreEqual(true, PageModel.Message.Equals("Something Went Wrong Try Again"));
        }

        #endregion OnPost

    }
}
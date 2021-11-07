using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using System.Text.Json;
using NUnit.Framework;


namespace UnitTests.Services
{
    public class JsonFilePollService
    {
        #region TestSetup
        /// <summary>
        /// Test Initialization for Poll Services
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        #region GetPoll

        [Test]
        public void GetPoll_ValidID_Should_Return_PollModel()
        {
            // Arrange
            
            // Valid PollID
            var validPollId = 1;

            // Act

            // Fetch Poll Model Result 
            var getModel = TestHelper.PollService.GetPoll(validPollId);

            // Reset

            // Assert

            // check poll id
            Assert.AreEqual(true, getModel.PollID.Equals(validPollId));

            // check poll Title
            Assert.AreEqual(true, getModel.Title.Equals("Aerospace company"));
        }

        [Test]
        public void GetPoll_InValidID_Should_Return_Null()
        {
            // Arrange

            // invalid poll ID
            var invalidID = -333;

            // Act

            // Fetch Poll Model Result
            var getModel = TestHelper.PollService.GetPoll(invalidID);

            // Reset

            // Assert

            // check getModel is null
            Assert.AreEqual(null, getModel);
        }


        [Test]
        public void GetPoll_ValidTitle_Should_Return_PollModel()
        {
            // Arrange

            // Valid PollID
            var validPollTitle = "Aerospace company";

            // Act

            // Fetch Poll Model Result 
            var getModel = TestHelper.PollService.GetPoll(validPollTitle);

            // Reset

            // Assert

            // check poll id
            Assert.AreEqual(true, getModel.PollID.Equals(1));

            // check poll Title
            Assert.AreEqual(true, getModel.Title.Equals("Aerospace company"));
        }

        [Test]
        public void GetPoll_InValidTitle_Should_Return_Null()
        {
            // Arrange

            // invalid poll ID
            var invalidPollTitle  = "Invalid Titles Existance";

            // Act

            // Fetch Poll Model Result
            var getModel = TestHelper.PollService.GetPoll(invalidPollTitle);

            // Reset

            // Assert

            // check getModel is null
            Assert.AreEqual(null, getModel);
        }

        #endregion GetPoll

        #region PollExist

        [Test]
        public void PollExist_ValidID_Should_Return_True()
        {
            // Arrange

            // Valid Poll ID
            var validPollId = 1;

            // Act

            // Fetch result from existance
            var getResult = TestHelper.PollService.PollExist(validPollId);

            // Reset

            // Assert
            Assert.AreEqual(true, getResult);
            
        }

        [Test]
        public void PollExist_InValidID_Should_Return_False()
        {
            // Arrange

            // InValid Poll ID
            var invalidPollId = -81;

            // Act

            // Fetch result from existance
            var getResult = TestHelper.PollService.PollExist(invalidPollId);

            // Reset

            // Assert
            Assert.AreEqual(false, getResult);
        }


        [Test]
        public void PollExist_ValidTitle_Should_Return_True()
        {
            // Arrange
            // Valid Poll Title
            var validPollTitle = "Aerospace company";

            // Act
            
            // Fetch result from existance
            var getResult = TestHelper.PollService.PollExist(validPollTitle);

            // Reset

            // Assert
            Assert.AreEqual(true, getResult);
        }

        [Test]
        public void PollExist_InValidTitle_Should_Return_False()
        {
            // Arrange

            var invalidPollTitle = "Aerospace Not Here";

            // Act

            // Fetch result from existance
            var getResult = TestHelper.PollService.PollExist(invalidPollTitle);
            // Reset

            // Assert

            Assert.AreEqual(false, getResult);
        }

        #endregion PollExist

        #region CreatePoll

        [Test]
        public void CreatePoll_ValidPollCreationModel_Should_Return_PollModel()
        {
            // Arrange

            // Instance of CreatePollModel created
            CreatePollModel createPoll = new CreatePollModel()
            {
                CreateTitle = "Atoms Chemistry Valid Unit Test",
                CreateDescription = "What is your favorite Atom",
                CreateOpinionOne = "Hydrogen",
                CreateOpinionTwo = "Holmium"
            };

            // ID reference back to User
            // PollService not responsible for validating this ID for the User
            var userID = 999;

            // Act

            // Fetch Result from CreatePoll function
            var getResult = TestHelper.PollService.CreatePoll(createPoll, userID);

            // Reset

            // Get OpinionOne from getResult
            var getOpinionOne = getResult.OpinionItems.ToList().Find(x => x.OpinionName.Equals(createPoll.CreateOpinionOne));

            // Assert

            // check pollModel has been Created 

            // check Title
            Assert.AreEqual(true, createPoll.CreateTitle.Equals(getResult.Title));

            // check Description
            Assert.AreEqual(true, createPoll.CreateDescription.Equals(getResult.Description));

            // Check Opinion 1
            Assert.AreEqual(true, getOpinionOne.OpinionName.Equals(createPoll.CreateOpinionOne));
        }

        [Test]
        public void CreatePoll_ValidPollCreationModel_DuplicatePoll_Should_Return_Null()
        {
            // Arrange

            // Instance of CreatePollModel created
            CreatePollModel createPoll = new CreatePollModel()
            {
                CreateTitle = "Duplicate Poll To Be",
                CreateDescription = "What is your favorite Duplicate Poll",
                CreateOpinionOne = "Poll 1",
                CreateOpinionTwo = "Poll 2"
            };

            // ID reference back to User
            // PollService not responsible for validating this ID for the User
            var userID = 999;

            // Create Poll first
            var getResult = TestHelper.PollService.CreatePoll(createPoll, userID);

            // Act

            // Fetch Result from Trying to Add A Duplicate Poll
            getResult = TestHelper.PollService.CreatePoll(createPoll, userID);

            // Reset

            // Assert
            Assert.AreEqual(null, getResult);

        }

        #endregion CreatePoll
    }
}

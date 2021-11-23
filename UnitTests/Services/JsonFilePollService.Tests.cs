using System.Linq;
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;

namespace UnitTests.Services
{
    /// <summary>
    /// Unit Test Class for Poll Services
    /// </summary>
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

        /// <summary>
        /// Test for Getting Poll with Valid Poll ID
        /// </summary>
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

        /// <summary>
        /// Test for Getting Poll with InValid Poll ID
        /// </summary>
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

        /// <summary>
        /// Test for Getting Poll with Valid Title
        /// </summary>
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

        /// <summary>
        /// Test for Getting Poll with Invalid Title
        /// </summary>
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

        /// <summary>
        /// Test for Checking If Poll Exist with Valid ID
        /// </summary>
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

        /// <summary>
        /// Test for Checking if Poll Exists with InValid ID
        /// </summary>
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

        /// <summary>
        /// Test for Checking if Poll Exist With Valid Title
        /// </summary>
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

        /// <summary>
        /// Test for Checking if Poll Exist with InValid Title
        /// </summary>
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

        /// <summary>
        /// Test for Creating Valid Poll That Doesn't Exist Already in DataSet
        /// </summary>
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

        /// <summary>
        /// Test for Creating Valid Poll That Already Exist in Poll Dataset
        /// </summary>
        [Test]
        public void CreatePoll_ValidPollCreationModel_DuplicatePoll_Should_Return_Null()
        {
            // Arrange

            // Instance of CreatePollModel created
            CreatePollModel createPoll = new CreatePollModel()
            {
                //title
                CreateTitle = "Duplicate Poll To Be",

                //description
                CreateDescription = "What is your favorite Duplicate Poll",

                //opinion 1
                CreateOpinionOne = "Poll 1",

                //opinion 2
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

        #region GetOpinion

        /// <summary>
        /// Test for Getting Opinon with Valid Poll Model and Title
        /// </summary>
        [Test]
        public void GetOpinion_Valid_PollModel_Valid_OpinionTitle_Should_Return_OpinionItem()
        {
            // Arrange
            
            // Get Poll Model
            var getPollModel = TestHelper.PollService.GetPoll("Aerospace company");

            // Valid Title
            var opinionTitle = "Airbus";

            // Act
            
            // Fetch result 
            var getOpinionResult = TestHelper.PollService.GetOpinion(opinionTitle, getPollModel);

            // Reset

            // Assert

            // Check title Name are valid
            Assert.AreEqual(true, getOpinionResult.OpinionName.Equals(opinionTitle));
            // Check Votes for Opinion
            Assert.AreEqual(true, (getOpinionResult.NumCounts > -1));
        }

        /// <summary>
        /// Test for Getting Opinion with Invalid Poll Model and Valid Title
        /// </summary>
        [Test]
        public void GetOpinion_InValid_PollModel_Valid_OpinionTitle_Should_Return_Null()
        {
            // Arrange

            // Invalid Poll Model
            var pollModel = TestHelper.PollService.GetPoll("Invalid Name NUll");

            // Valid Title
            var opinionTitle = "Airbus";

            // Act

            // Fetch Result
            var getOpinionResult = TestHelper.PollService.GetOpinion(opinionTitle, pollModel);

            // Reset

            // Assert
            
            // Check result from Fetch
            Assert.AreEqual(null, getOpinionResult);
        }

        /// <summary>
        /// Test for Getting Opinion with Valid Poll Model and InValid Opinion Title
        /// </summary>
        [Test]
        public void GetOpinion_Valid_PollModel_InValid_OpinionTitle_Should_Return_Null()
        {
            // Arrange
            
            // Valid Poll Model
            var pollModel = TestHelper.PollService.GetPoll("Aerospace company");

            // Act

            // Fetch Result with null for Title
            var getOpinionResult = TestHelper.PollService.GetOpinion(null, pollModel);

            // Reset

            // Assert

            // Check result from Fetch
            Assert.AreEqual(null, getOpinionResult);
        }


        #endregion GetOpinion

        #region UpdateOpinionVote

        /// <summary>
        /// Test for Updating Opinion Vote with Valid Title and Invalid Poll ID
        /// </summary>
        [Test]
        public void UpdateOpinionVote_InValid_PollId_Valid_OpinionTitle_Should_Return_False()
        {
            // Assert
            
            // Invalid ID
            var pollID = -999;

            // Act

            // Fetch result
            var getResult = TestHelper.PollService.UpdateOpinionVote(pollID, "Airbus");

            // Reset

            // Assert

            // Validate And Check result from Fetch
            Assert.AreEqual(false, getResult);
        }

        /// <summary>
        /// Test for Updating Opinion Vote with Valid Poll ID and Invalid Title
        /// </summary>
        [Test]
        public void UpdateOpinionVote_Valid_PollId_InValid_OpinionTitle_Should_Return_False()
        {
            // Arrange

            // Valid Id
            var pollID = 1;

            // Invalid Title
            var opinionTitle = "93383828992";

            // Act

            // Fetch result
            var getResult = TestHelper.PollService.UpdateOpinionVote(pollID, opinionTitle);

            // Reset

            // Assert

            // Validate And Check result from Fetch
            Assert.AreEqual(false, getResult);
        }

        #endregion UpdateOpinionVote

        #region getTotalVotes

        /// <summary>
        /// Test for Invalid Poll Model Submission
        /// </summary>
        [Test]
        public void GetTotalVotes_InValid_PollModel_Should_Return_Zero()
        {
            // Arrange

            // Act

            // Fetch Result from Service
            var getResult = TestHelper.PollService.GetTotalVotes(null);

            // Reset

            // Assert

            // Check result should be zero ?
            Assert.AreEqual(0, getResult);
        }

        #endregion GetTotalVotes

        #region addOpinion
        /*
        [Test]
        public void AddOpinion_InValid_PollModel_Should_Return_Zero()
        {
            // Arrange
            int pollId = 9999;

            //Act
            var result = TestHelper.PollService.addOpinion(pollId, "","");

            //Rest

            //Assert

            //Check result is false
            Assert.AreEqual(false, result);

        }
        */
        #endregion addOpinion 
    }
}
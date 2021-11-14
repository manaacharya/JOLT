using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{   
    /// <summary>
    /// Tests all basic functions in PollModel.cs
    /// </summary>
    class PollModelTest
    {
        #region TestSetup
        /// <summary>
        /// Test Initialization
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        /// <summary>
        /// Creates a Poll and tests all the get() for its attribute
        /// </summary>
        [Test]
        #region Test
        public void Create_Valid_Poll_Should_Get_All_Public_Attributes()
        {
            // Arrange
           
            //create new opinion item 
            OpinionItem exampleOptionName =
                new OpinionItem("ExampleOpinionName", 2);

            //create new poll model with attributes 
            PollModel testPollModel = new PollModel()
            {
                //poll id 
                PollID = 1,

                //id of user creating 
                UserID = 11,

                //title of poll
                Title = "ExampleTitle",

                //description of poll 
                Description = "ExampleDescription",

                //opinion items are list of items 
                OpinionItems = new List<OpinionItem>() { exampleOptionName }
            };
            //Arrange

            //Act

            //Assert
            //check poll id has been created & correct id
            Assert.AreEqual(1, testPollModel.PollID);

            //check user id has been created & correct id 
            Assert.AreEqual(11, testPollModel.UserID);

            //check title is correct 
            Assert.AreEqual("ExampleTitle", testPollModel.Title);

            //check description is correct 
            Assert.AreEqual("ExampleDescription", testPollModel.Description);

            //check opinion item is not empty 
            Assert.AreEqual(true, testPollModel.OpinionItems.First().OpinionName.Equals(exampleOptionName.OpinionName));

            //check opinion has correct name 
            Assert.AreEqual(exampleOptionName.OpinionName, "ExampleOpinionName");

            //check there are 2 votes 
            Assert.AreEqual(exampleOptionName.NumCounts, 2);
        }
        #endregion Test

    }
}
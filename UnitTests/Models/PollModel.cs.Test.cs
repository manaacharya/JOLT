using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Models;
using System.Text.Json;

namespace UnitTests.Models
{   /// <summary>
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
            // ------------------------- Arrange -------------------------
            IEnumerable<OpinionItem> listOfItems = new List<OpinionItem>();
            OpinionItem exampleOptionName = new OpinionItem("ExampleOpinionName", 2);
            listOfItems.Append(exampleOptionName);
            PollModel testPollModel = new PollModel()
            {
                PollID = 1,
                UserID = 11,
                Title = "ExampleTitle",
                Description = "ExampleDescription",
                OpinionItems = listOfItems
            };
            // ----------------- Act -----------------
            // Reset

            // ----------------- Assert -----------------
            Assert.AreEqual(1, testPollModel.PollID);
            Assert.AreEqual(11, testPollModel.UserID);
            Assert.AreEqual("ExampleTitle", testPollModel.Title);
            Assert.AreEqual("ExampleDescription", testPollModel.Description);
            Assert.AreEqual(testPollModel.OpinionItems.FirstOrDefault().ToString().Equals(""), false);
            Assert.AreEqual(exampleOptionName.OpinionName, "ExampleOpinionName");
            Assert.AreEqual(exampleOptionName.NumCounts, 2);
        }
        #endregion Test

    }
}

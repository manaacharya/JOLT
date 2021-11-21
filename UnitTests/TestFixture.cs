using System;
using System.IO;
using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    /// Text fixture class 
    /// </summary>
    [SetUpFixture]
    class TestFixture
    {
        // Path to the Web Root
        public static string DataWebRootPath = "./wwwroot";

        // Path to the data folder for the content
        public static string DataContentRootPath = "./data/";

        /// <summary>
        /// This is run before any tests occur 
        /// </summary>
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            // Run this code once when the test harness starts up.

            // var DataWebPath = "../../../../src/bin/Debug/net5.0/wwwroot/data";
            var dataWebPath = "../../../../src/wwwroot/data";

            //directory 
            var dataUTDirectory = "wwwroot";

            //add forward slash to dataUTDirectory string
            var dataUTPath = dataUTDirectory + "/data";

            // Delete the Detination folder
            if (Directory.Exists(dataUTDirectory))
            {
                Directory.Delete(dataUTDirectory, true);
            }

            // Make the directory
            Directory.CreateDirectory(dataUTPath);

            // Copy over all data files
            var filePaths = Directory.GetFiles(dataWebPath);

            foreach (var filename in filePaths)
            {
                //filepath name
                string originalFilePathName = filename.ToString();

                //new path name 
                var newFilePathName = originalFilePathName.Replace(dataWebPath, dataUTPath);

                //copy file path name 
                File.Copy(originalFilePathName, newFilePathName);
            }
        }

        /// <summary>
        /// Run after any test empty 
        /// </summary>
        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
}
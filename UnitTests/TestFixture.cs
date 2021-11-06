using System;
using System.IO;
using NUnit.Framework;

namespace UnitTests
{
    [SetUpFixture]
    class TestFixture
    {
        // Path to the Web Root
        public static string DataWebRootPath = "./wwwroot";

        // Path to the data folder for the content
        public static string DataContentRootPath = "./data/";

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            // Run this code once when the test harness starts up.

            // This will copy over the latest version of the database files

            // C:\repos\5110\ClassBaseline\UnitTests\bin\Debug\net5.0\wwwroot\data
            // C:\repos\5110\ClassBaseline\src\wwwroot\data
            // C:\repos\5110\ClassBaseline\src\bin\Debug\net5.0\wwwroot\data



            // var DataWebPath = "../../../../src/bin/Debug/net5.0/wwwroot/data";
            var dataWebPath = "../../../../src/wwwroot/data";

            var dataUTDirectory = "wwwroot";

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
                string originalFilePathName = filename.ToString();

                var newFilePathName = originalFilePathName.Replace(dataWebPath, dataUTPath);

                File.Copy(originalFilePathName, newFilePathName);
            }
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
}

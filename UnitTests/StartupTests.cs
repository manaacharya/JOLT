using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using NUnit.Framework;

namespace UnitTests.Pages.Startup
{
    /// <summary>
    /// StartupTests class for StartUp
    /// </summary>
    public class StartupTests
    {
        #region TestSetup

        /// <summary>
        ///  Test Initialization for StartUp 
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        /// <summary>
        /// Startup Class Creation, with inheritance  from ContosoCrafts.WebSite.Startup
        /// </summary>
        public class Startup : ContosoCrafts.WebSite.Startup
        {
            /// <summary>
            /// Startup constructor with IConfiguration parameter
            /// </summary>
            /// <param name="config"></param>
            public Startup(IConfiguration config) : base(config) { }
        }
        #endregion TestSetup

        #region ConfigureServices
        
        /// <summary>
        /// Test for Service Configuration
        /// </summary>
        [Test]
        public void Startup_ConfigureServices_Valid_Defaut_Should_Pass()
        {
            // webHost variable 
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();

            // Assert
            Assert.IsNotNull(webHost);
        }
        #endregion ConfigureServices

        #region Configure
        /// <summary>
        /// Test for Valid Configure
        /// </summary>
        [Test]
        public void Startup_Configure_Valid_Defaut_Should_Pass()
        {
            // webHost variable 
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();

            //Assert
            Assert.IsNotNull(webHost);
        }

        #endregion Configure
    }
}
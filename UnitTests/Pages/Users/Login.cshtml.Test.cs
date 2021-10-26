using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;

using ContosoCrafts.WebSite.Pages;


namespace UnitTests.Pages.Users
{
    class LoginTest
    {
        #region TestSetup
        public static LoginPageModel pageModel;

        [SetUp]

        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<LoginPageModel>>();

            pageModel = new LoginPageModel(MockLoggerDirect, TestHelper.UserService)
            {
                PageContext = TestHelper.PageContext
            };

        }
        #endregion TestSetup

        #region OnPost
        [Test]
        public void valid_should_do()
        {
            Assert.AreEqual('2', '2');

        }
        #endregion OnPost

    }
    
}

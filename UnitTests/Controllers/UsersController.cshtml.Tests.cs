using NUnit.Framework;
using ContosoCrafts.WebSite.Controllers;
using System.Linq;

namespace UnitTests.Controllers.Users
{
    /// <summary>
    ///  UserControllerTest Class for User Controller
    /// </summary>
    class UserControllerTest
    { 

        #region TestSetup
        // UsersController static field/attribute
        public static UsersController usersController;
 
        /// <summary>
        /// Test Initialization for UsersController 
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        // Usercontroller instance created
        // with UserService passsed through constructor 
        usersController = new UsersController(TestHelper.UserService); 
        
        }

        #endregion TestSetup

        #region Get

        /// <summary>
        /// Test for OnGet() Collection of Users
        /// </summary>
        [Test]
        public void Get_Valid_Should_Return_Users()
        {
            //Arrange 

            //Act

            // Fetch result from OnGet()
            var Users = usersController.Get();
      
            //Assert

            //check model state 
            Assert.AreEqual(true, usersController.ModelState.IsValid);

            //check User object  
            Assert.AreEqual(true, usersController.Users.ToList().Any());
            }
        #endregion Get
    }
}
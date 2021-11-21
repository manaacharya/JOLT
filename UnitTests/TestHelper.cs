using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Moq;
using ContosoCrafts.WebSite.Services;

namespace UnitTests
{

    /// <summary>
    /// Helper to hold the web start settings
    /// </summary>
    public static class TestHelper
    {
        //mock webhost environment 
        public static Mock<IWebHostEnvironment> MockWebHostEnvironment;

        //url helper factory 
        public static IUrlHelperFactory UrlHelperFactory;

        //default http context
        public static DefaultHttpContext HttpContextDefault;

        //host environment 
        public static IWebHostEnvironment WebHostEnvironment;

        //model state 
        public static ModelStateDictionary ModelState;

        //action context
        public static ActionContext ActionContext;

        //empty model 
        public static EmptyModelMetadataProvider ModelMetadataProvider;

        //view data 
        public static ViewDataDictionary ViewData;

        //temporary dictionary 
        public static TempDataDictionary TempData;

        //page context 
        public static PageContext PageContext;

        //Product services
        public static JsonFileProductService ProductService;

        // User Services
        public static JsonFileUserService UserService;

        // Poll Services
        public static JsonFilePollService PollService;

        /// <summary>
        /// Default Constructor
        /// </summary>
        static TestHelper()
        {
            //webhost new 
            MockWebHostEnvironment = new Mock<IWebHostEnvironment>();

            //unit testing environment 
            MockWebHostEnvironment.Setup(m =>
            m.EnvironmentName).Returns("Hosting:UnitTestEnvironment");

            //webroot path 
            MockWebHostEnvironment.Setup(m =>
            m.WebRootPath).Returns(TestFixture.DataWebRootPath);

            //content root path 
            MockWebHostEnvironment.Setup(m =>
            m.ContentRootPath).Returns(TestFixture.DataContentRootPath);

            //create default http contect 
            HttpContextDefault = new DefaultHttpContext()
            {
                //trace identifier 
                TraceIdentifier = "trace",
            };

            //http context default
            HttpContextDefault.HttpContext.TraceIdentifier = "trace";

            //model state 
            ModelState = new ModelStateDictionary();

            //action context
            ActionContext = new ActionContext(HttpContextDefault, HttpContextDefault.GetRouteData(), new PageActionDescriptor(), ModelState);

            //model meta data 
            ModelMetadataProvider = new EmptyModelMetadataProvider();

            //view data
            ViewData = new ViewDataDictionary(ModelMetadataProvider, ModelState);

            //temporary data 
            TempData = new TempDataDictionary(HttpContextDefault, Mock.Of<ITempDataProvider>());

            //page context
            PageContext = new PageContext(ActionContext)
            {
                //view data
                ViewData = ViewData,

                //http context
                HttpContext = HttpContextDefault
            };

            //product serives
            ProductService = new JsonFileProductService(MockWebHostEnvironment.Object);

            //product services 
            JsonFileProductService productService;

            //product service Json
            productService = new JsonFileProductService(TestHelper.MockWebHostEnvironment.Object);

            // User Services
            UserService = new JsonFileUserService(MockWebHostEnvironment.Object);

            //new userservice
            JsonFileUserService userService;

            //user service
            userService = new JsonFileUserService(TestHelper.MockWebHostEnvironment.Object);

            // Poll Services
            PollService = new JsonFilePollService(MockWebHostEnvironment.Object);

            //poll service 
            JsonFilePollService pollService;

            //new poll service
            pollService = new JsonFilePollService(TestHelper.MockWebHostEnvironment.Object);
        }
    }
}
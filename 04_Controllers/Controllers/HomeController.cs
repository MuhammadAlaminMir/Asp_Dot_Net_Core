using Microsoft.AspNetCore.Mvc;

namespace _4_Controllers.Controllers
{
    // by inheriting from Controller, we get access to a lot of useful methods and properties that we can use in our action methods, such as View(), RedirectToAction(), and many more.
    public class HomeController : Controller
    {
        // This is the default route for the HomeController, it will be accessed when the user navigates to the root URL or /home

        // Routes are case insensitive, so both /home and /Home will work


        [Route("home")]
        [Route("/")]
        public string Index()
        {
            return "Hey I am Home / Index";
        }


        // ContentResult is a type of ActionResult that allows us to return plain text, HTML, or any other content type as the response. In this case, we are returning plain text with the content "Hey I am Services" and specifying the content type as "text/plain".
        [Route("Services")]
        public ContentResult Services()
        {
            return new ContentResult()
            {
                Content = "Hey I am Services",
                ContentType = "text/plain"
            };
        }

        // Because we have inherited from Controller, we can use the Content() method to return a ContentResult without having to create a new instance of it. This is a convenient way to return plain text or other content types from our action methods.
        [Route("contact")]
        public ContentResult Contact()
        {
            //
            return  Content( "Hey I am Services",  "text/plain" );
        }

        // this is called attribute routing, we are defining the route for this action method using the Route attribute
        [Route("about")]
       
        public string about()
        {
            return "Hey I am about";
        }
    }
}

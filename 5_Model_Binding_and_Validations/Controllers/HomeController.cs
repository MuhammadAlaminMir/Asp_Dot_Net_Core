using Microsoft.AspNetCore.Mvc;
using _5_Model_Binding_and_Validations.Models;

namespace _5_Model_Binding_and_Validations.Controllers
{
    public class HomeController : Controller
    {

        // /book/1?bookId=3 
        // in this case, the bookId in the route will take precedence over the bookId in the query string. So, if you access /book/1?bookId=3, the bookId parameter in the Index action method will be set to 1, not 3. This is because the routing system will match the route template "book/{bookId}" first and bind the value from the route to the bookId parameter before considering any query string parameters.
        [Route("books/{bookId?}/{hasLoggedIn?}")]
        // to give the bookId from the route more priority than the bookId from the query string, we can use the [FromRoute] attribute on the bookId parameter in the Index action method. This tells the model binder to bind the value of bookId from the route data instead of the query string. So, if you access /book/1?bookId=3, the bookId parameter in the Index action method will be set to 1, and the value from the query string will be ignored.
        public IActionResult Index( bool? hasLoggedIn,  int? bookId,  Book book)
        {
            // we can get the bookId from the query string using model binding. The int? type allows for null values, which means that if the bookId is not provided in the query string, it will be null. This is a more elegant way to handle optional parameters compared to manually checking the query string.

            // Book Id is Required
            //if (!this.ControllerContext.HttpContext.Request.Query.ContainsKey("bookId"))
            if (bookId.HasValue == false)
            {
                return BadRequest("Book id is required");
            }

            //int bookId = Convert.ToInt32(Request.Query["bookId"]);
            if (bookId <= 0)
            {
                return BadRequest("Book id must be greater than 0");
            }
            return Content($", Book: {book}");
        }
    }
}


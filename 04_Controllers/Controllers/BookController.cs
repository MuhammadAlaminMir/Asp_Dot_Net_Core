using Microsoft.AspNetCore.Mvc;

namespace _4_Controllers.Controllers
{
    public class BookController : Controller
    {
        [Route("book")]
        public IActionResult Index()
        {
            // Book Id is Required
            if (!this.ControllerContext.HttpContext.Request.Query.ContainsKey("bookid"))
            {
                //this.ControllerContext.HttpContext.Response.StatusCode = 400;
                //return Content("Book id is required");
                // return new BadRequestResult();
                return BadRequest("Book id is required"); // this is a helper method that returns a BadRequestResult (code 400) with the specified error message
            }

            if (String.IsNullOrEmpty(Convert.ToString((Request.Query["bookid"]))))
            {
                return BadRequest("Book id can't be null or empty");
    
            }

            int bookId = Convert.ToInt32(Request.Query["bookid"]);
            if(bookId <= 0)
            {
                return BadRequest("Book id must be greater than 0");
            }

            //return File("/Book.pdf", "application/pdf"); // this is a helper method that returns a FileResult with the specified file path and content type

            //return Content("hey i am book controller");

            // hare we are redirecting to another Action Method.
            // RedirectToActionResult is a type of ActionResult that allows us to redirect the user to another action method. In this case, we are redirecting to the Index action method of the ComicController. The new { } is an anonymous object that can be used to pass route values to the target action method, but in this case, we are not passing any route values.
            return new RedirectToActionResult("Index", "Comic", new { });
        }
    }
}

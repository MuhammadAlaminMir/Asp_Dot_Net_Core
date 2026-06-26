using Microsoft.AspNetCore.Mvc;

namespace _4_Controllers.Controllers
{
    [Route("books/comic")]
    public class ComicController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hey I am comic");
        }
    }
}

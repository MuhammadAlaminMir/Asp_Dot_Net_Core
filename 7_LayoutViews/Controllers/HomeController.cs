using _7_LayoutViews.Models;
using Microsoft.AspNetCore.Mvc;

namespace _7_LayoutViews.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {

            return View();
        }
        [Route("about-Company")]
        public IActionResult About()
        {
            return View();
        }
        [Route("contact-support")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("Programming-Languages")]
        public IActionResult ProgrammingLanguages()
        {

            ListModel listModel = new ListModel()
            {
                ListTitle = "Programming Languages",
                ListItems = new List<string>()
                {
                    "C#",
                    "Java",
                    "Python",
                    "JavaScript",
                    "C++"
                }
            };

            return PartialView("_ListPartialView", listModel);
        }
}
}

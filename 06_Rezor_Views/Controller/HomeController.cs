
using Microsoft.AspNetCore.Mvc;
using Razor_Views.Models;


namespace _6_Razor_Views
{
    public class HomeController : Controller
    {
        List<Person> peoples = new List<Person>
            {
                new Person { Name = "Alice", dateOfBirth = new DateTime(1995, 5, 15) },
                new Person { Name = "Bob", dateOfBirth = new DateTime(2000, 10, 20) },
                new Person { Name = "Charlie", dateOfBirth = new DateTime(1985, 3, 30) },
                new Person { Name = "David", dateOfBirth = new DateTime(2010, 7, 25) },
                new Person { Name = "Eve", dateOfBirth = new DateTime(1998, 12, 5) }
            };

        


        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
           return View(); // it searches for Views/Home/Index.cshtml
            //return View("abc"); // it searches for abc.cshtml
            //return new ViewResult() { ViewName = "home" };
        }

        [Route("practice")]
        public IActionResult Practice()
        {

            // to pass some value to view, we can use ViewBag, ViewData or TempData
            //ViewData["appTitle"] = "Asp dot net core";
            ViewData["peoples"] = peoples;

            return View();
        }
        [Route("page")]
        public IActionResult Page()
        {



            // ViewData is a dictionary object that we can use to pass data from controller to view, it is of type Dictionary<string, object>
            //ViewData["peoples"] = peoples;

            // if we use viewData we have to typecast it in the view, so we can use ViewBag instead of ViewData
            // instead we can use ViewBag which is dynamic type, so we don't have to typecast it in the view

            //ViewBag.peoples = peoples;

            // instead of using ViewData or ViewBag we can use strongly typed view, which is more efficient and less error prone, we can pass the model to the view and then we can use it in the view

            return View(peoples);
        }

        [Route("person-details/{name}")]
        public IActionResult PersonDetails(string name)
        {
            if(name == null)
            {
                return BadRequest("Person Name is required");
            }

            return View(peoples.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
        }

        [Route("person-with-product")]
        public IActionResult PersonWithProduct()
        {
            Person person = new Person
            {
                Name = "Alice",
                dateOfBirth = new DateTime(1995, 5, 15),
                PersonGender = Person.Gender.Male
            };
            Product product = new Product
            {
                ProductId = 1,
                ProductName = "Laptop",
                Price = 999.99m
            };

            PersonAndProductWrapper personAndProductWrapper = new PersonAndProductWrapper
            {
                Person = person,
                Product = product
            };
            return View(personAndProductWrapper);

        }
}
}

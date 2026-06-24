using Microsoft.AspNetCore.Mvc;
using ServicesContracts;

namespace _8_Dependency_Injection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesService _citiesService;


        // here we are receiving the IOC container object of ICitiesService, which is CitiesService object. 
        // This is called constructor injection
        public HomeController(ICitiesService citiesService)
        {
            
            _citiesService = citiesService;
        }

        [Route("/")]
        [Route("home")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService.GetCities();
            return View(cities);
        }

        // We can also inject the objection here which is called method injection
        //public IActionResult About([FromServices]ICitiesService citiesService)
        //{
        //    List<string> cities = _citiesService.GetCities();
        //    return View(cities);
        //}
    }
}

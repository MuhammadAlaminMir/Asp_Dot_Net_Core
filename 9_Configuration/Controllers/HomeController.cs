using _9_Configuration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace _9_Configuration.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherApiOptions _configuration;

        //public HomeController(IConfiguration configuration)
        public HomeController(IOptions<WeatherApiOptions> configuration)
        {
            _configuration = configuration.Value;
        }

        [Route("/")]
        public IActionResult Index()
        {
            //ViewBag.MyAPIKey = _configuration["MyAPIKey"];
            ViewBag.WeatherClientId = _configuration.ClientId;
            //ViewBag.MyKey = _configuration.GetValue<string>("MyKey", "or set a default key");
            //ViewBag.WeatherClientId = _configuration["WeatherApi:ClientId"];
            // this is another option to get complex in from configuration.
            //ViewBag.WeatherClientKey = _configuration.GetSection("weatherApi")["ClientSecret"];

            // also we can store it in a variable:
            //IConfigurationSection weatherApi = _configuration.GetSection("weatherApi");

            ViewBag.WeatherClientKey = _configuration.ClientSecret;

            // we can also bind the configuration section to a strongly typed object:
            //WeatherApiOptions weatherApiOptions = new WeatherApiOptions();
            //_configuration.GetSection("weatherApi").Bind(weatherApiOptions);

            // we can also set it as service in the Program.cs file and inject it into the controller:

            return View();
        }
    }
}

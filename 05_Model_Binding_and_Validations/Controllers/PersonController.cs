using Microsoft.AspNetCore.Mvc;
using _5_Model_Binding_and_Validations.Models;

namespace _5_Model_Binding_and_Validations.Controllers
{
    [Route("personRegister")]
    public class PersonController : Controller
    {
        // Bind Attribute helps to control which property should be bind with the actual model
        
        public IActionResult Index( [Bind("PersonName, Email", nameof(Person.Password), nameof(Person.ConfirmPassword))]Person person)
        {
            if(!ModelState.IsValid)
            {
                // using LinQ
                var errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors)
                    .Select(err => err.ErrorMessage).ToList());


                //List<string> errorsList = new();
                //foreach(var values in ModelState.Values)  
                //{
                //    foreach(var error in values.Errors)
                //    {
                //        errorsList.Add(error.ErrorMessage);
                //    }
                //}
                //string errors = string.Join("\n", errorsList);

                return BadRequest(errors);
            }
            return Content($"{person}");
        }
    }
}

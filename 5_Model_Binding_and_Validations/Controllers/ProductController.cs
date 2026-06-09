using _5_Model_Binding_and_Validations.CustomModelBinders;
using _5_Model_Binding_and_Validations.Models;
using Microsoft.AspNetCore.Mvc;

namespace _5_Model_Binding_and_Validations.Controllers
{
    [Route("Products")]
    public class ProductController : Controller
    {
        //
        public IActionResult Index([ModelBinder(BinderType = typeof(ProductModelBinder))] Product product)
        {
            if (!ModelState.IsValid)
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

            //var result = ControllerContext.HttpContext.Request.Headers["key"];


            return Content($"{product}");

        }
    }
}

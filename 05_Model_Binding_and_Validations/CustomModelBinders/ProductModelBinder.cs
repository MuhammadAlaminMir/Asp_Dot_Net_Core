using _5_Model_Binding_and_Validations.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace _5_Model_Binding_and_Validations.CustomModelBinders
{
    public class ProductModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Product product = new();
            // Creating Owner full name using First and Last name
            if(bindingContext.ValueProvider.GetValue("OwnerFirstName").Length > 0)
            {
                product.OwnerName = bindingContext.ValueProvider.GetValue("OwnerFirstName").FirstValue;
            }
            if (bindingContext.ValueProvider.GetValue("OwnerLastName").Length > 0)
            {
                product.OwnerName += " "+ bindingContext.ValueProvider.GetValue("OwnerLastName").FirstValue;
            }
            if (bindingContext.ValueProvider.GetValue("Price").Length > 0)
            {
                product.Price = Convert.ToDecimal( bindingContext.ValueProvider.GetValue("Price").FirstValue);
            }

            if (bindingContext.ValueProvider.GetValue("Title").Length > 0)
            {
                product.Title = bindingContext.ValueProvider.GetValue("Title").FirstValue;
            }

            bindingContext.Result = ModelBindingResult.Success(product);

            return Task.CompletedTask;
        }
    }
}

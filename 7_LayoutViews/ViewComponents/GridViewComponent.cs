using Microsoft.AspNetCore.Mvc;

namespace _7_LayoutViews.ViewComponents
{
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(); // This will look for a view named "Default.cshtml" in the Views/Shared/Components/Grid folder
            //return View("test"); // if you change the name from default to any other name you have pass it as an argument
        }
    }
}

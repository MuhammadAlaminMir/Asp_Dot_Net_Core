namespace _3_Routing.Practice_Files
{
    public static class Route_Perameters
    {
        // so we are using route perameter hare. to recive the request. 
        public static async void RunRoutePerametersCodes(HttpContext context)
        {

            string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
            await context.Response.WriteAsync($"In Employee profile - {employeeName}");

        }
    }
}

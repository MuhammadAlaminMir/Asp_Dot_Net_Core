namespace _2_Middleware.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project

    // conventional middleware is a middleware that is implemented as a class with an Invoke or InvokeAsync method. This type of middleware is typically used for simple scenarios where you want to perform some logic before or after the next middleware in the pipeline. In this example, we have a conventional middleware called MyConventionalMiddleware, which is added to the pipeline using app.MyConventionalMiddleware(). This middleware will be executed in the order it is added, so it will be executed after the first middleware and before the third middleware.
    public class MyConventionalMiddleware
    {
        private readonly RequestDelegate _next;

        // here we get the next middleware in the pipeline as a parameter in the constructor. This allows us to call the next middleware after we have performed our logic in the current middleware. The next middleware is represented by the RequestDelegate type, which is a delegate that takes an HttpContext and returns a Task. This allows us to call the next middleware asynchronously, which is important for performance and scalability.
        public MyConventionalMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Query.ContainsKey("firstname") && httpContext.Request.Query.ContainsKey("lastname"))
            {
                string fullName = httpContext.Request.Query["firstname"] + " " + httpContext.Request.Query["lastname"];
                await httpContext.Response.WriteAsync(fullName);
            }
            await _next(httpContext);
            //after logic
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HelloCustomModdleExtensions
    {
        public static IApplicationBuilder MyConventionalMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyConventionalMiddleware>();
        }
    }
}
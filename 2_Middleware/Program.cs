using _2_Middleware.CustomMiddleware;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

// Middlewares are executed in the order they are added to the pipeline. So, the order of middleware is important. The first middleware added will be the first one to process the request and the last one to process the response.
// The middleware pipeline is a series of components that are invoked in a specific order to handle HTTP requests and responses. Each middleware component can perform operations on the request, response, or both, and then pass control to the next middleware in the pipeline. The order of middleware is crucial because it determines how requests are processed and how responses are generated.

// Use method is used to add a middleware to the pipeline. It takes a delegate that represents the middleware logic. The delegate receives an HttpContext object and a RequestDelegate that represents the next middleware in the pipeline. The middleware can perform operations on the HttpContext, such as modifying the request or response, and then call the next middleware using the RequestDelegate.
//middlware 1
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("From Midleware 1\n");
    await next(context);
});



//middleware 2

// You can add custom middleware to the pipeline using the UseMiddleware extension method. This allows you to create reusable middleware components that can be easily added to the pipeline. In this example, we have a custom middleware called MyCustomMiddleware, which is added to the pipeline using app.UseMiddleware<MyCustomMiddleware>(). This middleware will be executed in the order it is added, so it will be executed after the first middleware and before the third middleware.
//app.UseMiddleware<MyCustomMiddleware>();
app.UseMyCustomMiddleware();

// conventional middleware is a middleware that is implemented as a class with an Invoke or InvokeAsync method. This type of middleware is typically used for simple scenarios where you want to perform some logic before or after the next middleware in the pipeline. In this example, we have a conventional middleware called MyConventionalMiddleware, which is added to the pipeline using app.MyConventionalMiddleware(). This middleware will be executed in the order it is added, so it will be executed after the first middleware and before the third middleware.
app.MyConventionalMiddleware();

// useWhen method is used to conditionally add middleware to the pipeline based on a predicate. The predicate is a function that takes an HttpContext and returns a boolean value. If the predicate returns true, the middleware in the branch will be executed; otherwise, it will be skipped. In this example, we are using useWhen to add a middleware branch that will only be executed if the request query contains a "username" parameter. If the condition is met, the middleware in the branch will write "Hello from Middleware branch" to the response before calling the next middleware in the branch.
app.UseWhen(
    context => context.Request.Query.ContainsKey("username"),
    app => {
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Hello from Middleware branch");
            await next();
        });
    });

//middleware 3
app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("From Middleware 3\n");
});


// the last middleware in the pipeline is typically a terminal middleware, which means it does not call the next middleware and is responsible for generating the final response. In this example, the last middleware is the one added with app.Run(), which writes "From Middleware 3\n" to the response. This middleware will be executed after all the previous middlewares have processed the request and passed control to it.
app.Run();
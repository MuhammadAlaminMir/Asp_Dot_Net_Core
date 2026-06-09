var builder = WebApplication.CreateBuilder(args);

// we have to add controllers to the service collection in order for them to be discovered and used by the application
// like: builder.Services.AddTransient<Controllers.HomeController>();


// but instead of adding each controller separately, we can use the AddControllers() method to add all controllers in the assembly
builder.Services.AddControllers();

var app = builder.Build();

// we also have to tell the application to use controllers, otherwise it won't know how to route requests to them.
// like: app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

// but instead of mapping each controller separately, we can use the MapControllers() method to map all controllers in the assembly
app.MapControllers();

app.Run();

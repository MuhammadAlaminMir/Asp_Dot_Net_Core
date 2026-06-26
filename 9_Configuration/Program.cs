using _9_Configuration.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// this is how we can bind the configuration section to a strongly typed object and register it as a service in the DI container.
builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection("WeatherApi"));

// loading my custom configuration file (myconfig.json) into the configuration system
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("MyOwnConfig.json", optional: true, reloadOnChange: true);
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

// this example shows how to access configuration values of appsettings.json from program.cs file.
//app.UseEndpoints(endpoints =>
//{
//    _ = endpoints.Map("/config", async context =>
//    {
//        // This way we can access the configuration values from appsettings.json or other configuration sources
//        await context.Response.WriteAsync(app.Configuration["myKey"] + "\n");

//        // this is another way to access the configuration values using GetValue<T> method
//        await context.Response.WriteAsync(app.Configuration.GetValue<string>("myKey", "Default Value") + "\n");

//    });

//});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);




app.Run();

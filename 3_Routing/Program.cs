// routing is a process of matching the incoming request to the defined endpoints. It is case sensitive by default, which means that the URL must match the defined route exactly in terms of letter casing. For example, if you have an endpoint defined as "map1", a request to "MAP1" or "Map1" would not match and would result in a 404 Not Found response. To make routing case insensitive, you can set the following property in Program.cs:
using _3_Routing.Practice_Files;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Routing is automatically enabled.
//No need for app.UseRouting() anymore

//creating endpoints
//endpoints are defiend directly on the app object
// mapget method is used to define a GET endpoint. It takes the route pattern as the first parameter and a delegate that handles the request as the second parameter. In this example, we have defined a GET endpoint with the route pattern "Home". When a request is made to this endpoint, the response will be "In Home".
app.MapGet("Home", async (context) => {
    await context.Response.WriteAsync("In Home");
});

// all the methods starting with map are called mapstar method.
// mappost method is used to define a POST endpoint. It takes the route pattern as the first parameter and a delegate that handles the request as the second parameter. In this example, we have defined a POST endpoint with the route pattern "map2". When a request is made to this endpoint using the POST method, the response will be "In Map 2".
app.MapPost("map2", async (context) => {
    await context.Response.WriteAsync("In Map 2");
});


//Routing is case sensitive by default. To make it case insensitive, set the following property in Program.cs
// builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

// Eg: files/sample.txt
// In the above example, we have defined a route pattern "files/{filename}.{extension}". The {filename} and {extension} are route parameters that can capture the values from the URL. When a request is made to this endpoint, the values of filename and extension will be extracted from the URL and can be used in the response. For example, if a request is made to "files/sample.txt", the response will be "In files - sample - txt".
app.Map("files/{filename}.{extension}", async context =>
{
    string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

    await context.Response.WriteAsync($"In files - {fileName} - {extension}");
});

//map method can be used for both get and post requests. It will match the request method with the method defined in the route pattern. For example, if we have defined a route pattern "employee/profile/{EmployeeName}" using the Map method, it will match both GET and POST requests to that endpoint. So, if a request is made to "employee/profile/john" using either GET or POST method, the response will be "In Employee profile - john".
//Eg: employee/profile/john
//app.Map("employee/profile/{EmployeeName}", async context =>
//{
//    string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
//    await context.Response.WriteAsync($"In Employee profile - {employeeName}");
//});



// Practicing another Features of Routing 

// Route Parameters 
app.Map("employee/profile/{EmployeeName}", async context =>
{
Route_Perameters.RunRoutePerametersCodes(context);
   
});


// Optional Parameter / null able parameter 
// we can take null as an parameter route 
app.Map("product/details/{id?}", async context => {

    if (context.Request.RouteValues.ContainsKey("id"))
    {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"Product ID :- {id}");
    }
    else
    {
        await context.Response.WriteAsync($"Product ID :- id is not supplied ");
    }
});



// we can also set some constraint on the route parameters. for example we can set a constraint that the id should be an integer. if the request does not match the constraint, it will not be matched to that route endpoint rather it will go to the fallback route or will result in a 404 Not Found response.

app.Map("cities/{cityid:guid}", async (context) => 
{

    Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);

    await context.Response.WriteAsync($"City ID :- {cityId}");
});


// we can set also the length and type of the route parameters. for example we can set a constraint that the username should be a string and should have a minimum length of 5 characters. if the request does not match the constraint, it will not be matched to that route endpoint rather it will go to the fallback route or will result in a 404 Not Found response.
app.Map("users/{username:minlength(5):maxlength(12):alpha:string}", async (context) =>
{
    string username = Convert.ToString(context.Request.RouteValues["username"])!;
    await context.Response.WriteAsync($"Username :- {username}");
});

//Fallback for any other requests. when no path/route will match the request this one will be executed. 
app.MapFallback(async context => {
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();
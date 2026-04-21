var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Routing is automatically enabled.
//No need for app.UseRouting() anymore

//creating endpoints
app.MapGet("map1", async (context) => {
    await context.Response.WriteAsync("In Map 1");
});

app.MapPost("map2", async (context) => {
    await context.Response.WriteAsync("In Map 2");
});

//Routing is automatically enabled.
//No need for app.UseRouting() anymore
//Routing is case sensitive by default. To make it case insensitive, set the following property in Program.cs
// routing is a process of matching the incoming request to the defined endpoints. It is case sensitive by default, which means that the URL must match the defined route exactly in terms of letter casing. For example, if you have an endpoint defined as "map1", a request to "MAP1" or "Map1" would not match and would result in a 404 Not Found response. To make routing case insensitive, you can set the following property in Program.cs:

// Eg: files/sample.txt
// In the above example, we have defined a route pattern "files/{filename}.{extension}". The {filename} and {extension} are route parameters that can capture the values from the URL. When a request is made to this endpoint, the values of filename and extension will be extracted from the URL and can be used in the response. For example, if a request is made to "files/sample.txt", the response will be "In files - sample - txt".
app.Map("files/{filename}.{extension}", async context =>
{
    string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

    await context.Response.WriteAsync($"In files - {fileName} - {extension}");
});


//Eg: employee/profile/john
app.Map("employee/profile/{EmployeeName}", async context =>
{
    string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
    await context.Response.WriteAsync($"In Employee profile - {employeeName}");
});


//Fallback for any other requests
app.MapFallback(async context => {
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();
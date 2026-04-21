var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.Run(async (HttpContext context) =>
{

    context.Response.Headers["Content-type"] = "text/html";
    if (context.Request.Headers.ContainsKey("User-Agent"))
    {
        string userAgent = context.Request.Headers["User-Agent"];
        await context.Response.WriteAsync($"<p>{userAgent}</p>");
    }

    // You can also access other request information, such as the path, query parameters, etc.
    string path = context.Request.Path;
    string method = context.Request.Method;

    // Set the response content type to HTML and write the path and method to the response
    context.Response.Headers["Content-type"] = "text/html";
    // Write the path and method to the response
    await context.Response.WriteAsync($"<p>{path}</p>");
    await context.Response.WriteAsync($"<p>{method}</p>");

    // You can also check for custom headers, such as an "AuthorizationKey" header
    if (context.Request.Headers.ContainsKey("AuthorizationKey"))
    {
        string auth = context.Request.Headers["AuthorizationKey"];
        await context.Response.WriteAsync($"<p>{auth}</p>");
    }

    // To read the body of the request, you can use a StreamReader to read the request body as a string, this way you can access the body content and parse it as needed. For example, if the body contains form data, you can parse it using the QueryHelpers.ParseQuery method to extract key-value pairs from the body.
    StreamReader reader = new StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

    if (queryDict.ContainsKey("firstName"))
    {
        string firstName = queryDict["firstName"][0];
        await context.Response.WriteAsync(firstName);
    }
});

app.Run();

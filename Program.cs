var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) => 
{
    await next(); 
    await context.Response.
    WriteAsync($"\nStatus Code: {context.Response.StatusCode}"
        ); 
});
// Define a middleware function that takes in an HTTP context and a next function
app.Use(async (context, next) =>
{
    // Check if the request method is GET and if the "custom" query parameter is set to "true"
    if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
    {
        // Set the content type of the response to "text/plain"
        context.Response.ContentType = "text/plain";

        // Write a message to the response body
        await context.Response.WriteAsync("Custom Middleware \n");
    }

    // Call the next middleware in the pipeline
    await next();
}
);

app.UseMiddleware<Platform.QueryStringMiddleWare>();

app.MapGet("/", () => "Hello World!");

app.Run();

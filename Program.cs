using Platform;
using Platform.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>();

var app = builder.Build(); 

app.UseMiddleware<WeatherMiddleware>();

app.MapGet("middleware/function", async (HttpContext context, IResponseFormatter formatter) 
    => { await formatter.Format(context, "Middleware Function: It is snowing in Chicago");}); 

app.MapGet("endpoint/class", WeatherEndpoint.Endpoint); 

app.MapGet("endpoint/function", async (HttpContext context, IResponseFormatter formatter) 
    => { await formatter.Format(context, "Endpoint Function: It is sunny in LA");});

app.MapGet("test", async (HttpContext context) => {
    await context.Response.WriteAsync("Hello from the test route!");
});

app.Run();
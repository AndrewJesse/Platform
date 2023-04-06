using Platform.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ITimeStamper, DefaultTimeStamper>();
var app = builder.Build();
app.MapGet("/",
    async context => { await context.Response.WriteAsync("Hello World!"); });

app.MapGet("config", async (HttpContext context, IConfiguration config) =>
{
    string defaultDebug = config["Logging:LogLevel:Default"];
    await context.Response.WriteAsync($"The config setting is: {defaultDebug}");
});
app.Run();
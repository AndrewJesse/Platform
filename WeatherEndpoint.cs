using Platform.Services;

namespace Platform
{
    public class WeatherEndpoint
    {
        private RequestDelegate next;
        //private IResponseFormatter formatter;
        public WeatherEndpoint(RequestDelegate nextDelegate, IResponseFormatter respFormatter)
        {
           next = nextDelegate;
            //formatter = responseFormatter;
        }
        public async Task Invoke(HttpContext context, IResponseFormatter formatter) 
        {
            if (context.Request.Path == "/middleware/class") 
            {
                await formatter.Format(context, "Middleware Class: It is raining in London"); 
            }
            else 
            {
                await next(context); 
            }
        }
    }
}

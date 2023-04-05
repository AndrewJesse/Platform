using Platform.Services;

namespace Platform
{
    public class WeatherEndpoint
    {
        //private IResponseFormatter formatter;
        //public WeatherEndpoint(RequestDelegate nextDelegate, IResponseFormatter respFormatter)
        //{
        //    formatter = responseFormatter;
        //}
        public async Task Invoke(HttpContext context, IResponseFormatter formatter) 
        {

                await formatter.Format(context, "Middleware Class: It is raining in London"); 
         }
    }
}

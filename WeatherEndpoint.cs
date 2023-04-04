using Platform.Services;

namespace Platform
{
    public class WeatherEndpoint
    {
        private IResponseFormatter formatter;
        public WeatherEndpoint(IResponseFormatter responseFormatter)
        {
            formatter = responseFormatter;
        }
        public static async Task Endpoint(HttpContext context, IResponseFormatter formatter) 
        {
            await formatter.Format(context, "Endpoint Class: It is cloudy in Milan"); 
        }
    }
}

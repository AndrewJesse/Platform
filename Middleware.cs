// Define a new namespace called "Platform"
namespace Platform
{
    // Define a public class called "QueryStringMiddleWare"
    public class QueryStringMiddleWare
    {
        // Declare a private field of type RequestDelegate named "next"
        private RequestDelegate next;

        // Declare a public constructor that takes a RequestDelegate parameter called "nextDelegate"
        public QueryStringMiddleWare(RequestDelegate nextDelegate)
        {
            // Assign the incoming "nextDelegate" parameter to the private "next" field
            next = nextDelegate;
        }

        // Declare a public asynchronous method called "Invoke" that takes an HttpContext parameter named "context" and returns a Task
        public async Task Invoke(HttpContext context)
        {
            // Check if the request method is GET and if the "custom" query parameter is set to "true"
            if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
            {
                // Check if the response has not started yet
                if (!context.Response.HasStarted)
                {
                    // Set the content type of the response to "text/plain"
                    context.Response.ContentType = "text/plain";
                }

                // Write a message to the response body
                await context.Response.WriteAsync("Class-based Middleware \n");
            }

            // Call the next middleware in the pipeline using the "next" field and passing the "context" parameter
            await next(context);
        }
    }
}


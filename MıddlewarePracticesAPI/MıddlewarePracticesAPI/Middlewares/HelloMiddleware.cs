namespace MıddlewarePracticesAPI.Middlewares
{
    public class HelloMiddleware
    {

        private readonly RequestDelegate _next;
        public HelloMiddleware(RequestDelegate next) { 
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("Hello World");
            await _next.Invoke(context); //bir sonrakinin invoke ini çağırdım.
            Console.WriteLine("Bye World");
        }

    }

    //Bir tane app builder alan extension yazman gerek
    static class HellaMiddleWareExtension
    {
        public static IApplicationBuilder UseHello(this IApplicationBuilder builder) 
        { 
            return builder.UseMiddleware<HelloMiddleware>();
        }
    }
}

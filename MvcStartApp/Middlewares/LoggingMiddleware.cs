using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context, IRequestRepository repoRequest)
        {
            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

            var request = new Request()
            {
                Date = DateTime.Now,
                Url = $"{context.Request.Host.Value + context.Request.Path}"
            };
            await repoRequest.AddRequest(request);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}

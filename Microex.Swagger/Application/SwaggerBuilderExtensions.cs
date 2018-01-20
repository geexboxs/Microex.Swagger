using System;
using Microex.Swagger.SwaggerUI;
using Microsoft.AspNetCore.Builder;

namespace Microex.Swagger.Application
{
    public static class SwaggerBuilderExtensions
    {
        public static IApplicationBuilder UseSwagger(
            this IApplicationBuilder app,
            Action<SwaggerOptions> setupAction = null)
        {
            var options = new SwaggerOptions();
            setupAction?.Invoke(options);

            app.UseMiddleware<SwaggerMiddleware>(options);

            return app;
        }
    }
}
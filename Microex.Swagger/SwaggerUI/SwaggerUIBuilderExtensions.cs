using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

namespace Microex.Swagger.SwaggerUI
{
    internal static class SwaggerUIBuilderExtensions
    {
        private const string EmbeddedFilesNamespace = "Microex.Swagger.SwaggerUI";

        internal static IApplicationBuilder UseSwaggerUI3(
            this IApplicationBuilder app,
            Action<SwaggerUIOptions> setupAction)
        {
            var options = new SwaggerUIOptions();
            setupAction?.Invoke(options);

            app.UseMiddleware<SwaggerUIIndexMiddleware>(options);
            app.UseFileServer(new FileServerOptions
            {
                RequestPath = $"/{options.RoutePrefix}",
                FileProvider = new EmbeddedFileProvider(typeof(SwaggerUIBuilderExtensions).GetTypeInfo().Assembly, EmbeddedFilesNamespace),
                EnableDirectoryBrowsing = true // will redirect to /{options.RoutePrefix}/ when trailing slash is missing
            });

            return app;
        }
    }
}

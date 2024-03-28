using LibraryUtil.DTO.ResponseDTO;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Library.IOC
{
    internal static  class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(
    options =>
    {
        options.Run(
            async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                var ex = context.Features.Get<IExceptionHandlerFeature>();
                if (ex != null)
                {
                    await context.Response.WriteAsJsonAsync(new ResultResponseDTO
                    {
                        StatusCode = (HttpStatusCode)context.Response.StatusCode,
                        Message = ex.Error.Message

                    });
                }
            });
    });
        }
    }
}

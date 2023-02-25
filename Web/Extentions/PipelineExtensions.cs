using FacePlusPlus.Web.Middleware;
using Microsoft.AspNetCore.Builder;

namespace FacePlusPlus.Web.Extentions
{
    public static class PipelineExtensions
    {
        public static void UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }

        public static void UseExceptionFormatting(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionFormattingMiddleware>();
        }
    }
}
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FacePlusPlus.Web.Contracts.Response;
using FacePlusPlus.Web.Extentions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FacePlusPlus.Web.Middleware
{
    public class ExceptionFormattingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger _logger;


        public ExceptionFormattingMiddleware(RequestDelegate next, IWebHostEnvironment env,
            ILoggerFactory loggerFactory)
        {
            _next = next;
            _env = env;
            _logger = loggerFactory
                .CreateLogger<ExceptionFormattingMiddleware>();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleException(httpContext, ex, _env);
            }
        }

        private Task HandleException(HttpContext context, Exception exception, IWebHostEnvironment env)
        {
            var code = HttpStatusCode.InternalServerError;
            var error = _env.IsDevelopment() ? exception.Message : DummyMessage();

            _logger.LogError(exception,message:
                "Http Request Exception Information: {Environment} Schema:{Schema} Host: {Host} Path: {Path} QueryString: {QueryString} Error Message: {ErrorMessage} Error Trace: {StackTrace}",
                Environment.NewLine, context.Request.Scheme, context.Request.Host, context.Request.Path,
                context.Request.QueryString, exception.Message, exception.StackTrace);


            switch (exception)
            {
                case InvalidCredentialsProvidedException invalidCredentialsProvidedException:
                    code = HttpStatusCode.BadRequest;
                    error = invalidCredentialsProvidedException.Message;

                    break;
                case ExistingPasswordNotAllowedException existingPasswordNotAllowedException:
                    code = HttpStatusCode.BadRequest;
                    error = existingPasswordNotAllowedException.Message;

                    break;

                case UserIdentityConfirmationUnavailableException userIdentityConfirmationUnavailableException:
                    code = HttpStatusCode.UnprocessableEntity;
                    error = userIdentityConfirmationUnavailableException.Message;
                    break;
                case SignInDeniedUserLockedException userLockedException:
                    code = HttpStatusCode.Locked;
                    error = userLockedException.Message;
                    break;
                case AccessRequestedFromUnknownDeviceException unknownDeviceException:
                    code = HttpStatusCode.UpgradeRequired;
                    error = unknownDeviceException.Message;
                    break;
                case DeviceAccessExpiredException deviceAccessExpiredException:
                    code = HttpStatusCode.UnavailableForLegalReasons;
                    error = deviceAccessExpiredException.Message;
                    break;
               

                    break;
                case SignInNotAllowedException signInNotAllowedException:
                    code = HttpStatusCode.UnavailableForLegalReasons;
                    error = signInNotAllowedException.Message;

                    break;
                case RequestedToAccessProtectedResourceWithoutSignInException accessProtectedResourceWithoutSign:
                    code = HttpStatusCode.Unauthorized;
                    error = accessProtectedResourceWithoutSign.Message;

                    break;
                case RegistrationFailedException registrationFailedException:
                    code = HttpStatusCode.UnprocessableEntity;
                    error = registrationFailedException.Details.Select(x => $"{x.Code}, {x.Description}")
                        .FirstOrDefault();
                    break;
                case CredentialAlreadyTakenException alreadyExistsException:
                    code = HttpStatusCode.UnprocessableEntity;
                    error = alreadyExistsException.Message;

                    break;

                case UserNotFoundException userNotFoundException:
                    code = HttpStatusCode.UnprocessableEntity;
                    error = userNotFoundException.Message;

                    break;
            }

            var envelope = Envelope.Error(error);
            var result = JsonConvert.SerializeObject(envelope, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;
            return context.Response.WriteAsync(result);
        }

        private static string DummyMessage()
        {
            return "Something wrong on our side, Please try again";
        }
    }
}
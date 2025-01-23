using Microsoft.Extensions.Logging;
using System.Net;

namespace RecuperApp.Common.Exceptions
{
    public class NotAuthorizedException : ApplicationException
    {
        public new const string GENERIC_EXCEPTION_MESSAGE = "The application has thrown a NotAuthorizedException, please check if you have access to the requested resource and try again.";

        public NotAuthorizedException() : base(GENERIC_EXCEPTION_MESSAGE, true, HttpStatusCode.Unauthorized, null, true, LogLevel.Warning, false) { }

        public NotAuthorizedException(string message,
            Exception innerException = null,
            bool logException = true,
            LogLevel logLevel = LogLevel.Warning,
            bool alreadyLoggedException = false) : base(message, true, HttpStatusCode.Unauthorized, innerException, logException, logLevel, alreadyLoggedException)
        {

        }
    }
}

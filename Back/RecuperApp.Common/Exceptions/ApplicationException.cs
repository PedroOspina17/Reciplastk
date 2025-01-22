using System.Net;
using Microsoft.Extensions.Logging;
using RecuperApp.Common.Extensions;

namespace RecuperApp.Common.Exceptions
{
    public class ApplicationException : Exception
    {
        public const string GENERIC_EXCEPTION_MESSAGE = "The application has thrown an exception.";
        public bool IsUIException { get; set; } = false;
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
        public bool LogException { get; set; } = true;
        public bool AlreadyLoggedException { get; set; } = false;
        public LogLevel LogLevel { get; set; }


        public ApplicationException(string message,
            bool isUIException = false,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            Exception innerException = null,
            bool logException = true,
            LogLevel logLevel = LogLevel.Debug,
            bool alreadyLoggedException = false) : base(message, innerException)
        {
            IsUIException = isUIException;
            StatusCode = statusCode;
            LogException = logException;
            LogLevel = logLevel;
            AlreadyLoggedException = alreadyLoggedException;
            var appException = innerException as ApplicationException;
            if (appException != null && appException.AlreadyLoggedException)
            {
                AlreadyLoggedException = true;
            }
            LogCurrentException();
        }
        private void LogCurrentException()
        {
            if (LogException && !AlreadyLoggedException)
            {
                StaticLogger.logger.Log(LogLevel,this ," The application has trown a custom exception");
                this.AlreadyLoggedException = true;
            }
        }
    }
}

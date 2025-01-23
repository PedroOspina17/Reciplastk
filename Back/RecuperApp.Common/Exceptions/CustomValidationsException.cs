using System.Net;
using Microsoft.Extensions.Logging;

namespace RecuperApp.Common.Exceptions
{
    public class CustomValidationsException : ApplicationException
    {
        public new const string GENERIC_EXCEPTION_MESSAGE = "The application has thrown a CustomValidationsException, please check the data sent and try again.";

        public CustomValidationsException() : base(GENERIC_EXCEPTION_MESSAGE, true, HttpStatusCode.BadRequest, null, true, LogLevel.Information, false) { }

        public CustomValidationsException(string message,
            Exception innerException = null,
            bool logException = true,
            LogLevel logLevel = LogLevel.Information,
            bool alreadyLoggedException = false) : base(message, true, HttpStatusCode.BadRequest, innerException, logException, logLevel, alreadyLoggedException)
        {

        }

    }
}

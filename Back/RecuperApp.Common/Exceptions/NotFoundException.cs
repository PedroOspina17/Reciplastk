using System.Net;
using Microsoft.Extensions.Logging;

namespace RecuperApp.Common.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public new const string GENERIC_EXCEPTION_MESSAGE = "The application has thrown a NotFoundExeption, please check the data sent and try again.";

        public NotFoundException() : base(GENERIC_EXCEPTION_MESSAGE, true, HttpStatusCode.NotFound, null, true, LogLevel.Information, false) { }

        public NotFoundException(string message,
            Exception innerException = null,
            bool logException = true,
            LogLevel logLevel = LogLevel.Debug,
            bool alreadyLoggedException = false) : base(message, true, HttpStatusCode.NotFound, innerException, logException, logLevel, alreadyLoggedException)
        {

        }
    }
}

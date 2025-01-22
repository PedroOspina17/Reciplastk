using RecuperApp.Common.Models;

namespace RecuperApp.Common.Extensions
{
    public static class HttpResonseHelpersExtensions
    {
        public static HttpResponseModel ToHttpResponse<T>(this T response)
        {
            return new HttpResponseModel { Data = response };
        }
        public static HttpResponseModel ToHttpResponse<T>(this T response, string message)
        {
            return new HttpResponseModel { Data = response, StatusMessage = message };
        }
        public static HttpResponseModel ToHttpResponse<T>(this T response, bool wasSuccessful, string message)
        {
            return new HttpResponseModel { Data = response, WasSuccessful = wasSuccessful, StatusMessage = message };
        }
    }
}

namespace RecuperApp.Common.Models
{
    public class HttpResponseModel
    {
        public HttpResponseModel(string message = ""): this(null,message,true,200)
        {
        }

        public HttpResponseModel(object data, string message = "", bool wasSuccessful = true, int? statusCode = null)
        {
            this.Data = data;
            this.StatusMessage = message;
            this.WasSuccessful = WasSuccessful;
            this.StatusCode = statusCode;
            if (statusCode == null)
                this.StatusCode = wasSuccessful ? 200 : 400;
        }
        public object Data { get; set; }
        public string StatusMessage { get; set; }
        public bool WasSuccessful { get; set; } = true;
        public int? StatusCode { get; set; }
        public T getData<T>()
        {
            return (T)Data;
        }
    }
}

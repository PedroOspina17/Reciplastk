namespace Reciplastk.Gateway.Models
{
    public class HttpResponseModel
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public bool WasSuccessful { get; set; }
        public object Data { get; set; }
    }
}

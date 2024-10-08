namespace Reciplastk.Gateway.Models
{
    public class HttpResponseModel
    {
        public int StatusCode
        {
            get { return WasSuccessful ? 200 : 400; }
            set { StatusCode = value; }
        }
        public string StatusMessage { get; set; }
        public bool WasSuccessful { get; set; }
        public object Data { get; set; }
    }
}

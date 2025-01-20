namespace Reciplastk.Common.Models
{
    public class HttpResponseModel
    {
        public int StatusCode
        {
            get { return WasSuccessful ? 200 : 400; } 
            set { StatusCode = value; }
        }
        public string StatusMessage { get; set; }
        public bool WasSuccessful { get; set; } = true;
        public object Data { get; set; }
    }
}

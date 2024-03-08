using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;

namespace Reciplastk.Gateway.Services
{
    public class SecurityService
    {
        private readonly ReciplastkContext db;

        public SecurityService(ReciplastkContext db)
        {
            this.db = db;
        }
        public HttpResponseModel Login(LoginModel loginModel)
        {
            var userInfo = db.Employees.Where(p => p.Username == loginModel.UserName && p.Password == loginModel.Password).FirstOrDefault();
            var response = new HttpResponseModel();
            if (userInfo == null)
            {
                response.WasSuccessful = false;
                response.StatusMessage = "The information provided was not correct.";
            }
            else
            {
                response.WasSuccessful = true;
                response.StatusMessage = "The user was recognized.";
                response.Data = userInfo;
            }
            return response;
        }
    }
}

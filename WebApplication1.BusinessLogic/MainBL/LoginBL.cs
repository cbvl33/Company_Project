using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.BusinessLogic.Interfaces;
using WebApplication1.Domain.Entities.Respond;
using WebApplication1.Domain.Entities.User;
using System.Web;
using WebApplication1.Domain.Entities.User.Models;
using WebApplication1.BusinessLogic.MainAPI;

namespace WebApplication1.BusinessLogic.MainBL
{
    public class LoginBL : UserAPI, ILogin
    {//убираем
     //public LoginResponse Login(ULoginData loginData)
     //{
     //    return LoginCheck(loginData);
     //}
     // убираем
     //public LoginResponse RegisterUsers(URegisterData loginData)
     //{
     //    return RegisterNewUsers(loginData);
     //}
     // убираем под вопросом 
     //public LoginResponse GenerateUserSessionActionFlow(ULoginData uData)
     //{
     //    return GenerateUserSession(uData);
     //}
        /// 
        public LoginResponse UserLogin(ULoginData data)
        {
            return UserLoginAction(data);
        }
        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }

        public UMinData GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }
    }
}

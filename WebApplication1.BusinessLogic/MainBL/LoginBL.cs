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
    {
        public LoginResponse Login(ULoginData loginData)
        {
            return LoginCheck(loginData);
        }

        public LoginResponse RegisterUsers(URegisterData loginData)
        {
            return RegisterNewUsers(loginData);
        }

        public LoginResponse GenerateUserSessionActionFlow(ULoginData loginData)
        {
            return GenerateUserSession(loginData);
        }
        public HttpCookie CookieGenerate(string Uname)
        {
            return UserGenerateCookie(Uname);
        }

        public UMinData GetUserByCookie(string cookieName)
        {
            return GetUserByCookieApi(cookieName);
        }

        public void CloseCurrentSession(string sessionName)
        {
           // CloseCurrentSession_Api(sessionName);
        }

    }
}

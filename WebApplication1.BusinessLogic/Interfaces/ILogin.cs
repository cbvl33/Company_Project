using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.Domain.Entities.Respond;
using WebApplication1.Domain.Entities.User;
using WebApplication1.Domain.Entities.User.Models;

namespace WebApplication1.BusinessLogic.Interfaces
{
    public interface ILogin
    {
        //LoginResponse RegisterUsers(URegisterData uData);
        //LoginResponse Login(ULoginData loginData);
        LoginResponse UserLogin(ULoginData data);
        HttpCookie GenCookie(string loginCredential);
        UMinData GetUserByCookie(string apiCookieValue);
        //void CloseCurrentSession(string sessionName);


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.BusinessLogic.MainAPI;
using WebApplication1.BusinessLogic.Interfaces;
using WebApplication1.Domain.Entities.Respond;
using WebApplication1.Domain.Entities.User;

namespace WebApplication1.BusinessLogic.MainBL
{
    public class LoginBL : UserAPI, ILogin
    {
        public LoginResponse Login(ULoginData loginData)
        {
            return LoginCheck(loginData);
        }
    }
}

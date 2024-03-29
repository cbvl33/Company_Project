using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.BusinessLogic.Core;
using WebApplication1.BusinessLogic.Interfaces;
using WebApplication1.Domain.Entities.Respond;
using WebApplication1.Domain.Entities.User;

namespace WebApplication1.BusinessLogic.MainBL
{
    public class LoginBL : UserApi, ILogin
    {
        public LoginResponse Login(ULoginData ulogindata)
        {
            return LoginCheck(ulogindata);
        }
    }
}

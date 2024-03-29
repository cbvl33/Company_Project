using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities.Respond;
using WebApplication1.Domain.Entities.User;


namespace WebApplication1.BusinessLogic.Core
{
    public class UserApi
    {
        public LoginResponse LoginCheck(ULoginData uld)
        {
            LoginResponse response = new LoginResponse();
            if (uld.Email == "lera_ira@gmail.com")
            {
                response.succes = true;
                return response;
            }
            response.succes = false;
            return response;
        }
    }
}

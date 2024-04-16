﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.BusinessLogic.DBModel;
using WebApplication1.Domain.Entities.Respond;
using WebApplication1.Domain.Entities.User;

namespace WebApplication1.BusinessLogic.MainAPI
{
    public class UserAPI
    {

        internal LoginResponse LoginCheck(ULoginData uld)
        {
            UserDTO local;
            using (var db = new UserContext())
            {
                local = db.Users.FirstOrDefault(x => x.Email == uld.Credential);
              
            }
            if (local != null)
            {
                return new LoginResponse { Status = true };
            }
            return new LoginResponse { Status = false, StatusMessage = "NO USER WITH THIS EMAIL" };
          // LoginResponse response = new LoginResponse();
          // if (uld.Email == "lera_ira@gmail.com")
          // {
          //     response.succes = true;
          //     return response;
          // }
          // response.succes = false;
          // return response;
        }
    }
}
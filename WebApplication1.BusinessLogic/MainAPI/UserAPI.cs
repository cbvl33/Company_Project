using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.BusinessLogic.DBModel;
using WebApplication1.Domain.Entities.Respond;
using WebApplication1.Domain.Entities.User;
using WebApplication1.Domain.Enums;
using WebApplication1.Helpers;

namespace WebApplication1.BusinessLogic.MainAPI
{
    public class UserAPI
    {

        internal LoginResponse LoginCheck(ULoginData uld)
        {
            UserDTO local;
            using (var db = new UserContext())
            {
                local = db.Users.FirstOrDefault(x => x.Email == uld.Email);
              
            }
            if (local != null)
            {
                return new LoginResponse { Status = true };
            }
            return new LoginResponse { Status = false, StatusMessage = "NO USER WITH THIS EMAIL" };
         
        }

        internal LoginResponse GenerateUserSession(ULoginData uld)
        {
            UserDTO local;
            var password = PasswordManager.Md5Crypt(uld.Password);
            using (var db = new UserContext())
            {
                local = db.Users.FirstOrDefault(x => x.Email == uld.Email);

            }

            if (local == null)
            {
                return new LoginResponse { Status = false, StatusMessage = "WRONG USERNAME OR PASSWORD" };
            }

            return new LoginResponse { Status = true };
        }

        internal LoginResponse RegisterNewUsers(URegisterData data)
        {
            UserDTO local;
            using (var db = new UserContext())
            {
                local = db.Users.FirstOrDefault(x => x.Email == data.Email);

            }
            if (local != null)
            {
                return new LoginResponse
                {
                    Status = false,
                    StatusMessage = "This username is already registered"
                };
            }

            var user = new UserDTO 
            {
                Password = PasswordManager.Md5Crypt(data.Password),
                Email = data.Email,
                UserName = data.Name,
                LastLogin = data.LastLogin,
                UserIp = data.UserIP,
                Created = DateTime.Now,
                Levels = Levels.User,
            };

            using (var db = new UserContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            return new LoginResponse 
            { 
                Status = true            
            };
        }
    }
}

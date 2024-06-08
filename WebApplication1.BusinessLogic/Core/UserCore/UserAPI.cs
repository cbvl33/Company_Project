using System;
using System.Linq;
using System.Data.Entity;
using System.Web;
using WebApplication1.Domain.Entities.User;
using WebApplication1.Domain.Entities.Respond;
using WebApplication1.Helpers;
using System.Net.Http;
using AutoMapper;
using WebApplication1.BusinessLogic.DBModel;
using WebApplication1.Domain.Entities.UDbTable;
using WebApplication1.Domain.Enums;
using WebApplication1.Domain.Entities.User.Models;
using System.ComponentModel.DataAnnotations;
using static System.Collections.Specialized.BitVector32;
using WebApplication1.Domain.Entities.User.UDbTable;
namespace WebApplication1.BusinessLogic.MainAPI
{
    public class UserAPI
    {
        internal LoginResponse UserLoginAction(ULoginData data)
        {
            UserDTOes result;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Email))
            {
                
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Email && u.Password == data.Password);
                }

                if (result == null)
                {
                    return new LoginResponse { Status = false, StatusMessage = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    result.LasIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new LoginResponse { Status = true };
            }
            else
            {
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Email && u.Password == data.Password);
                }

                if (result == null)
                {
                    return new LoginResponse { Status = false, StatusMessage = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    result.LasIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new LoginResponse { Status = true };
            }
        }

        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGeneration.Create(loginCredential)
            };

            using (var db = new SessionContext())
            {
                UDbSession curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredential))
                {
                    curent = (from e in db.Sessions where e.UserName == loginCredential select e).FirstOrDefault();
                }
                else
                {
                    curent = (from e in db.Sessions where e.UserName == loginCredential select e).FirstOrDefault();
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.Lifetime = DateTime.Now.AddMinutes(60);
                    using (var todo = new SessionContext())
                    {
                        todo.Entry(curent).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new UDbSession
                    {
                        UserName = loginCredential,
                        CookieString = apiCookie.Value,
                        Lifetime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
        }

        internal UMinData UserCookie(string cookie)
        {
            UDbSession session;
            UserDTOes curentUser;

            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.Lifetime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.UserName))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.UserName);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.UserName);
                }
            }



            if (curentUser == null) return null;
            Mapper.Initialize(cfg => cfg.CreateMap<UserDTOes, UMinData>());
            var userminimal = Mapper.Map<UMinData>(curentUser);

            return userminimal;
        }
    }
}

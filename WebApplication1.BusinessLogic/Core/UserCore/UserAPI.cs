using System;
using System.Linq;
using System.Data.Entity;
using System.Web;
using WebApplication1.Domain.Entities.User;
using WebApplication1.Domain.Entities.Respond;
using WebApplication1.Helpers;
using System.Net.Http;
using WebApplication1.BusinessLogic.DBModel;
using WebApplication1.Domain.Entities.Product.PDbTable;
using WebApplication1.Domain.Entities.UDbTable;
using WebApplication1.Domain.Enums;
using WebApplication1.Domain.Entities.User.Models;

namespace WebApplication1.BusinessLogic.MainAPI
{
    public class UserAPI
    {
        internal LoginResponse LoginCheck(ULoginData uld)
        {
            UserDTO local;
            var hashpass = PasswordManager.Md5Crypt(uld.Password);

            using (var db = new UserContext())
            {
                local = db.Users.FirstOrDefault(x => x.Email == uld.Email && x.Password == hashpass);
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
                local = db.Users.FirstOrDefault(x => x.Email == uld.Email && x.Password == password);
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

            return new LoginResponse { Status = true };
        }

        public HttpCookie UserGenerateCookie(string Username)
        {
            var cookies = new HttpCookie("WebApplication1")
            {
                Value = CookieGeneration.Create(Username)
            };

            using (var db = new SessionContext())
            {
                UDbSession current;

                current = (from el in db.Sessions where el.UserName == Username select el).FirstOrDefault();

                if (current != null)
                {
                    current.CookieString = cookies.Value;
                    current.Lifetime = DateTime.Now.AddHours(2);
                    using (var db_context = new SessionContext())
                    {
                        db_context.Entry(current).State = EntityState.Modified;
                        db_context.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new UDbSession
                    {
                        UserName = Username,
                        CookieString = cookies.Value,
                        Lifetime = DateTime.Now.AddHours(2)
                    });
                    db.SaveChanges();

                }
                return cookies;
            }
        }
        public UMinData GetUserByCookieApi(string cookie)
        {
            UDbSession session;
            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(el => el.CookieString == cookie);

                if (session != null)
                {
                    if (session.Lifetime < DateTime.Now)
                    {
                        db.Sessions.Remove(session);
                        db.SaveChanges();
                        return null;
                    }

                    UserDTO user;
                    using (var db_user = new UserContext())
                    {
                        user = db_user.Users.FirstOrDefault(u => u.UserName == session.UserName);
                    }
                    UMinData uMinData = new UMinData()
                    {
                        Username = user.UserName,
                        Email = user.Email,
                        Level = user.Levels
                    };
                    return uMinData;
                }
            }
            return null;
        }
    }
}

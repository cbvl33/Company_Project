using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Domain.Enums;
using WebApplication1.BusinessLogic.DBModel;
using WebApplication1.BusinessLogic.Interfaces;
using WebApplication1.Domain.Entities.Respond;
using WebApplication1.Domain.Entities.User;
using WebApplication1.Models.User;
using WebApplication1.Domain.Entities.UDbTable;
using WebApplication1.Domain.Entities.Product.PDbTable;
using WebApplication1.Domain.Entities.User.UDbTable;
using System.Data.Entity.Infrastructure;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogin _session;
        public LoginController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetLoginBL();
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(UActionLogin model)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<UActionLogin, ULoginData>());
                var data = Mapper.Map<ULoginData>(model);

                data.UserIP = Request.UserHostAddress;
                data.LastLogin = DateTime.Now;
                // в Isession
                var userLogin = _session.UserLogin(data);
                if (userLogin.Status)
                {
                    HttpCookie cookie = _session.GenCookie(model.Email);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    using (UserContext db = new UserContext())
                    {
                        data.Level = db.Users.FirstOrDefault(u => u.Email == data.Email).Levels;
                    }
                    if (data.Level == Levels.Admin)
                        return RedirectToAction("Admin", "User");
                    else
                        return RedirectToAction("user", "User");
                }
                else
                {
                    ModelState.AddModelError("Email", userLogin.StatusMessage);
                    return View();
                }
            }

            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                using (UserContext db = new UserContext())
                {
                    if (db.Users.Any(u => u.Email == model.Email))
                    {
                        ModelState.AddModelError("Email", "Email уже занят");
                        return View(model);
                    }
                    //

                    var user = new UserDTOes
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        Password = model.Password,
                        Levels = Levels.User,
                        LastLogin = DateTime.Now,
                        Created = DateTime.Now,
                    };
                    db.Users.Add(user);
                    db.SaveChanges();

                    using (var sessionDb = new SessionContext())
                    {
                        var thisSession = sessionDb.Sessions.FirstOrDefault(s => s.UserName == model.UserName);
                        if(thisSession != null)
                        {
                            // bimbimbambam ya ne yebu prosto pishu
                        }
                        //не верю =)
                        var session = new UDbSession()
                        {
                            CookieString = " dmvjnjvnjsnv",
                            UserName = model.UserName,
                            Lifetime = DateTime.Now,

                        };
                        sessionDb.Sessions.Add(session);
                        sessionDb.SaveChanges();
                    }
                    using (var cdb = new CommentContext())
                    {
                        var thisCom = new CDbTable()
                        {
                            Email = model.Email,
                            Text = "kmvfdvmjfndvjndfjvjdnvjndjvndjvnd",
                            Status = ARole.REJECTED
                        };
                        cdb.Comment.Add(thisCom);
                        cdb.SaveChanges();
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult SignOut()
        {
            System.Web.HttpContext.Current.Session.Clear();
            var cookie = ControllerContext.HttpContext.Request.Cookies["X-KEY"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }
            System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
            System.Web.HttpContext.Current.Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}
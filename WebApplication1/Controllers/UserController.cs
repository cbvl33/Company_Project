using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BusinessLogic.DBModel;
using WebApplication1.BusinessLogic;
using WebApplication1.Domain.Entities.User.UDbTable;
using WebApplication1.Domain.Entities.User;
using WebApplication1.BusinessLogic.Interfaces;
using WebApplication1.Extension;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogin _session;

        public UserController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetLoginBL();
        }

        [HttpGet]

        public ActionResult user()
        {
            var apiCookie = Request.Cookies["X-KEY"];
            var profile = _session.GetUserByCookie(apiCookie.Value);
            if (profile != null)
            {
                System.Web.HttpContext.Current.SetMySessionObject(profile);
                System.Web.HttpContext.Current.Session["LoginStatus"] = "login";
            }
            else
            {
                System.Web.HttpContext.Current.Session.Clear();
                if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("X-KEY"))
                {
                    var cookie = ControllerContext.HttpContext.Request.Cookies["X-KEY"];
                    if (cookie != null)
                    {
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    }
                }
            }
            if (profile.Level != Domain.Enums.Levels.User)
            {
                return RedirectToAction("Index", "Home");
            }
            UserData u = new UserData();
            u.UserName = profile.UserName;
            u.Email = profile.Email;
            u.LastName = profile.LastName;
            u.PhoneNumber = profile.Number;


            return View(u);
        }

        [HttpGet]

        public ActionResult Expert()
        {
            var apiCookie = Request.Cookies["X-KEY"];
            var profile = _session.GetUserByCookie(apiCookie.Value);
            if (profile != null)
            {
                System.Web.HttpContext.Current.SetMySessionObject(profile);
                System.Web.HttpContext.Current.Session["LoginStatus"] = "login";
            }
            else
            {
                System.Web.HttpContext.Current.Session.Clear();
                if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("X-KEY"))
                {
                    var cookie = ControllerContext.HttpContext.Request.Cookies["X-KEY"];
                    if (cookie != null)
                    {
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    }
                }
            }
            if (profile.Level != Domain.Enums.Levels.Expert)
            {
                return RedirectToAction("Index", "Home");
            }
            UserData u = new UserData();
            u.UserName = profile.UserName;
            u.Email = profile.Email;
            u.LastName = profile.LastName;
            u.PhoneNumber = profile.Number;


            return View(u);
        }

        public ActionResult appointment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult appointment(AppointmentRegistration model)
        {
            var apiCookie = Request.Cookies["X-KEY"];
            var profile = _session.GetUserByCookie(apiCookie.Value);
            if (profile != null)
            {
                System.Web.HttpContext.Current.SetMySessionObject(profile);
                System.Web.HttpContext.Current.Session["LoginStatus"] = "login";
            }
            else
            {
                System.Web.HttpContext.Current.Session.Clear();
                if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("X-KEY"))
                {
                    var cookie = ControllerContext.HttpContext.Request.Cookies["X-KEY"];
                    if (cookie != null)
                    {
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    }
                }
            }
            if (ModelState.IsValid)
            {
                using (var db = new AppointmentContext())
                {
                    if (db.Users.Any(u => u.Time == model.Time && u.Expert == model.Expert && u.Date == model.Date))
                    {
                        ModelState.AddModelError("Notes", "Это время занято, выберите другое");
                        return View(model);
                    }

                    var user = new ADbTable
                    {
                        Email = profile.Email,
                        Expert = model.Expert,
                        Service = model.Service,
                        Date = model.Date,
                        Time = model.Time,
                        Notes = model.Notes,
                    };
                    switch (model.Expert)
                    {
                        case Domain.Enums.Experts.AmandaJepson:
                            user.DEmail = "amandajepson@gmail.com";
                            user.Number = Domain.Enums.Numbers.Number1;
                            break;
                        case Domain.Enums.Experts.WilliamAnderson:
                            user.DEmail = "williamanderson@gmail.com";
                            user.Number = Domain.Enums.Numbers.Number2;
                            break;
                        case Domain.Enums.Experts.WalterWhite:
                            user.DEmail = "walterwhite@gmail.com";
                            user.Number = Domain.Enums.Numbers.Number3;
                            break;
                        case Domain.Enums.Experts.SarahJhonson:
                            user.DEmail = "sarahjhonson@gmail.com";
                            user.Number = Domain.Enums.Numbers.Number4;
                            break;
                    }
                    db.Users.Add(user);
                    db.SaveChanges();


                    return RedirectToAction("user", "User");
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Comment(string text)
        {
            var apiCookie = Request.Cookies["X-KEY"];
            var profile = _session.GetUserByCookie(apiCookie.Value);
            if (profile != null)
            {
                System.Web.HttpContext.Current.SetMySessionObject(profile);
                System.Web.HttpContext.Current.Session["LoginStatus"] = "login";
            }
            else
            {
                System.Web.HttpContext.Current.Session.Clear();
                if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("X-KEY"))
                {
                    var cookie = ControllerContext.HttpContext.Request.Cookies["X-KEY"];
                    if (cookie != null)
                    {
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    }
                }
            }
            if (text != null)
            {
                using (var db = new CommentContext())
                {
                    if (db.Comment.Any(u => u.Email == profile.Email && u.Status != Domain.Enums.ARole.REJECTED))
                    {
                        ModelState.AddModelError("Notes", "Вы уже оставили отзыв, дождитесь, пока он будет рассмотрен");
                        return RedirectToAction("user", "User");
                    }
                    var comment = new CDbTable
                    {
                        Email = profile.Email,
                        Text = text,
                        Status = Domain.Enums.ARole.NOTSELECTED
                    };

                    db.Comment.Add(comment);
                    db.SaveChanges();


                    return RedirectToAction("user", "User");
                }
            }
            else
            {
                ModelState.AddModelError("Notes", "Поле пустое");
                return RedirectToAction("user", "User");
            }

        }

    }
}
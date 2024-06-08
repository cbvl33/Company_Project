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
using WebApplication1.Domain.Entities.User.UDbTable;
using System.Data.Entity.Infrastructure;
using WebApplication1.BusinessLogic;

namespace eUseControl.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogin _session;
        public LoginController()
        {
            var bl = new BusinessLogic();
            _session = bl.GetLoginBL();
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminSignIn(UActionLogin model)
        {
            if (ModelState.IsValid)
            {
                // Здесь добавьте логику для аутентификации администратора
                if (model.Email == "admin@example.com" && model.Password == "adminpassword")
                {
                    // Аутентификация успешна
                    // Здесь вы можете выполнить действия, специфичные для администратора
                    return RedirectToAction("Expert", "User");
                }
                else
                {
                    // Ошибка аутентификации администратора
                    ModelState.AddModelError("", "Неверные учетные данные эксперта.");
                    return View();
                }
            }

            // Неверные данные в форме
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

                data.LoginIp = Request.UserHostAddress;
                data.LoginDateTime = DateTime.Now;

                var userLogin = _session.UserLogin(data);
                if (userLogin.Status)
                {
                    HttpCookie cookie = _session.GenCookie(model.Email);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    using (UserContext db = new UserContext())
                    {
                        data.Level = db.Users.FirstOrDefault(u => u.Email == data.Email).Level;
                    }
                    if (data.Level == WebApplication1.Domain.Enums.Levels.Expert)
                        return RedirectToAction("Expert", "User");
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
                    if (model.Password != model.ConfirmPassword)
                    {
                        ModelState.AddModelError("ConfirmPassword", "Не правильно повторили пароль ");
                        return View(model);
                    }

                    var user = new UserDTOes()
                    {
                        UserName = model.UserName,
                        LastName = model.LastName,
                        Number = model.Number,
                        Email = model.Email,
                        Password = model.Password,
                        Level = WebApplication1.Domain.Enums.Levels.User,
                        LastLogin = DateTime.Now

                    };
                    db.Users.Add(user);
                    db.SaveChanges();

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
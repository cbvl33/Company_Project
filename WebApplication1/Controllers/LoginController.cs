using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BusinessLogic.Interfaces;
using WebApplication1.Domain.Entities.Respond;
using WebApplication1.Domain.Entities.User;
using WebApplication1.Models.Authentication;
using WebApplication1.Models.User;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogin DoLogin;
        public LoginController()
        {
            var tmp = new BusinessLogic.BusinessLogic();
            DoLogin = tmp.GetLoginBL();

        }

        public ActionResult Index()
        {
            return View(new UActionLogin());
        }

        [HttpPost]
        public ActionResult LoginAction(UActionLogin data)
        {
            var address = base.Request.UserHostAddress;
            ULoginData loginData = new ULoginData
            {
                Email = data.Email,
                Password = data.Password,
                LastLogin = DateTime.Now,
                UserIP = address
            };
            LoginResponse resp = DoLogin.Login(loginData);
            if (resp.Status)
            {
                LoginResponse auth = DoLogin.GenerateUserSessionActionFlow(loginData);
                if (resp.Status)
                {
                    return View("~/Views/Home/Index.cshtml");
                }
            }
            return null;

        }

        public ActionResult Register()
        {
            return View(new UActionRegister());
        }

        [HttpPost]
        public ActionResult RegisterAction(UActionRegister data)
        {
            var address = base.Request.UserHostAddress;
            var uData = new URegisterData
            {
                Name = data.Name,
                Email = data.Email,
                Password = data.Password,
                LastLogin = DateTime.Now,
                UserIP = address
            };
            LoginResponse resp = DoLogin.RegisterUsers(uData);
            if (resp.Status)
            {
                return View("~/Views/Home/Index.cshtml");
            }
            return null;
        }
    }
}
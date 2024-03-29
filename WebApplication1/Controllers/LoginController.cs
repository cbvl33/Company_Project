using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BusinessLogic.Interfaces;
using WebApplication1.Domain.Entities.Respond;
using WebApplication1.Domain.Entities.User;
using WebApplication1.Models.Authentication;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        internal ILogin DoLogin;
        public LoginController()
        {
            var gg = new BusinessLogic.BusinessLogic();
            DoLogin = gg.GetLoginBL();
        }

        [HttpPost]
        public ActionResult LoginAction(MLogin mLogin) 
        {
            ULoginData loginData = new ULoginData
            {
                Email = mLogin.Email,
                Password = mLogin.Password,
            };
            LoginResponse resp = DoLogin.Login(loginData);

            return View();
        
        }
    }
}
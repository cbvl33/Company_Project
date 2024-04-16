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

        [HttpPost]
        public ActionResult LoginAction(UActionLogin data) 
        {
            var address = base.Request.UserHostAddress;
            ULoginData loginData = new ULoginData
            { 
                Credential = data.Credential,
                Password = data.Password,
                LastLogin = DateTime.Now,
                UserIP = address
            };
            LoginResponse resp = DoLogin.Login(loginData);


            return View();
        
        }
    }
}
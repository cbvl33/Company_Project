using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BusinessLogic.Interfaces;
using WebApplication1.Domain.Entities.User.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogin _session;
        public HomeController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetLoginBL();
        }
        public ActionResult Index()
        {
            SessionStatus();
            var apiCookie = Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                return View(profile);
            }
            var empty = new UMinData();
            empty.Level = Domain.Enums.Levels.None;
            return View(empty);
        }
        public ActionResult Contact()
        {
            SessionStatus();
            var apiCookie = Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                return View(profile);
            }
            var empty = new UMinData();
            empty.Level = Domain.Enums.Levels.None;
            return View(empty);
        }
        public ActionResult About()
        {
            SessionStatus();
            var apiCookie = Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                return View(profile);
            }
            var empty = new UMinData();
            empty.Level = Domain.Enums.Levels.None;
            return View(empty);
        }
        public ActionResult Pricing()
        {
            SessionStatus();
            var apiCookie = Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                return View(profile);
            }
            var empty = new UMinData();
            empty.Level = Domain.Enums.Levels.None;
            return View(empty);
        }

        public ActionResult Testimonials()
        {
            SessionStatus();
            var apiCookie = Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                return View(profile);
            }
            var empty = new UMinData();
            empty.Level = Domain.Enums.Levels.None;
            return View(empty);
        }

        public ActionResult Services()
        {
            SessionStatus();
            var apiCookie = Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                return View(profile);
            }
            var empty = new UMinData();
            empty.Level = Domain.Enums.Levels.None;
            return View(empty); 
        }

        public ActionResult Portfolio ()
        {
            SessionStatus();
            var apiCookie = Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                return View(profile);
            }
            var empty = new UMinData();
            empty.Level = Domain.Enums.Levels.None;
            return View(empty);
        }

        public ActionResult Blog ()
        {
            SessionStatus();
            var apiCookie = Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                return View(profile);
            }
            var empty = new UMinData();
            empty.Level = Domain.Enums.Levels.None;
            return View(empty);
        }

        public ActionResult Blog_Single()
        {
            SessionStatus();
            var apiCookie = Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                return View(profile);
            }
            var empty = new UMinData();
            empty.Level = Domain.Enums.Levels.None;
            return View(empty);
        }

        public ActionResult Team()
        {
            SessionStatus();
            var apiCookie = Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                return View(profile);
            }
            var empty = new UMinData();
            empty.Level = Domain.Enums.Levels.None;
            return View(empty);
        }


    }
}
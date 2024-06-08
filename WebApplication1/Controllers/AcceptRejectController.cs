using WebApplication1.BusinessLogic.DBModel;
using WebApplication1.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Domain.Enums;
using WebApplication1.Models;
using WebApplication1.Domain.Entities.User.UDbTable;

namespace WebApplication1.Controllers
{
    public class AcceptRejectController : Controller
    {
        [HttpPost]
        public ActionResult Accept()
        {
            string Id = Request.Form["Id"];
            var ConvertID = Convert.ToInt32(Id);
            using (var db = new AppointmentContext())
            {
                var app = db.Users.Where(a => a.Id == ConvertID).FirstOrDefault();
                app.Status = ARole.ACCEPTED;
                db.SaveChanges();
            }
            return RedirectToAction("Expert", "User");
        }
        [HttpPost]
        public ActionResult Reject()
        {
            string Id = Request.Form["Id"];
            var ConvertID = Convert.ToInt32(Id);
            using (var db = new AppointmentContext())
            {
                var app = db.Users.Where(a => a.Id == ConvertID).FirstOrDefault();
                app.Status = ARole.REJECTED;
                db.SaveChanges();
            }
            return RedirectToAction("Expert", "User");
        }
        [HttpPost]
        public ActionResult AcceptComment()
        {
            string Id = Request.Form["Id"];
            var ConvertID = Convert.ToInt32(Id);
            using (var db = new CommentContext())
            {
                var app = db.Comment.Where(a => a.Id == ConvertID).FirstOrDefault();
                app.Status = ARole.ACCEPTED;
                db.SaveChanges();
            }
            return RedirectToAction("Expert", "User");
        }
        [HttpPost]
        public ActionResult RejectComment()
        {
            string Id = Request.Form["Id"];
            var ConvertID = Convert.ToInt32(Id);
            using (var db = new CommentContext())
            {
                var app = db.Comment.Where(a => a.Id == ConvertID).FirstOrDefault();
                app.Status = ARole.REJECTED;
                db.SaveChanges();
            }
            return RedirectToAction("Expert", "User");
        }
        public ActionResult ChangeEmail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangeEmail(UserChangeEmail user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new UserContext())
                {
                    if (db.Users.Any(u => u.Email == user.NewEmail))
                    {
                        ModelState.AddModelError("Email", "Email уже занят");
                        return View(user);
                    }
                    var User = db.Users.Where(p => p.Email == user.Email).FirstOrDefault();
                    if (User.Password == user.Password)
                    {
                        User.Email = user.NewEmail;
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Не правильный пароль");
                        return View(user);
                    }
                    db.SaveChanges();
                }
                using (var db = new CommentContext())
                {
                    var Comments = db.Comment.Where(p => p.Email == user.Email);
                    foreach (var Comment in Comments)
                    {
                        Comment.Email = user.NewEmail;
                    }
                    db.SaveChanges();
                }
                using (var db = new AppointmentContext())
                {
                    var Appointments = db.Users.Where(p => p.Email == user.Email);
                    foreach (var Appointment in Appointments)
                    {
                        Appointment.Email = user.NewEmail;
                    }
                    db.SaveChanges();
                }

            }
            return RedirectToAction("SignIn", "Login");
        }
    }
}
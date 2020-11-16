using MVCBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCBank.Controllers
{
    [HandleError]
    [AllowAnonymous]
    public class UserController : Controller
    {        BankContext db = new BankContext();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Id,UserName,Password,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            
            

            return View(user);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User obj)
        {
            var count = db.Users.Where(u => u.UserName == obj.UserName && u.Password == obj.Password).Count();
            if (count <= 0)
            {
                ViewBag.Message = "Invalid User";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(obj.UserName, false);
                return RedirectToAction("Index", "Home");
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
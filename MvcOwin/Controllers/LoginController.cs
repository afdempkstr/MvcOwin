using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOwin.Models;
using MvcOwin.ViewModels;

namespace MvcOwin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account account)
        {
            UserManager manager = new UserManager();

            //var loggedInUser = manager.Login(account.Username, account.Password);

            //if (loggedInUser != null)
            //{
            //    Session["user"] = loggedInUser;
            //    return View("Success", loggedInUser);
            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}
            return RedirectToAction("Index");
        }
    }
}
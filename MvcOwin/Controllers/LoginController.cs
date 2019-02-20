using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
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
            var user = manager.GetUser(account.Username);
            if (user == null || user.Password != account.Password)
            {
                ModelState.AddModelError("Username", "Invalid username or password");
                return RedirectToAction("Index");
            }

            var claims = new List<Claim>(new[]
            {
                // adding following 2 claim just for supporting default antiforgery provider
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(
                    "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                    "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),
                new Claim(ClaimTypes.Name, user.Username)
            });

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            HttpContext.GetOwinContext().Authentication.SignIn(
                new AuthenticationProperties { IsPersistent = false }, identity);

            Session["user"] = user;
            return RedirectToAction("Index", "Home");
        }
    }
}
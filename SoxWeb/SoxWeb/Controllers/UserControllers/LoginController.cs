using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SoxWeb.Models;
using SoxWeb.PasswordManager;
using System.Web.Security;

namespace SoxWeb.Controllers.UserControllers
{
    public class AccountController : Controller
    {
        
        private PasswordChecker passwordManager = new PasswordChecker();

        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountLogin model, string returnUrl)
        {


            if (ModelState.IsValid)
            {
                string userName = model.Username;

                string password = model.Password;

                //var user = db.User.Where(u => u.Email == email).SingleOrDefault();

                //string salt = user.salt;

                //bool userValid = passwordManager.IsPasswordValid(password, salt, user.Password);

                bool userValid = true;

                if (userValid)
                {
                    FormsAuthentication.SetAuthCookie(userName, false);

                    if (returnUrl != null)
                        //return Redirect(returnUrl);
                        return RedirectToAction("Index", "Home");

                    return RedirectToAction("Index", "Home");

                }

                else
                {
                    ModelState.AddModelError("", "The username and password provided does not match.");
                }
            }

            else
            {
                ModelState.AddModelError("", "The username or password provided is not valid.");
            }


            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        } 

    }
}

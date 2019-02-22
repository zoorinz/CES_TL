using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutePlanningCES.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public bool AuthUser(string username, string password)
        {
            User user = null;
            if (ValidateString(username) && ValidateString(password))
            {
                using (var context = new TLContext())
                {
                    user = context.GetUser(username, password);
                }
            }
            return user != null;
        }

        //TODO ensure we check the string input.
        private bool ValidateString(string str)
        {
            return true;
        }
    }
}
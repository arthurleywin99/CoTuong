using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoAPI.ViewModels;
using Lib.Entities;
using Lib.Services;

namespace DemoAPI.Controllers.api
{
    public class UserController : Controller
    {
        UserService userService = new UserService();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(LoginViewModel loginModel)
        {
            User user = userService.Login(loginModel.Username, loginModel.Password);
            if (user == null)
            {
                return HttpNotFound();
            }
            Session["User"] = user;
            return RedirectToAction("GetAllRoom", "Chess");
        }
    }
}
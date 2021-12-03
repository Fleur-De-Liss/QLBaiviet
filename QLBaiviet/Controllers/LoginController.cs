using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBaiviet.Models;
using QLBaiviet.Session;

namespace QLBaiviet.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel loginModel)
        {
            var res = new UserModel().Login(loginModel.Username, loginModel.Password);
            if(res && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession() { UserName = loginModel.Username });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu sai");
            }
            return View(loginModel);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using _19T1021316.BusinessLayers;
using _19T1021316.DomainModels;

namespace _19T1021316.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [Authorize]

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
        /// <summary>
        /// Trang đăng nhập vào hệ thống
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string userName = "", string password = "")
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.UserName = userName;

                ModelState.AddModelError("", "Thông tin không đầy đủ");
                return View();
            }

            var userAccount = UserAccountService.Authorize(AccountTypes.Employee, userName, password);
            if (userAccount == null)
            {
                ModelState.AddModelError("", "Thông tin đăng nhập không đúng");
                return View();
            }

            //Ghi cookie cho phiên đăng nhập
            string cookieString = Newtonsoft.Json.JsonConvert.SerializeObject(userAccount);
            FormsAuthentication.SetAuthCookie(cookieString, false);

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Logout()
        {
            Session.Clear();

            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [ValidateAntiForgeryToken]
        [AllowAnonymous]

        public ActionResult ChangePassword(string UserName, string oldPassword, string newPassword, string newPasswordAgain)
        {
            if (newPassword != newPasswordAgain)
            {
                ModelState.AddModelError("", "Xác nhận mật khẩu không chính xác");
                return View("Edit");
            }
            bool changePass = UserAccountService.ChangePassword(AccountTypes.Employee, UserName, oldPassword, newPassword);

            if (changePass == false)
            {
                ModelState.AddModelError("", "Mật khẩu cũ không chính xác");
                return View("Edit");
            }

            return RedirectToAction("Edit");
        }
    }
}
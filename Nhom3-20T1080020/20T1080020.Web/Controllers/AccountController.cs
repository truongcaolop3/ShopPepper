using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _20T1080020.DomainModels;
using _20T1080020.DataLayers;
using _20T1080020.BusinessLayers;
using System.Web.Security;

namespace _20T1080020.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
       
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string username = "", string password = "")
        {

            ViewBag.UserName = username;
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "thông tin không đầy đủ");
                return View();
            }
            var userAccount = UserAcccountSevice.Authorize(AccountTypes.Employee, username, password);
            if (userAccount == null)
            {
                ModelState.AddModelError("", "Đăng nhập thất bại");
                return View();
            }
            // ghi cookie cho phiên đăng nhập
            // chuyển offject về chuỗi
            string cookieString = Newtonsoft.Json.JsonConvert.SerializeObject(userAccount);
            FormsAuthentication.SetAuthCookie(cookieString, false);
            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// đăng xuất 
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        /// <summary>
        /// đổi mật khẩu
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangePassword()
        {
            ViewBag.Title = "Thay đổi mật khẩu";
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ChangePassword(string userName = "", string oldPassword = "", string newPassword = "")
        {
            ViewBag.OldPassword = oldPassword ?? "";
            if (string.IsNullOrWhiteSpace(userName)
                || string.IsNullOrWhiteSpace(oldPassword)
                || string.IsNullOrWhiteSpace(newPassword))
            {
                ModelState.AddModelError("", "Thông tin không đầy đủ");
                return View();
            }

            bool isChangePassword = UserAcccountSevice.ChangePassword(AccountTypes.Employee, userName, oldPassword, newPassword);
            if (!isChangePassword)
            {
                ModelState.AddModelError("", "Thay đổi mật khẩu thất bại");
                return View();
            }

            //ViewBag.messageSuccess = "Thay đổi mật khẩu thành công";
            //return View();
            //return RedirectToAction("Index", "Home");
            return RedirectToAction("Logout");
        }
    }
}
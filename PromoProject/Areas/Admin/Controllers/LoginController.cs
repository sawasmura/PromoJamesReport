using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using PromoProject.Areas.Admin.Models;
using PromoProject.Common;

namespace PromoProject.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            //login vao tai khoan qua viec su dung session
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.Username = user.UserName;
                    userSession.UserID = user.Id;
                    Session.Add(CommonConstants.USER_SESSION,userSession);

                    return RedirectToAction("Index", "Home");
                }
                else if(result == 2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
            }
            return View("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        LoginModel1 db = new LoginModel1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy( User user )
        {
            db.Users.Add( user );
            db.SaveChanges();
            return RedirectToAction("DangNhap");
        }

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(User user)
        {
            var taikhoanForm = user.TaiKhoan;
            var matkhauForm = user.MatKhau;
            var userCheck = db.Users.SingleOrDefault(x =>x.TaiKhoan.Equals(taikhoanForm) && x.MatKhau.Equals(matkhauForm));
            if (userCheck != null)
            {
                Session["User"]=userCheck;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginFail = "Đăng nhập thất bại vui lòng kiểm tra lại tài khoảng hoặc mật khẩu";
                return View("DangNhap");
            }
                
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
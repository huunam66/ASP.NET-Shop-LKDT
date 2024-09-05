using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom.Models.LINQ;

namespace Nhom.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View(new TAI_KHOAN());
        }

        [HttpPost]
        public ActionResult Index(TAI_KHOAN Ac, String Pw_again)
        {
            if (!Ac.MAT_KHAU.Equals(Pw_again))
            {
                ViewBag.Err_pw = "Password không giống nhau !";
                return View(Ac);
            }

            Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
            TAI_KHOAN Us = dt.TAI_KHOANs.Where(item => item.EMAIL.Equals(Ac.EMAIL)).FirstOrDefault();
            if(Us != null) {
                ViewBag.Err_email = "Email đã được sử dụng !";
                return View(Ac);
            }
            Us = dt.TAI_KHOANs.Where(item => item.TEN_TAI_KHOAN.Equals(Ac.TEN_TAI_KHOAN)).FirstOrDefault();
            if (Us != null)
            {
                ViewBag.Err_us = "Username đã tồn tại !";
                return View(Ac);
            }
            Ac.QUYEN_HAN = "user";
            dt.TAI_KHOANs.InsertOnSubmit(Ac);
            dt.SubmitChanges();
            Session["dangkythanhcong"] = "Đăng ký thành công !";
            return Redirect("~/Login"); 
        }
    }
}
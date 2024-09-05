using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom.Models.LINQ;
using Nhom.Support;

namespace Nhom.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            if (Session["User"] == null) return Redirect("/");

            ViewBag.avt = Maker.get_avt();
            ViewBag.profile = true;
            ViewBag.not_cat = true;
            ViewBag.cart_size = Maker.cart_size();
            Session["Page"] = "/profile";
            Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
            TAI_KHOAN ac = (TAI_KHOAN)Session["User"];
            ac = dt.TAI_KHOANs.Where(item => item.TEN_TAI_KHOAN.Equals(ac.TEN_TAI_KHOAN)).FirstOrDefault();
            ViewBag.EMAIL = ac.EMAIL;
            THONG_TIN_TAI_KHOAN ab = ac.THONG_TIN_TAI_KHOANs.Count > 0 ? ac.THONG_TIN_TAI_KHOANs.First() : new THONG_TIN_TAI_KHOAN();
            return View(ab);
        }

        public ActionResult Edit()
        {
            if (Session["User"] == null) return Redirect("/");

            ViewBag.avt = Maker.get_avt();
            ViewBag.profile = true;
            ViewBag.not_cat = true;
            ViewBag.cart_size = Maker.cart_size();
            Session["Page"] = "/profile/edit";
            Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
            TAI_KHOAN ac = (TAI_KHOAN)Session["User"];
            ac = dt.TAI_KHOANs.Where(item => item.TEN_TAI_KHOAN.Equals(ac.TEN_TAI_KHOAN)).FirstOrDefault();
            THONG_TIN_TAI_KHOAN ab = ac.THONG_TIN_TAI_KHOANs.Count > 0 ? ac.THONG_TIN_TAI_KHOANs.First() : new THONG_TIN_TAI_KHOAN();
            ViewBag.account = ac;
            return View(ab);
        }

        [HttpPost]
        public ActionResult Edit(THONG_TIN_TAI_KHOAN ab_us, String EMAIL, HttpPostedFileBase FILE)
        {
            THONG_TIN_TAI_KHOAN ab = new THONG_TIN_TAI_KHOAN();
            ab.HO = ab_us.HO;
            ab.SDT = ab_us.SDT;
            ab.TEN = ab_us.TEN;
            ab.QUAN_HUYEN = ab_us.QUAN_HUYEN;
            ab.PHUONG_XA = ab_us.PHUONG_XA;
            ab.TINH_THANH = ab_us.TINH_THANH;
            ab.DIA_CHI = ab_us.DIA_CHI;
            ab.GIOI_TINH = ab_us.GIOI_TINH;
            TAI_KHOAN ac = ((TAI_KHOAN)Session["User"]);
            ab.TEN_TAI_KHOAN = ac.TEN_TAI_KHOAN;
            Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
            ac = dt.TAI_KHOANs.Where(item => item.TEN_TAI_KHOAN.Equals(ac.TEN_TAI_KHOAN)).FirstOrDefault();
            ac.EMAIL = EMAIL;
            THONG_TIN_TAI_KHOAN abb = ac.THONG_TIN_TAI_KHOANs.Count > 0 ? ac.THONG_TIN_TAI_KHOANs.First() : null;

            ab.ANH_DAI_DIEN = Maker.Upload_Image("avt", FILE);
            if (ab.ANH_DAI_DIEN == null) if (abb != null) ab.ANH_DAI_DIEN = abb.ANH_DAI_DIEN;

            ac.THONG_TIN_TAI_KHOANs.Clear();
            ac.THONG_TIN_TAI_KHOANs.Add(ab);
            dt.SubmitChanges();
            return Redirect("/profile");
        }
    }
}
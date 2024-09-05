 using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Nhom.App_Start;
using Nhom.Models.LINQ;
using Nhom.Models;
using Nhom.Support;

namespace Nhom.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if(Session["User"] != null)
                return Redirect(Session["Page"] != null ? Session["Page"].ToString() : "~/Home");

            if(Session["dangkythanhcong"] != null)
            {
                ViewBag.dangkythanhcong = Session["dangkythanhcong"];
                Session["dangkythanhcong"] = null;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(String Us, String Pw)
        {
            Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
            TAI_KHOAN Ac = dt.TAI_KHOANs.Where(item => item.TEN_TAI_KHOAN.Equals(Us) && item.MAT_KHAU.Equals(Pw)).FirstOrDefault();
            if(Ac != null)
            {
                Session["User"] = Ac;

                List<GIO_HANG> cart_s = (List<GIO_HANG>)Session["cart_s"];
                if(cart_s != null)
                {
                    Ac.GIO_HANGs = update_cart(
                        Ac.GIO_HANGs,
                        cart_s
                    );
                    dt.SubmitChanges();
                    Session["cart_s"] = null;
                }

                List<PayProducts> payProducts = (List<PayProducts>)Session["pay_product"];
                if (payProducts != null)
                {
                    return Redirect("/cart/pay");
                }

                return Redirect(Session["Page"] != null ? Session["Page"].ToString() : "~/Home");
            }
            ViewBag.Err_log = "Sai tên tài khoản hoặc mật khẩu !";
            return View();
        }

        private EntitySet<GIO_HANG> update_cart(EntitySet<GIO_HANG> user_cart, List<GIO_HANG> carts_temp)
        {
            foreach(GIO_HANG c in carts_temp)
            {
                GIO_HANG ca = user_cart.Where(i => i.SAN_PHAM_ID == c.SAN_PHAM_ID).FirstOrDefault();
                if (ca != null)
                {
                    ca.SO_LUONG += c.SO_LUONG;
                    continue;
                }

                ca = new GIO_HANG();
                ca.TEN_TAI_KHOAN = ((TAI_KHOAN)Session["User"]).TEN_TAI_KHOAN;
                ca.SAN_PHAM_ID = c.SAN_PHAM_ID;
                ca.SO_LUONG = c.SO_LUONG;
                user_cart.Add(ca);
            };
            return user_cart;
        }
    }
}
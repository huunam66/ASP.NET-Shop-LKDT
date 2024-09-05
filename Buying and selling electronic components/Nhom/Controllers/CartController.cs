using Nhom.App_Start;
using Nhom.Models.LINQ;
using Nhom.Models;
using Nhom.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            ViewBag.avt = Maker.get_avt();
            ViewBag.cart_size = Maker.cart_size();

            if (Session["pay_product"] != null) Session["pay_product"] = null;

            ViewBag.not_cat = true;

            List<HINH_ANH> aSSESTs = new List<HINH_ANH>();
            List<String> price_format = new List<String>();
            List<String> price_total = new List<String>();
            List<GIO_HANG> cARTs = new List<GIO_HANG>();
            decimal total = 0;
            int sum_count = 0;
            Data_Linh_KienDataContext data = new Data_Linh_KienDataContext();
            if (Session["User"] == null)
            {
                cARTs = (List<GIO_HANG>)Session["cart_s"];
                if (cARTs == null) cARTs = new List<GIO_HANG>();
            }
            else
            {
                TAI_KHOAN ac = (TAI_KHOAN)Session["User"];
                cARTs = data.GIO_HANGs.Where(item => item.TEN_TAI_KHOAN.Equals(ac.TEN_TAI_KHOAN)).ToList(); 
            }
            if (cARTs != null && cARTs.Count > 0)
            {
                cARTs.ForEach(item =>
                {
                    if(item.SAN_PHAM == null)
                        item.SAN_PHAM = data.SAN_PHAMs.Where(i => i.ID == item.SAN_PHAM_ID).FirstOrDefault();
                    aSSESTs.Add(item.SAN_PHAM.HINH_ANHs[0]);
                    price_format.Add(Maker.Format_Price((decimal)item.SAN_PHAM.GIA));
                    price_total.Add(Maker.Format_Price((decimal)(item.SAN_PHAM.GIA * item.SO_LUONG)));
                    total += (decimal)(item.SAN_PHAM.GIA * item.SO_LUONG);
                    sum_count += (int)item.SO_LUONG;
                });
            }
            ViewBag.price_format = price_format;
            ViewBag.price_total = price_total;
            ViewBag.assests = aSSESTs;
            ViewBag.total = Maker.Format_Price(total);
            ViewBag.sum_count = sum_count;
            return View(cARTs);
        }


        public ActionResult pay()
        {
            ViewBag.avt = Maker.get_avt();
            ViewBag.cart_size = Maker.cart_size();
            
            if (Session["pay_product"] == null) return Redirect("/cart");

            if (Session["User"] == null) return Redirect("/login");

            ViewBag.not_cat = true;

            List<PayProducts> pay_products_s = (List<PayProducts>)Session["pay_product"];
            List<HINH_ANH> aSSESTs = new List<HINH_ANH>();
            List<String> price_format = new List<String>();
            List<String> price_total = new List<String>();
            decimal total = 0;
            int sum_count = 0;
            List<GIO_HANG> cARTs = new List<GIO_HANG>();
            Data_Linh_KienDataContext data = new Data_Linh_KienDataContext();
            pay_products_s.ForEach(item =>
            {
                GIO_HANG c = new GIO_HANG();
                SAN_PHAM pr = data.SAN_PHAMs.Where(i => i.ID == item.product_id).FirstOrDefault();
                c.SAN_PHAM = pr;
                c.SO_LUONG = item.product_count;             
                cARTs.Add(c);
                aSSESTs.Add(pr.HINH_ANHs[0]);
                price_format.Add(Maker.Format_Price((decimal)pr.GIA));
                price_total.Add(Maker.Format_Price((decimal)(pr.GIA * item.product_count)));
                total += (decimal)(pr.GIA * item.product_count);
                sum_count += (int)item.product_count;
            });
            ViewBag.price_format = price_format;
            ViewBag.price_total = price_total;
            ViewBag.assests = aSSESTs;
            ViewBag.total = Maker.Format_Price(total);
            ViewBag.sum_count = sum_count;
            return View(cARTs);
        }
    }
}
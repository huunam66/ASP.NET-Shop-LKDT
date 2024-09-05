using Nhom.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom.Models.LINQ;

namespace Nhom.Controllers
{
    public class OrderController : Controller
    {
        // GET: order
        private const int limit = 8;
        public ActionResult Index(int type = 0, int page = 1, int sp = 0)
        {
            if (Session["User"] == null) return Redirect("/home");

            ViewBag.not_cat = true;

            ViewBag.avt = Maker.get_avt();
            ViewBag.cart_size = Maker.cart_size();

            Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
            TAI_KHOAN ac = (TAI_KHOAN)Session["User"];
            List<DON_HANG> bils = new List<DON_HANG>();

            if (type == 0)
            {
                bils = dt.TAI_KHOANs.Where(item => item.TEN_TAI_KHOAN.Equals(ac.TEN_TAI_KHOAN))
                    .FirstOrDefault().DON_HANGs.ToList();
                ViewBag.count_chuaduyet = bils.Where(item => item.TRANG_THAI.ToLower().Equals("đang duyệt")).Count();
            }
            if(type == 1)
            {
                bils = dt.TAI_KHOANs.Where(item => item.TEN_TAI_KHOAN.Equals(ac.TEN_TAI_KHOAN))
                    .FirstOrDefault().DON_HANGs.Where(item => item.TRANG_THAI.ToLower().Equals("đang duyệt")).OrderByDescending(item => item.NGAY_DAT_HANG).ToList();
            }
            if (type == 2)
            {
                bils = dt.TAI_KHOANs.Where(item => item.TEN_TAI_KHOAN.Equals(ac.TEN_TAI_KHOAN))
                    .FirstOrDefault().DON_HANGs.Where(item => item.TRANG_THAI.ToLower().Equals("đã duyệt")).OrderByDescending(item => item.NGAY_DUYET).ToList();
            }
            if (type == 3)
            {
                bils = dt.TAI_KHOANs.Where(item => item.TEN_TAI_KHOAN.Equals(ac.TEN_TAI_KHOAN))
                    .FirstOrDefault().DON_HANGs.Where(item => item.TRANG_THAI.ToLower().Equals("đã hủy")).OrderByDescending(item => item.NGAY_HUY).ToList();
            }

            ViewBag.count_bill = bils.Count;

            float pages = Maker.Get_Count_Page(bils.Count, limit);

            if (sp > 0)
            {
                if(sp == 1) bils = bils.OrderBy(item => item.TONG_TIEN).Skip((page - 1) * limit).Take(limit).ToList();
                if(sp == 2) bils = bils.OrderByDescending(item => item.TONG_TIEN).Skip((page - 1) * limit).Take(limit).ToList();
            }
            else
            {
                bils = bils.OrderByDescending(item => item.ID).Skip((page - 1) * limit).Take(limit).ToList();
            }

            List<String> Format_Prices = new List<string>();
            bils.ForEach(item =>
            {
                Format_Prices.Add(
                    Maker.Format_Price((decimal)item.TONG_TIEN)
                );
            });

            ViewBag.sp = sp;
            ViewBag.type = type;
            ViewBag.page = page;
            ViewBag.pages = pages;
            ViewBag.format_prices = Format_Prices;

            return View(bils);
        }


        public ActionResult Detail(long id)
        {
            if (Session["User"] == null) return Redirect("/home");

            ViewBag.not_cat = true;

            ViewBag.avt = Maker.get_avt();
            ViewBag.cart_size = Maker.cart_size();
            Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
            TAI_KHOAN ac = (TAI_KHOAN)Session["User"];

            ac = dt.TAI_KHOANs.Where(item => item.TEN_TAI_KHOAN.Equals(ac.TEN_TAI_KHOAN)).FirstOrDefault();
            DON_HANG bill = ac.DON_HANGs.Where(item => item.ID == id).FirstOrDefault();
            ViewBag.bill_infor = bill.THONG_TIN_DON_HANG;
            List<CHI_TIET_DON_HANG> bILL_DETAILs = bill.CHI_TIET_DON_HANGs.ToList();
            ViewBag.bill_details = bILL_DETAILs;
            int sum_prod = bill.CHI_TIET_DON_HANGs.Sum(item => item.SO_LUONG).Value;
            decimal total = bill.CHI_TIET_DON_HANGs.Sum(item => item.SO_LUONG * item.GIA).Value;
            ViewBag.sum_prod = sum_prod;
            ViewBag.total = Maker.Format_Price(total);
            List<String> format_price = new List<string>();
            List<String> format_total_price = new List<string>();
            bILL_DETAILs.ForEach(item =>
            {
                format_price.Add(Maker.Format_Price((decimal)item.GIA));
                format_total_price.Add(Maker.Format_Price((decimal)(item.GIA * item.SO_LUONG)));
            });
            ViewBag.format_price = format_price;
            ViewBag.format_total_price = format_total_price;
            return View(bill);
        }
    }
}
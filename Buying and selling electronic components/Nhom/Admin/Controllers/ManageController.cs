﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom.Models;
using Nhom.Support;
using Nhom.Models.LINQ;

namespace Nhom.Admin
{
    public class ManageController : Controller
    {
        // GET: Manage
        private const int limit = 8;

        public ActionResult Customer(int page = 1)
        {
            Data_Linh_KienDataContext data = new Data_Linh_KienDataContext();
            List<THONG_TIN_TAI_KHOAN> kh = data.THONG_TIN_TAI_KHOANs.Where(item => !item.TAI_KHOAN.QUYEN_HAN.ToLower().Equals("admin")).ToList();
            ViewBag.pages = Maker.Get_Count_Page(kh.Count, limit);
            ViewBag.page = page;
            kh = kh.Skip(limit * (page - 1)).Take(limit).ToList();
            return View(kh);
        }

        public ActionResult Customer_Detail(long id)
        {
            Data_Linh_KienDataContext data = new Data_Linh_KienDataContext();
            THONG_TIN_TAI_KHOAN kh = data.THONG_TIN_TAI_KHOANs.Where(item => item.ID == id).FirstOrDefault();
            ViewBag.count_bill = data.DON_HANGs.Where(item => item.TAI_KHOAN.THONG_TIN_TAI_KHOANs.First().ID == id).ToList().Count;
            ViewBag.count_sanpham = data.DON_HANGs.Sum(item => item.CHI_TIET_DON_HANGs.Sum(i => i.SO_LUONG)).Value;
            ViewBag.count_giatri = Maker.Format_Price(data.DON_HANGs.Sum(item => item.TONG_TIEN).Value);
            return View(kh);
        }



        // SAN_PHAM *****************************

        public ActionResult Product(int page = 1, int typing = 0)
        {
            if (Session["User"] == null || ((TAI_KHOAN)Session["User"]).QUYEN_HAN.ToUpper().Equals("user".ToUpper()))
                return Redirect(Session["Page"] != null ? Session["Page"].ToString() : "~/Home");
            ViewBag.not_cat = true;
            Session["page_return_before_del"] = "/Manage/Product?page=" + page + "&typing=" + typing; 
            int show = limit * (page - 1);

            Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
            List<SAN_PHAM> p = new List<SAN_PHAM>();

            if (typing == 0) p = dt.SAN_PHAMs.ToList();
            else p = dt.SAN_PHAMs.Where(item => item.LOAI_SP_ID == typing).ToList();

            float count_page = Maker.Get_Count_Page(p.Count, limit);
            p = p.Skip((page - 1) * limit).Take(limit).ToList();
            ViewBag.type_list = dt.LOAI_SAN_PHAMs.ToList();
            ViewBag.typing = typing;
            ViewBag.page = page;
            ViewBag.pages = count_page;
            List<String> assest = new List<string>();
            List<String> prices = new List<String>();
            foreach(SAN_PHAM pr in p)
            {
                prices.Add(Maker.Format_Price((decimal)pr.GIA));
                assest.Add(
                    pr.HINH_ANHs.Count > 0
                    ? pr.HINH_ANHs.ElementAt(0).THU_MUC + "/" + pr.HINH_ANHs.ElementAt(0).TEN_FILE
                    : null
                );
            }
            ViewBag.prices = prices;
            ViewBag.pics = assest;
            ViewBag.ASSESTS = dt.HINH_ANHs.Where(item => item.SAN_PHAM.LOAI_SP_ID == typing).ToList();
            return View(p);
        }

        public ActionResult More_Product()
        {
            if (Session["User"] == null || ((TAI_KHOAN)Session["User"]).QUYEN_HAN.ToUpper().Equals("user".ToUpper()))
                return Redirect(Session["Page"] != null ? Session["Page"].ToString() : "~/Home");
            ViewBag.not_cat = true;

            Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
            return View(dt.LOAI_SAN_PHAMs.ToList());
        }

        public ActionResult Fix_Product(long id)
        {
            if (Session["User"] == null || ((TAI_KHOAN)Session["User"]).QUYEN_HAN.ToUpper().Equals("user".ToUpper()))
                return Redirect(Session["Page"] != null ? Session["Page"].ToString() : "~/Home");
            ViewBag.not_cat = true;
            Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
            SAN_PHAM p = dt.SAN_PHAMs.Where(item => item.ID == id).FirstOrDefault();
            ViewBag.type_list = dt.LOAI_SAN_PHAMs.ToList();
            ViewBag.assest = p.HINH_ANHs.ToList();
            ViewBag.details = p.CHI_TIET_SAN_PHAMs.ToList();
            return View(p);
        }


        public ActionResult Order(int type = 0, int page = 1, int sp = 0)
        {
            if (Session["User"] == null || ((TAI_KHOAN)Session["User"]).QUYEN_HAN.ToUpper().Equals("user".ToUpper()))
                return Redirect(Session["Page"] != null ? Session["Page"].ToString() : "~/Home");
            if (Session["User"] == null) return Redirect("/home");

            ViewBag.not_cat = true;

            ViewBag.avt = Maker.get_avt();
            ViewBag.cart_size = Maker.cart_size();

            Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
            List<DON_HANG> bils = dt.DON_HANGs.OrderByDescending(item => item.ID).ToList();

            if (type == 0)
            {
                ViewBag.count_chuaduyet = bils.Where(item => item.TRANG_THAI.ToLower().Equals("đang duyệt")).Count();
            }
            if (type == 1)
            {
                bils = bils.Where(item => item.TRANG_THAI.ToLower().Equals("đang duyệt")).ToList();
                if (sp == 3) bils = bils.OrderBy(item => item.NGAY_DAT_HANG).ToList();
                if (sp == 4) bils = bils.OrderByDescending(item => item.NGAY_DAT_HANG).ToList();
            }
            if (type == 2)
            {
                bils = bils.Where(item => item.TRANG_THAI.ToLower().Equals("đã duyệt")).ToList();
                if (sp == 3) bils = bils.OrderBy(item => item.NGAY_DUYET).ToList();
                if (sp == 4) bils = bils.OrderByDescending(item => item.NGAY_DUYET).ToList();
            }
            if (type == 3)
            {
                bils = bils.Where(item => item.TRANG_THAI.ToLower().Equals("đã hủy")).ToList();
                if (sp == 3) bils = bils.OrderBy(item => item.NGAY_HUY).ToList();
                if (sp == 4) bils = bils.OrderByDescending(item => item.NGAY_HUY).ToList();
            }

            ViewBag.count_bill = bils.Count;

            float pages = Maker.Get_Count_Page(bils.Count, limit);

            if (sp > 0)
            {
                if (sp == 1) bils = bils.OrderBy(item => item.TONG_TIEN).Skip((page - 1) * limit).Take(limit).ToList();
                if (sp == 2) bils = bils.OrderByDescending(item => item.TONG_TIEN).Skip((page - 1) * limit).Take(limit).ToList();
            }
            else
            {
                bils = bils.Skip((page - 1) * limit).Take(limit).ToList();
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


        public ActionResult Order_Detail(long id)
        {
            if (Session["User"] == null) return Redirect("/home");

            ViewBag.not_cat = true;

            ViewBag.avt = Maker.get_avt();
            ViewBag.cart_size = Maker.cart_size();
            Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();

            DON_HANG bill = dt.DON_HANGs.Where(item => item.ID == id).FirstOrDefault();
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
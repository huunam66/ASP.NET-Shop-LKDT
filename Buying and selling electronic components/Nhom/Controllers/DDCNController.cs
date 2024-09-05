using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom.Models.LINQ;
using Nhom.Support;

namespace Nhom.Controllers
{
    public class DDCNController : Controller
    {
        // GET: DDCN
        private const int limit = 15;
        public ActionResult Index(int page = 1, String type = "", decimal mod = 0)
        {
            ViewBag.avt = Maker.get_avt();
            ViewBag.cart_size = Maker.cart_size();

            Session["Page"] = "~/Product";
            Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
            long Product_Type_ID = dt.LOAI_SAN_PHAMs.Where(item => item.TEN.Equals("Điện dân dụng và Công nghiệp")).FirstOrDefault().ID;
            List<SAN_PHAM> prods = dt.SAN_PHAMs.Where(item => item.LOAI_SP_ID == Product_Type_ID).ToList();
            decimal price_max = (decimal)prods.Max(item => item.GIA);
            decimal price_min = (decimal)prods.Min(item => item.GIA);
            decimal minus_min = price_max - price_min;
            decimal price_mid = minus_min / 2 + price_min;
            decimal fm_price_max = decimal.Parse(Maker.Format_Price(price_max).Split('.')[0]);
            decimal fm_price_min = decimal.Parse(Maker.Format_Price(price_min).Split('.')[0]);
            if (mod != 0)
            {
                if (mod == fm_price_min)
                    prods = prods.Where(item => item.GIA >= price_min && item.GIA <= price_mid).ToList();
                else
                    prods = prods.Where(item => item.GIA >= price_mid && item.GIA <= price_max).ToList();
            }

            if (!type.Equals(""))
            {
                if (type.Trim().Equals("low"))
                    prods = prods.ToList().OrderByDescending(item => item.GIA).ToList();
                else
                    prods = prods.ToList().OrderBy(item => item.GIA).ToList();
            }

            float pages = Maker.Get_Count_Page(prods.Count, limit);
            prods = prods.Skip((page - 1) * limit).Take(limit).ToList();

            List<String> pic = new List<String>();
            List<String> Format_Prices = new List<string>();
            prods.ForEach(item =>
            {
                Format_Prices.Add(
                    Maker.Format_Price((decimal)item.GIA)
                );
                HINH_ANH assest = item.HINH_ANHs.FirstOrDefault();
                pic.Add(
                    assest != null
                    ? assest.THU_MUC + "/" + assest.TEN_FILE
                    : null
                );
            });

            String fm_price_max_text = Maker.Format_Price(price_max);
            String fm_price_min_text = Maker.Format_Price(price_min);

            ViewBag.mod_text = "Tất cả";
            if (mod == fm_price_max) ViewBag.mod_text = "Từ " + fm_price_min_text + " đến " + fm_price_max_text;
            if (mod == fm_price_min) ViewBag.mod_text = "Từ " + fm_price_max_text + " đến " + fm_price_min_text;

            ViewBag.type_show = "Mặc định";
            if (type.Equals("high")) ViewBag.type_show = "Giá thấp đến cao";
            if (type.Equals("low")) ViewBag.type_show = "Giá cao đến thấp";

            ViewBag.price_max = fm_price_max_text;
            ViewBag.price_min = fm_price_min_text;
            ViewBag.price_mid = Maker.Format_Price(price_mid);
            ViewBag.mod = mod;
            ViewBag.type = type;
            ViewBag.page = page;
            ViewBag.pages = pages;
            ViewBag.pic = pic;
            ViewBag.Formart_Prices = Format_Prices;
            return View(prods);
        }
    }
}
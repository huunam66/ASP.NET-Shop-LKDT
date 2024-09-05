using Newtonsoft.Json;
using Nhom.Models.LINQ;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Nhom.Support
{
    public class Maker
    {
        public static String Format_Price(decimal price)
        {
            String left_price = price.ToString().Contains('.') ? price.ToString().Split('.')[0] : price.ToString();
            int len = left_price.Length;
            int jump = 0;
            for (int i = len - 1; i >= 0; i--)
            {
                if (jump % 2 == 0 && jump != 0 && i != 0)
                {
                    left_price = left_price.Substring(0, i) + "." + left_price.Substring(i);
                    i--;
                }
                jump++;
            }
            return left_price;
        }

        public static float Get_Count_Page(int size_list, int limit)
        {
            float value = (float)size_list / limit;
            if (value > (int)value)
                return (int)value + 1;
            return value;
        }

        public static String Upload_Image(HttpPostedFileBase f)
        {
            if (f == null || f.FileName.Equals("")) return null;

            HttpServerUtility HttpContext_Server = System.Web.HttpContext.Current.Server;
            String Path_save = Path.Combine(HttpContext_Server.MapPath("~/Content/img/" + Maker.get_cookie("folder") + "/" + f.FileName));
            if (!File.Exists(Path_save))
            {
                f.SaveAs(Path_save);
            }
            return f.FileName;
        }
        public static String Upload_Image(String folder, HttpPostedFileBase f)
        {
            if (f == null || f.FileName.Equals("")) return null;

            HttpServerUtility HttpContext_Server = System.Web.HttpContext.Current.Server;
            String Path_save = Path.Combine(HttpContext_Server.MapPath("~/Content/img/" + folder + "/" + f.FileName));
            if (!File.Exists(Path_save))
            {
                f.SaveAs(Path_save);
            }
            return f.FileName;
        }

        public static Boolean Move_File(String old_folder, String new_folder, String old_file, String new_file)
        {
            try
            {
                HttpServerUtility HttpContext_Server = System.Web.HttpContext.Current.Server;
                String Path_old = Path.Combine(HttpContext_Server.MapPath("~/Content/img/" + old_folder + "/" + old_file));
                String Path_new = Path.Combine(HttpContext_Server.MapPath("~/Content/img/" + new_folder + "/" + new_file));
                File.Copy(Path_old, Path_new, true);
                return true;
            }
            catch (Exception) { return false; }
        }

        public static int cart_size()
        {
            HttpSessionState session = System.Web.HttpContext.Current.Session;
            TAI_KHOAN ac = (TAI_KHOAN)session["User"];
            if (ac == null)
            {
                List<GIO_HANG> cart_s = (List<GIO_HANG>)session["cart_s"];
                if (cart_s == null) cart_s = new List<GIO_HANG>();
                return cart_s.Sum(item => item.SO_LUONG).Value;
            }

            Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
            return dt.TAI_KHOANs.Where(item => item.TEN_TAI_KHOAN.Equals(ac.TEN_TAI_KHOAN)).FirstOrDefault().GIO_HANGs.Sum(item => item.SO_LUONG).Value;
        }

        public static String get_avt()
        {
            HttpSessionState session = System.Web.HttpContext.Current.Session;
            TAI_KHOAN ac = (TAI_KHOAN)session["User"];
            if (ac == null) return null;
            Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
            List<THONG_TIN_TAI_KHOAN> l_ab = dt.TAI_KHOANs.Where(item => item.TEN_TAI_KHOAN.Equals(ac.TEN_TAI_KHOAN)).FirstOrDefault().THONG_TIN_TAI_KHOANs.ToList();
            if (l_ab.Count < 1) return null;

            return l_ab.First().ANH_DAI_DIEN;
        }

        public static void set_cookie(String name, String value)
        {
            HttpCookie httpCookie = HttpContext.Current.Request.Cookies[name];
            if(httpCookie != null)
            {
                httpCookie.Value = value;
                return;
            }

            httpCookie = new HttpCookie(name);
            httpCookie.Value = value;
            httpCookie.HttpOnly = true;
            httpCookie.Secure = true;
            httpCookie.Expires = new DateTime().AddYears(3000);
            HttpContext.Current.Response.Cookies.Add(httpCookie);
        }

        public static String get_cookie(String name)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            return cookie != null ? cookie.Value : null;
        }

        public static void del_cookie(String name)
        {
            HttpContext.Current.Response.Cookies.Remove(name);
        }

        public static JsonSerializerSettings jsonSerializerSettings()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return settings;
        }

        public static void user_exists_check()
        {
            HttpCookieCollection cookie = System.Web.HttpContext.Current.Request.Cookies;
            if (cookie["user"] == null) return;

            Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
            TAI_KHOAN ac = (TAI_KHOAN)dt.TAI_KHOANs.Where(item => item.TEN_TAI_KHOAN.Equals(cookie["user"])).FirstOrDefault();
            System.Web.HttpContext.Current.Session["User"] = ac;
        }
    }
}
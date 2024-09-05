using Nhom.App_Start;
using Nhom.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.avt = Maker.get_avt();
            ViewBag.cart_size = Maker.cart_size();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.avt = Maker.get_avt();
            ViewBag.cart_size = Maker.cart_size();
            ViewBag.Message = "Your application description page.";

            return View();
        }

    
        public ActionResult Logout()
        {
            if (Session["User"] != null)
            {
                HttpContext.Response.Cookies.Clear();
                Session["User"] = null;
            }
            return Redirect(Session["Page"] != null ? Session["Page"].ToString() : "~/Home");
        }
    }
}
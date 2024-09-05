using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Nhom.App_Start;
using Nhom.Controllers;
using Nhom.Models.LINQ;
using Nhom.Models;
using Nhom.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.Mvc;

namespace Nhom.Rest
{
    public class CartController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("load/api/pay")]
        public HttpResponseMessage load_api_pay(
            [System.Web.Http.FromBody] List<PayProducts> pay_Products)
            {
            if (pay_Products == null || pay_Products.Count < 1)
                return Request.CreateResponse(new { url = "/cart", error = "Chọn sản phẩm muốn đặt hàng !"});

            HttpSessionState session = System.Web.HttpContext.Current.Session;
            session["pay_product"] = pay_Products;
            return Request.CreateResponse(new { url = "/cart/pay" });
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("load/api/cart/checkout")]
        public HttpResponseMessage cart_checkout(
            [System.Web.Http.FromBody] Payment payment
            )
        {
            Exception ex = null;    
            try {
                HttpSessionState session = System.Web.HttpContext.Current.Session;
                TAI_KHOAN ac = (TAI_KHOAN)session["User"];
                Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
                ac = dt.TAI_KHOANs.Where(item => item.TEN_TAI_KHOAN.Equals(ac.TEN_TAI_KHOAN)).FirstOrDefault();
                DON_HANG bil = new DON_HANG();
                bil.TEN_TAI_KHOAN = ac.TEN_TAI_KHOAN;
                bil.NGAY_DAT_HANG = DateTime.Now;
                bil.TONG_SAN_PHAM = payment.products_cart.Sum(item => item.product_count);
                bil.TONG_TIEN = (decimal)payment.products_cart.Sum(item => item.product_count * (
                    dt.SAN_PHAMs.Where(i => i.ID == item.product_id).FirstOrDefault().GIA
                )).Value;
                bil.TRANG_THAI = "Đang duyệt";

                THONG_TIN_DON_HANG b_inf = new THONG_TIN_DON_HANG();
                b_inf.TEN = payment.bill_infor.first_name;
                b_inf.HO = payment.bill_infor.last_name;
                b_inf.SDT = payment.bill_infor.phone;
                b_inf.GIOI_TINH = payment.bill_infor.gender;
                b_inf.DIA_CHI = payment.bill_infor.address;
                b_inf.PHUONG_XA = payment.bill_infor.ward;
                b_inf.QUAN_HUYEN = payment.bill_infor.district;
                b_inf.TINH_THANH = payment.bill_infor.city;
                bil.THONG_TIN_DON_HANG = b_inf;

                payment.products_cart.ForEach(item =>
                {
                    CHI_TIET_DON_HANG detail = new CHI_TIET_DON_HANG();
                    SAN_PHAM pr = dt.SAN_PHAMs.Where(i => i.ID == item.product_id).FirstOrDefault();
                    detail.SAN_PHAM_ID = item.product_id;
                    detail.GIA = pr.GIA;
                    detail.SO_LUONG = item.product_count;
                    detail.TEN_SAN_PHAM = pr.TEN;
                    detail.MAU = pr.MAU;
                    detail.HINH_ANH = pr.HINH_ANHs[0].THU_MUC + "/" + pr.HINH_ANHs[0].TEN_FILE;
                    bil.CHI_TIET_DON_HANGs.Add(detail);
                });

                ac.DON_HANGs.Add(bil);
                dt.SubmitChanges();

                foreach(PayProducts pp in payment.products_cart)
                {
                    GIO_HANG c = ac.GIO_HANGs.Where(i => i.SAN_PHAM_ID == pp.product_id).FirstOrDefault();
                    if(c != null)
                    {
                        if(c.SO_LUONG > pp.product_count)
                        {
                            c.SO_LUONG -= pp.product_count;
                            continue;
                        }

                        ac.GIO_HANGs.Remove(c);
                    }
                };
                dt.SubmitChanges();

                session["pay_product"] = null;

                return Request.CreateResponse(new
                {
                    status = true,
                    content = "Đặt hàng thành công !",
                    url = "/order"
                });
            }
            catch (Exception e)
            {
                ex = e;
            }
            return Request.CreateResponse(new
            {
                status = false,
                content = "Đặt hàng thất bại !",
                error = ex.Message
            });
        }
        
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("load/api/cart/update/count")]
        public HttpResponseMessage load_api_update_count(
            [System.Web.Http.FromBody] PayProducts pay_prod
        )
        {
            Exception ex = null;
            try
            {
                HttpSessionState session = System.Web.HttpContext.Current.Session;
                TAI_KHOAN ac = (TAI_KHOAN)session["User"];
                if (ac == null)
                {
                    List<GIO_HANG> cARTs = (List<GIO_HANG>)session["cart_s"];
                    if (cARTs == null) cARTs = new List<GIO_HANG>();
                    GIO_HANG c = cARTs.Where(item => item.SAN_PHAM_ID == pay_prod.product_id).FirstOrDefault();
                    c.SO_LUONG = pay_prod.product_count;
                    session["cart_s"] = cARTs;
                }
                else
                {
                    Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
                    GIO_HANG c = dt.TAI_KHOANs.Where(item => item.TEN_TAI_KHOAN.Equals(ac.TEN_TAI_KHOAN))
                        .FirstOrDefault().GIO_HANGs.Where(item => item.SAN_PHAM_ID == pay_prod.product_id)
                        .FirstOrDefault();

                    if(c != null)
                    {
                        c.SO_LUONG = pay_prod.product_count;
                        dt.SubmitChanges();
                    }
                }

                return Request.CreateResponse(new
                {
                    status = true,
                    cart_size = Maker.cart_size()
                });
            }
            catch(Exception e)
            {
                ex = e;
            }
            return Request.CreateResponse(new
            {
                status = false,
                error = ex.Message,
                cart_size = Maker.cart_size()
            });
        }


        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("load/api/cart/del/{product_id}")]
        public HttpResponseMessage load_api_del(
            [System.Web.Http.FromUri] long product_id
        )
        {
            Exception ex = null;
            try
            {
                HttpSessionState session = System.Web.HttpContext.Current.Session;
                TAI_KHOAN ac = (TAI_KHOAN)session["User"];
                if (ac == null)
                {
                    List<GIO_HANG> cARTs = (List<GIO_HANG>)session["cart_s"];
                    if (cARTs == null) cARTs = new List<GIO_HANG>();
                    GIO_HANG ca = cARTs.Where(item => item.SAN_PHAM_ID == product_id).FirstOrDefault();
                    if (ca != null) cARTs.Remove(ca);
                    session["cart_s"] = cARTs;
                }
                else
                {
                    Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
                    GIO_HANG c = dt.GIO_HANGs.Where(item => item.TEN_TAI_KHOAN.Equals(ac.TEN_TAI_KHOAN) && item.SAN_PHAM_ID == product_id).FirstOrDefault();
                    dt.GIO_HANGs.DeleteOnSubmit(c);
                    dt.SubmitChanges();
                }
                return Request.CreateResponse(new
                {
                    status = true,
                    cart_size = Maker.cart_size()
                });
            }
            catch(Exception e)
            {
                ex = e;
            }

            return Request.CreateResponse(new
            {
                status = false,
                result = "Xóa thất bại !",
                error = ex.Message,
                cart_size = Maker.cart_size()
            });
        }


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("load/api/cart/add/{product_id}")]
        public HttpResponseMessage load_api_add(
             [System.Web.Http.FromUri] long product_id
        )
        {
            HttpSessionState session = System.Web.HttpContext.Current.Session;
            Exception ex = null;
            try
            {
                Data_Linh_KienDataContext data = new Data_Linh_KienDataContext();
                List<GIO_HANG> carts = new List<GIO_HANG>();

                TAI_KHOAN ac = (TAI_KHOAN)session["User"];
                if (ac == null)
                {
                    carts = (List<GIO_HANG>)session["cart_s"];
                    if (carts == null) carts = new List<GIO_HANG>();
                    carts = update_cart(carts, product_id);
                    session["cart_s"] = carts;
                }
                else
                {
                    ac = data.TAI_KHOANs.Where(item => item.TEN_TAI_KHOAN.Equals(ac.TEN_TAI_KHOAN)).FirstOrDefault();
                    carts = ac.GIO_HANGs.ToList();
                    carts = update_cart(carts, product_id);
                    ac.GIO_HANGs.Clear();
                    carts.ForEach(item =>
                    {
                        GIO_HANG c = new GIO_HANG();
                        c.SAN_PHAM_ID = item.SAN_PHAM_ID;
                        c.TEN_TAI_KHOAN = ac.TEN_TAI_KHOAN;
                        c.SO_LUONG = item.SO_LUONG;
                        ac.GIO_HANGs.Add(c);
                    });
                    data.SubmitChanges();
                }
                return Request.CreateResponse(
                        new
                        {
                            status = "Đã thêm vào giỏ !",
                            color = "#46ac4a",
                            gif = "/Content/img/sys/icons8-success.gif",
                            sta_tic = "/Content/img/sys/icons8-success-48.png",
                            http_status = "OK",
                            cart_size = Maker.cart_size()
                        });
            }
            catch (Exception e)
            {
                ex = e;
            }
            return Request.CreateResponse(
                  new
                  {
                      status = "Thêm vào giỏ thất bại !",
                      color = "red",
                      gif = "/Content/img/sys/icons8-error.gif",
                      sta_tic = "/Content/img/sys/icons8-error-48.png",
                      http_status = "OK",
                      error = ex.Message,
                      cart_size = Maker.cart_size()
                  });
        }

        private List<GIO_HANG> update_cart(List<GIO_HANG> cARTs, long id_product)
        {
            Data_Linh_KienDataContext data = new Data_Linh_KienDataContext();
            GIO_HANG c = cARTs.Where(item => item.SAN_PHAM_ID == id_product).FirstOrDefault();
            if (c != null)
            {
                c.SO_LUONG += 1;
            }
            else
            {
                c = new GIO_HANG();
                SAN_PHAM pr = data.SAN_PHAMs.Where(item => item.ID == id_product).FirstOrDefault();
                c.SAN_PHAM = pr;
                c.SO_LUONG = 1;
                c.SAN_PHAM_ID = pr.ID;
                cARTs.Add(c);
            }

            return cARTs;
        }
    }
}
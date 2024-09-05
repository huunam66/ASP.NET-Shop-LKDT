using Nhom.Models.LINQ;
using Nhom.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.SessionState;

namespace Nhom.Rest
{
    public class OrderController : ApiController
    {
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("load/api/order/cancel")]
        public HttpResponseMessage order_cancel(
            [System.Web.Http.FromBody] Dictionary<String, Object> request)
        {
            Exception ex = null;
            try
            {
                HttpSessionState session = System.Web.HttpContext.Current.Session;
                Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
                TAI_KHOAN ac = (TAI_KHOAN)session["User"];
                long bill_id = Convert.ToInt64(request["bill_id"]);
                DON_HANG bill = dt.TAI_KHOANs.Where(item => item.TEN_TAI_KHOAN.Equals(ac.TEN_TAI_KHOAN)).FirstOrDefault().DON_HANGs.Where(item => item.ID == bill_id).FirstOrDefault();
                bill.TRANG_THAI = "Đã hủy";
                bill.NGAY_HUY = DateTime.Now;

                dt.SubmitChanges();

                return Request.CreateResponse(new
                {
                    status = true,
                    content = "Hủy đơn thành công !",
                    url = "/order?type=3"
                });
            }
            catch (Exception e)
            {
                ex = e;
            }
            return Request.CreateResponse(new
            {
                status = false,
                content = "Hủy đơn thất bại !",
                error = ex.Message
            });
        }


        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("load/api/order/duyet")]
        public HttpResponseMessage order_duyet(
            [System.Web.Http.FromBody] Dictionary<String, Object> request)
        {
            Exception ex = null;
            try
            {
                Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
                long bill_id = Convert.ToInt64(request["bill_id"]);
                DON_HANG bill = dt.DON_HANGs.Where(item => item.ID == bill_id).FirstOrDefault();
                bill.TRANG_THAI = "Đã duyệt";
                bill.NGAY_DUYET = DateTime.Now;

                dt.SubmitChanges();

                return Request.CreateResponse(new
                {
                    status = true,
                    content = "Duyệt đơn thành công !",
                    url = "/manage/order?type=2"
                });
            }
            catch (Exception e)
            {
                ex = e;
            }
            return Request.CreateResponse(new
            {
                status = false,
                content = "Duyệt đơn thất bại !",
                error = ex.Message
            });
        }
    }
}

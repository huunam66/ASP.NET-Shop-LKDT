using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.SessionState;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nhom.Models.LINQ;
using Nhom.Models;
using Nhom.Support;

namespace Nhom.Rest
{
    public class ProductController : ApiController
    {

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("load/api/add-new-product")]
        public HttpResponseMessage Add_product(
            [System.Web.Http.FromBody] Product product)
        {
            if (product != null)
            {
                try
                {
                    HttpSessionState session = System.Web.HttpContext.Current.Session;
                    Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
                    SAN_PHAM p = new SAN_PHAM();
                    p.TRANG_THAI = product.Status;
                    p.TEN = product.Name;
                    p.GIA = product.Price;
                    p.MA_PHAN_LOAI = product.Code;
                    p.MAU = product.Attribute;
                    p.SO_LUONG = product.Count;
                    p.LOAI_SP_ID = product.ID_Type;
                    product.Product_Details.ForEach(item =>
                    {
                        p.CHI_TIET_SAN_PHAMs.Add(new CHI_TIET_SAN_PHAM()
                        {
                            TIEU_DE = item.Title,
                            NOI_DUNG = item.Content
                        });
                    });

                    dt.SAN_PHAMs.InsertOnSubmit(p);
                    dt.SubmitChanges();
                    session["ID_SS"] = p.ID.ToString();
                    String type = dt.LOAI_SAN_PHAMs.Where(item => item.ID == product.ID_Type).FirstOrDefault().TEN;
                    if (type.Equals("Cảm biến")) session["FOLDER"] = "cambien";
                    else if (type.Equals("Mạch (Board)")) session["FOLDER"] = "mach";
                    else if (type.Equals("Đèn LED, Điều khiển LED")) session["FOLDER"] = "led";
                    else session["FOLDER"] = "dien";
                    return Request.CreateResponse(new { Status = "Success", Content = "Thay đổi dữ liệu sản phẩm thành công !" });
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(new { Status = "Fail", Content = "Thay đổi dữ liệu sản phẩm thất bại !" });
                }
            }
            return Request.CreateResponse(new { Status = "Fail", Content = "Thay đổi dữ liệu sản phẩm thất bại !" });
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("load/api/fix-product")]
        public HttpResponseMessage Fix_product(
            [System.Web.Http.FromBody] Product product)
        {
            if (product != null)
            {
                try
                {
                    HttpSessionState session = System.Web.HttpContext.Current.Session;
                    Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
                    SAN_PHAM p = dt.SAN_PHAMs.Where(item => item.ID == product.ID).FirstOrDefault();
                    String type = dt.LOAI_SAN_PHAMs.Where(item => item.ID == p.LOAI_SP_ID).FirstOrDefault().TEN;
                    if (type.Equals("Cảm biến")) session["old_folder"] = "cambien";
                    else if (type.Equals("Mạch (Board)")) session["old_folder"] = "mach";
                    else if (type.Equals("Đèn LED, Điều khiển LED")) session["old_folder"] = "led";
                    else session["old_folder"] = "dien";
                    if(p != null)
                    {
                        p.TRANG_THAI = product.Status;
                        p.TEN = product.Name;
                        p.GIA = product.Price;
                        p.MA_PHAN_LOAI = product.Code;
                        p.MAU = product.Attribute;
                        p.SO_LUONG = product.Count;
                        p.LOAI_SP_ID = product.ID_Type;
                        p.CHI_TIET_SAN_PHAMs.Clear();
                        product.Product_Details.ForEach(item =>
                        {
                            p.CHI_TIET_SAN_PHAMs.Add(new CHI_TIET_SAN_PHAM()
                            {
                                TIEU_DE = item.Title,
                                NOI_DUNG = item.Content
                            });
                        });
                        dt.SubmitChanges();
                        session["ID_SS"] = p.ID.ToString();
                         type = dt.LOAI_SAN_PHAMs.Where(item => item.ID == product.ID_Type).FirstOrDefault().TEN;
                        if (type.Equals("Cảm biến")) session["FOLDER"] = "cambien";
                        else if (type.Equals("Mạch (Board)")) session["FOLDER"] = "mach";
                        else if (type.Equals("Đèn LED, Điều khiển LED")) session["FOLDER"] = "led";
                        else session["FOLDER"] = "dien";
                        return Request.CreateResponse(new { Status = "Success", Content = "Thay đổi dữ liệu sản phẩm thành công !" });
                    }
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(new { Status = "Fail", Content = "Thay đổi dữ liệu sản phẩm thất bại !" });
                }
            }
            return Request.CreateResponse(new { Status = "Fail", Content = "Thay đổi dữ liệu sản phẩm thất bại !" });
        }


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("load/api/type-update-product")]
        public HttpResponseMessage type_update_product(String type)
        {
            HttpSessionState session = System.Web.HttpContext.Current.Session;
            session["type_update_product"] = type;
            return Request.CreateResponse();
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("load/api/add-files-img")]
        public HttpResponseMessage Save_File()
        {
            try
                {
                HttpSessionState session = System.Web.HttpContext.Current.Session;
                HttpFileCollection files_context = System.Web.HttpContext.Current.Request.Files;
                int len = files_context.Count;
                if(len > 0)
                {
                    Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
                    SAN_PHAM p = dt.SAN_PHAMs.Where(item => item.ID == Convert.ToInt64(session["ID_SS"])).FirstOrDefault();
                    p.HINH_ANHs.Clear();
                    if(session["type_update_product"].ToString() == "add")
                    {
                        for (int i = 0; i < len; i++)
                        {
                            HttpPostedFile pic = files_context["file_" + i];
                            HttpPostedFileBase f = new HttpPostedFileWrapper(pic);

                            Maker.Upload_Image(session["FOLDER"].ToString(), f);

                            p.HINH_ANHs.Add(new HINH_ANH()
                            {
                                SAN_PHAM_ID = p.ID,
                                THU_MUC = session["FOLDER"].ToString().Trim(),
                                TEN_FILE = f.FileName.Trim()
                            });
                        }
                    }
                    else
                    {
                        for (int i = 0; i < len; i++)
                        {
                            HttpPostedFile pic = files_context["file_" + i];
                            HttpPostedFileBase f = new HttpPostedFileWrapper(pic);
                            if(f != null)
                            {
                                Boolean move_file = Maker.Move_File(session["old_folder"].ToString(), session["FOLDER"].ToString(), f.FileName, f.FileName);
                                if (!move_file) Maker.Upload_Image(session["FOLDER"].ToString(), f);
                                p.HINH_ANHs.Add(new HINH_ANH()
                                {
                                    SAN_PHAM_ID = p.ID,
                                    THU_MUC = session["FOLDER"].ToString().Trim(),
                                    TEN_FILE = f.FileName.Trim()
                                });
                            }
                        }
                        session["old_folder"] = null;
                    }

                    dt.SubmitChanges();
                    return Request.CreateResponse(new { Status = "Success", Content = "Thay đổi dữ liệu sản phẩm thành công !<br>Thay đổi dữ liệu hình ảnh thành công !" });
                }
                else
                {
                    Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
                    dt.SAN_PHAMs.Where(item => item.ID == Convert.ToInt64(session["ID_SS"])).FirstOrDefault().HINH_ANHs.Clear();
                    dt.SubmitChanges();
                    return Request.CreateResponse(new { Status = "Success", Content = "Thay đổi dữ liệu sản phẩm thành công !<br>Thay đổi dữ liệu hình ảnh thành công !" });
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(new { Status = "Fail", Content = "Thay đổi dữ liệu sản phẩm thành công !<br>Thay đổi dữ liệu hình ảnh thất bại !"});
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("load/api/search/admin/product")]
        public HttpResponseMessage Search_Product(
            [System.Web.Http.FromBody] SearchProductAdmin spa
        ){
            if (!spa.content.Equals(""))
            {
                try
                {
                    Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
                    List<SAN_PHAM> pr = new List<SAN_PHAM>();
                    if (spa.type == 0)
                    {
                        pr = dt.SAN_PHAMs.Where(
                        item => item.TEN.ToUpper().Contains(spa.content.ToUpper())
                        ).ToList();
                    }
                    else
                    {
                        pr = dt.SAN_PHAMs.Where(
                            item => item.TEN.ToUpper().Contains(spa.content.ToUpper()) 
                            && item.LOAI_SP_ID == spa.type
                        ).ToList();
                    }
                    if(pr != null)
                    {
                        List<Product> result = new List<Product>();
                        pr.ForEach(item =>
                        {
                            List<ProductDetails> product_Details = new List<ProductDetails>();
                            List<Assest> assests = new List<Assest>();
                            item.CHI_TIET_SAN_PHAMs.ToList().ForEach(pd =>
                            {
                                product_Details.Add(new ProductDetails()
                                {
                                    ID = pd.ID,
                                    ID_Product = pd.SAN_PHAM_ID,
                                    Title = pd.TIEU_DE,
                                    Content = pd.NOI_DUNG
                                });
                            });
                            item.HINH_ANHs.ToList().ForEach(a =>
                            {
                                assests.Add(new Assest()
                                {
                                    ID = a.ID,
                                    file_name = a.TEN_FILE,
                                    folder = a.THU_MUC
                                });
                            });
                            result.Add(new Product()
                            {
                                ID = item.ID,
                                Name = item.TEN,
                                Attribute = item.MAU,
                                Price = (decimal)item.GIA,
                                ID_Type = (long)item.LOAI_SP_ID,
                                Product_Type = item.LOAI_SAN_PHAM.TEN,
                                Status = item.TRANG_THAI,
                                Count = (int)item.SO_LUONG,
                                Code = item.MA_PHAN_LOAI,
                                Product_Details = product_Details,
                                Assests = assests
                            });
                        });
                        spa.result = result;
                    }
                }
                catch(Exception e)
                {
                    return Request.CreateResponse(new { result = spa});
                }
            }
            return Request.CreateResponse(new { result = spa }) ;
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("load/api/delete/product/admin/{ID}")]
        public HttpResponseMessage Delete_Product_Admin(
            [System.Web.Http.FromUri] long ID
        ){
            Data_Linh_KienDataContext dt = new Data_Linh_KienDataContext();
            SAN_PHAM p = dt.SAN_PHAMs.Where(item => item.ID == ID).FirstOrDefault();  
            if(p != null)
            {
                try
                {
                    String name = p.TEN;
                    dt.SAN_PHAMs.DeleteOnSubmit(p);
                    dt.SubmitChanges();
                    return Request.CreateResponse(new { Status = "Success", Content = "Xóa sản phẩm<br>" + name + " thành công !" });
                }
                catch(Exception e)
                {
                    return Request.CreateResponse(new { Status = "Fail", Content = "Xóa sản phẩm có mã " + ID + " thất bại !" });
                }
            }
            return Request.CreateResponse(new { Status = "Fail", Content = "Xóa sản phẩm có mã " + ID + " thất bại !"});
        }
    }
}

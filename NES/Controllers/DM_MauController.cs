using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modals.DAO;
using Modals.EF;
using NES.Common;


namespace NES.Controllers
{
    public class DM_MauController : BaseController
    {
        // GET: DM_LoaiPhieuKham
        public ActionResult Index()
        {
            var dao = new DM_Mau_Dao();
            var modal = dao.ListAll();
            return View(modal);
        }
        [HttpGet]
        public ActionResult GetDetails(int _id)
        {
            var dao = new DM_Mau_Dao();
            var modal = dao.ViewDetail(_id);
            return PartialView("~/Views/DM_Mau/GetDetails.cshtml", modal);
        }

        public JsonResult Create(string _TenDanhMucMau_Add)
        {
            string _error = "";
            bool _status = true;
            try
            {
                DM_Mau dmMau = new DM_Mau();
                var dao = new DM_Mau_Dao();
                if (dao.GetByTenDMMau(_TenDanhMucMau_Add) != null)
                {
                    _error = "Tên danh mục mẫu đã tồn tại";
                    _status = false;
                    return Json(new
                    {
                        status = _status,
                        error = _error
                    });
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                        string accountLogin = "";
                        if (session != null)
                        {
                            if (session.TaiKhoan != " ")
                            {
                                accountLogin = session.TaiKhoan;
                            }
                        }
                        dmMau.TenDanhMucMau = _TenDanhMucMau_Add;
                        dmMau.TrangThai = 1;
                        dmMau.NgayTao = DateTime.Now;
                        dmMau.NguoiTao = accountLogin;
                        dmMau.NgayCapNhat = DateTime.Now;
                        dmMau.NguoiCapNhat = accountLogin;
                        var result = dao.Insert(dmMau);
                        if (result > 0)
                        {
                            _status = true;
                        }
                        else
                        {
                            _status = false;
                            _error = "Lỗi cập nhật dữ liêu";
                        }
                        return Json(new
                        {
                            status = _status,
                            error = _error
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                _error = ex.ToString();
                return Json(new
                {
                    status = false,
                    error = _error
                });
            }
            return Json(new
            {
                status = _status,
                error = _error
            });
        }
        
        public JsonResult Update(int _ID_Edit, string _TenDanhMucMau_Edit)
        {
            string _error = "";
            bool _status = true;
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            try
            {
                DM_Mau dmMau = new DM_Mau();
                var dao = new DM_Mau_Dao();
                if (dao.GetByTenDMMau(_TenDanhMucMau_Edit) != null)
                {
                    _error = "Tên danh mục mẫu đã tồn tại";
                    _status = false;
                    return Json(new
                    {
                        status = _status,
                        error = _error
                    });
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        int result = dao.Update(_ID_Edit, _TenDanhMucMau_Edit, session.TaiKhoan, DateTime.Now);
                        if (result > 0)
                        {
                            _status = true;
                        }
                        else
                        {
                            _status = false;
                            _error = "Lỗi cập nhật dữ liêu";
                        }
                        return Json(new
                        {
                            status = _status,
                            error = _error
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                _error = ex.ToString();
                return Json(new
                {
                    status = false,
                    error = _error
                });
            }
            return Json(new
            {
                status = _status,
                error = _error
            });
        }

       

        public JsonResult Delete(int id)
        {
            string _error = "";
            bool _status = true;
            var dao = new DM_Mau_Dao();
            if (dao.Update_Status(id, 0) == 1)
            {
                return Json(new
                {
                    status = true,
                    error = _error
                });
            }
            else
            {
                _error = "Có lỗi khi xóa dữ liệu";
                return Json(new
                {
                    status = false,
                    error = _error
                });
            }
        }

       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modals.DAO;
using Modals.EF;

namespace NES.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Index()
        {
            var dao = new Account_Dao();
            var modal = dao.ListAll();
            return View(modal);
        }
        [HttpGet]
        public ActionResult GetDetails(string _id)
        {
            var dao = new Account_Dao();
            var modal = dao.ViewDetail(_id);
            return PartialView("~/Views/Account/GetDetails.cshtml", modal);
        }
        public JsonResult Create(string _TaiKhoan_Add, string _TenDayDu_Add, string _MatKhau_Add,
                string _LoaiUser_Add)
        {
            string _error = "";
            bool _status = true;
            try
            {
                int LoaiUser = 2;
                if (!string.IsNullOrEmpty(_LoaiUser_Add))
                    LoaiUser = int.Parse(_LoaiUser_Add);

                Account sys = new Account();
                var dao = new Account_Dao();
                if (dao.GetById(_TaiKhoan_Add) != null)
                {
                    _error = "Tài khoản đã tồn tại, vui lòng nhập tên tài khoản khác";
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
                        var encryptedMd5Pas = Encryptor.MD5Hash(_MatKhau_Add);
                        sys.TaiKhoan = _TaiKhoan_Add;
                        sys.TenDayDu = _TenDayDu_Add;
                        sys.LoaiUser = LoaiUser;
                        sys.MatKhau = encryptedMd5Pas;
                        sys.isActive = 1;
                        var result = dao.Insert(sys);
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
        public JsonResult Update(string _TaiKhoan_Edit, string _TenDayDu_Edit, string _LoaiUser_Edit)
        {
            string _error = "";
            bool _status = true;
            int LoaiUser = 2;
            if (!string.IsNullOrEmpty(_LoaiUser_Edit))
            {
                LoaiUser = int.Parse(_LoaiUser_Edit);
            }
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new Account_Dao();
                    int result = dao.Update(_TaiKhoan_Edit, _TenDayDu_Edit, LoaiUser);
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
        public JsonResult Delete(string TaiKhoan)
        {
            string _error = "";
            bool _status = true;
            var dao = new Account_Dao();
            if (dao.Delete(TaiKhoan) == 1)
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
        public JsonResult ResetPassword(string TaiKhoan)
        {
            string _error = "";
            bool _status = true;
            var dao = new Account_Dao();
            var MatKhau = Encryptor.MD5Hash("Abc@1234");
            if (dao.ResetPassword(TaiKhoan, MatKhau) == 1)
            {
                return Json(new
                {
                    status = true,
                    error = _error
                });
            }
            else
            {
                _error = "Lỗi khi reset mật khẩu";
                return Json(new
                {
                    status = false,
                    error = _error
                });
            }
        }

        public JsonResult Lock(string TaiKhoan)
        {
            string _error = "";
            bool _status = true;
            var dao = new Account_Dao();
            if (dao.Update_Status(TaiKhoan, 0) == 1)
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
        public JsonResult UnLock(string TaiKhoan)
        {
            string _error = "";
            bool _status = true;
            var dao = new Account_Dao();
            if (dao.Update_Status(TaiKhoan, 1) == 1)
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
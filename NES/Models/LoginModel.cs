using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NES.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập tài khoàn")]
        public string TaiKhoan { get; set; }

        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string MatKhau { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
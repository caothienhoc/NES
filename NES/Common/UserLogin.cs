using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NES
{
    [Serializable]
    public class UserLogin
    {
        public string TaiKhoan { get; set; }
        public int LoaiUser { get; set; }
        public string TenDayDu { get; set; }
        public string ID_Khoa { get; set; }
    }
}
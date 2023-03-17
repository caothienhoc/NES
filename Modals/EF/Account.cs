namespace Modals.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        [StringLength(20)]
        public string TaiKhoan { get; set; }

        [Required]
        [StringLength(100)]
        public string TenDayDu { get; set; }

        public int LoaiUser { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

        public int isActive { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayTao { get; set; }

        [StringLength(50)]
        public string NguoiTao { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayCapNhat { get; set; }

        [StringLength(50)]
        public string NguoiCapNhat { get; set; }
    }
}

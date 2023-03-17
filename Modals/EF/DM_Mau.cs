namespace Modals.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DM_Mau
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string TenDanhMucMau { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayTao { get; set; }

        [StringLength(50)]
        public string NguoiTao { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayCapNhat { get; set; }

        [StringLength(50)]
        public string NguoiCapNhat { get; set; }

        public int? TrangThai { get; set; }
    }
}

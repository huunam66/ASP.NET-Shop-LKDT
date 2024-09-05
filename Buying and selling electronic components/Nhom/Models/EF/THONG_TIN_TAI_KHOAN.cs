namespace Nhom.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class THONG_TIN_TAI_KHOAN
    {
        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TEN_TAI_KHOAN { get; set; }

        [Required]
        [StringLength(50)]
        public string TEN { get; set; }

        [Required]
        [StringLength(50)]
        public string HO { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }

        [StringLength(4)]
        public string GIOI_TINH { get; set; }

        [StringLength(50)]
        public string DIA_CHI { get; set; }

        [StringLength(50)]
        public string PHUONG_XA { get; set; }

        [StringLength(50)]
        public string QUAN_HUYEN { get; set; }

        [StringLength(50)]
        public string TINH_THANH { get; set; }

        [StringLength(200)]
        public string ANH_DAI_DIEN { get; set; }

        public virtual TAI_KHOAN TAI_KHOAN { get; set; }
    }
}

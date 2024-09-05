namespace Nhom.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class THONG_TIN_DON_HANG
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(50)]
        public string TEN { get; set; }

        [StringLength(50)]
        public string HO { get; set; }

        [StringLength(20)]
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

        public virtual DON_HANG DON_HANG { get; set; }
    }
}

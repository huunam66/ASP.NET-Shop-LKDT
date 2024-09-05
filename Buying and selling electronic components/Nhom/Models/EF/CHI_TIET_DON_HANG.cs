namespace Nhom.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CHI_TIET_DON_HANG
    {
        public long ID { get; set; }

        public long? DON_HANG_ID { get; set; }

        public long? SAN_PHAM_ID { get; set; }

        public decimal? GIA { get; set; }

        [StringLength(50)]
        public string MAU { get; set; }

        public int? SO_LUONG { get; set; }

        [StringLength(100)]
        public string TEN_SAN_PHAM { get; set; }

        [StringLength(200)]
        public string HINH_ANH { get; set; }

        public virtual DON_HANG DON_HANG { get; set; }

        public virtual SAN_PHAM SAN_PHAM { get; set; }
    }
}

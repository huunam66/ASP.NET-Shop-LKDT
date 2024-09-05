namespace Nhom.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GIO_HANG
    {
        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TEN_TAI_KHOAN { get; set; }

        public long SAN_PHAM_ID { get; set; }

        public int? SO_LUONG { get; set; }

        public virtual SAN_PHAM SAN_PHAM { get; set; }

        public virtual TAI_KHOAN TAI_KHOAN { get; set; }
    }
}

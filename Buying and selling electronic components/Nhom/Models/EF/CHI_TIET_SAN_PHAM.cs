namespace Nhom.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CHI_TIET_SAN_PHAM
    {
        public long ID { get; set; }

        public long SAN_PHAM_ID { get; set; }

        [StringLength(100)]
        public string TIEU_DE { get; set; }

        [StringLength(300)]
        public string NOI_DUNG { get; set; }

        public virtual SAN_PHAM SAN_PHAM { get; set; }
    }
}

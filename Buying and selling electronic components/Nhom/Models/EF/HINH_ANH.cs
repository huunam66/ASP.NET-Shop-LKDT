namespace Nhom.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HINH_ANH
    {
        public long ID { get; set; }

        public long? SAN_PHAM_ID { get; set; }

        [Required]
        [StringLength(555)]
        public string TEN_FILE { get; set; }

        [StringLength(50)]
        public string THU_MUC { get; set; }

        public virtual SAN_PHAM SAN_PHAM { get; set; }
    }
}

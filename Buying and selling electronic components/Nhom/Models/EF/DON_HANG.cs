namespace Nhom.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DON_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DON_HANG()
        {
            CHI_TIET_DON_HANG = new HashSet<CHI_TIET_DON_HANG>();
        }

        public long ID { get; set; }

        [StringLength(50)]
        public string TEN_TAI_KHOAN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAY_DAT_HANG { get; set; }

        public int? TONG_SAN_PHAM { get; set; }

        public decimal? TONG_TIEN { get; set; }

        [StringLength(50)]
        public string TRANG_THAI { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAY_DUYET { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAY_HUY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHI_TIET_DON_HANG> CHI_TIET_DON_HANG { get; set; }

        public virtual TAI_KHOAN TAI_KHOAN { get; set; }

        public virtual THONG_TIN_DON_HANG THONG_TIN_DON_HANG { get; set; }
    }
}

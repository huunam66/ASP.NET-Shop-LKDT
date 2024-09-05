namespace Nhom.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SAN_PHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SAN_PHAM()
        {
            CHI_TIET_DON_HANG = new HashSet<CHI_TIET_DON_HANG>();
            CHI_TIET_SAN_PHAM = new HashSet<CHI_TIET_SAN_PHAM>();
            GIO_HANG = new HashSet<GIO_HANG>();
            HINH_ANH = new HashSet<HINH_ANH>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(200)]
        public string TEN { get; set; }

        public decimal? GIA { get; set; }

        [StringLength(50)]
        public string MAU { get; set; }

        [StringLength(50)]
        public string MA_PHAN_LOAI { get; set; }

        public int? SO_LUONG { get; set; }

        [StringLength(50)]
        public string TRANG_THAI { get; set; }

        public long? LOAI_SP_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHI_TIET_DON_HANG> CHI_TIET_DON_HANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHI_TIET_SAN_PHAM> CHI_TIET_SAN_PHAM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIO_HANG> GIO_HANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HINH_ANH> HINH_ANH { get; set; }

        public virtual LOAI_SAN_PHAM LOAI_SAN_PHAM { get; set; }
    }
}

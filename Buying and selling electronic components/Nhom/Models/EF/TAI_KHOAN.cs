namespace Nhom.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TAI_KHOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAI_KHOAN()
        {
            DON_HANG = new HashSet<DON_HANG>();
            GIO_HANG = new HashSet<GIO_HANG>();
            THONG_TIN_TAI_KHOAN = new HashSet<THONG_TIN_TAI_KHOAN>();
        }

        [Key]
        [StringLength(50)]
        public string TEN_TAI_KHOAN { get; set; }

        [Required]
        [StringLength(50)]
        public string MAT_KHAU { get; set; }

        [Required]
        [StringLength(50)]
        public string QUYEN_HAN { get; set; }

        [Required]
        [StringLength(200)]
        public string EMAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DON_HANG> DON_HANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIO_HANG> GIO_HANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THONG_TIN_TAI_KHOAN> THONG_TIN_TAI_KHOAN { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Nhom.Models.EF
{
    public partial class EF_Linh_Kien : DbContext
    {
        public EF_Linh_Kien()
            : base("name=EF_Linh_Kien")
        {
        }

        public virtual DbSet<CHI_TIET_DON_HANG> CHI_TIET_DON_HANG { get; set; }
        public virtual DbSet<CHI_TIET_SAN_PHAM> CHI_TIET_SAN_PHAM { get; set; }
        public virtual DbSet<DON_HANG> DON_HANG { get; set; }
        public virtual DbSet<GIO_HANG> GIO_HANG { get; set; }
        public virtual DbSet<HINH_ANH> HINH_ANH { get; set; }
        public virtual DbSet<LOAI_SAN_PHAM> LOAI_SAN_PHAM { get; set; }
        public virtual DbSet<SAN_PHAM> SAN_PHAM { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAI_KHOAN> TAI_KHOAN { get; set; }
        public virtual DbSet<THONG_TIN_DON_HANG> THONG_TIN_DON_HANG { get; set; }
        public virtual DbSet<THONG_TIN_TAI_KHOAN> THONG_TIN_TAI_KHOAN { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHI_TIET_DON_HANG>()
                .Property(e => e.GIA)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CHI_TIET_DON_HANG>()
                .Property(e => e.HINH_ANH)
                .IsUnicode(false);

            modelBuilder.Entity<DON_HANG>()
                .Property(e => e.TEN_TAI_KHOAN)
                .IsUnicode(false);

            modelBuilder.Entity<DON_HANG>()
                .Property(e => e.TONG_TIEN)
                .HasPrecision(15, 2);

            modelBuilder.Entity<DON_HANG>()
                .HasMany(e => e.CHI_TIET_DON_HANG)
                .WithOptional(e => e.DON_HANG)
                .HasForeignKey(e => e.DON_HANG_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<DON_HANG>()
                .HasOptional(e => e.THONG_TIN_DON_HANG)
                .WithRequired(e => e.DON_HANG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<GIO_HANG>()
                .Property(e => e.TEN_TAI_KHOAN)
                .IsUnicode(false);

            modelBuilder.Entity<HINH_ANH>()
                .Property(e => e.TEN_FILE)
                .IsUnicode(false);

            modelBuilder.Entity<HINH_ANH>()
                .Property(e => e.THU_MUC)
                .IsUnicode(false);

            modelBuilder.Entity<LOAI_SAN_PHAM>()
                .HasMany(e => e.SAN_PHAM)
                .WithOptional(e => e.LOAI_SAN_PHAM)
                .HasForeignKey(e => e.LOAI_SP_ID);

            modelBuilder.Entity<SAN_PHAM>()
                .Property(e => e.GIA)
                .HasPrecision(12, 2);

            modelBuilder.Entity<SAN_PHAM>()
                .Property(e => e.MA_PHAN_LOAI)
                .IsUnicode(false);

            modelBuilder.Entity<SAN_PHAM>()
                .HasMany(e => e.CHI_TIET_DON_HANG)
                .WithOptional(e => e.SAN_PHAM)
                .HasForeignKey(e => e.SAN_PHAM_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SAN_PHAM>()
                .HasMany(e => e.CHI_TIET_SAN_PHAM)
                .WithRequired(e => e.SAN_PHAM)
                .HasForeignKey(e => e.SAN_PHAM_ID);

            modelBuilder.Entity<SAN_PHAM>()
                .HasMany(e => e.GIO_HANG)
                .WithRequired(e => e.SAN_PHAM)
                .HasForeignKey(e => e.SAN_PHAM_ID);

            modelBuilder.Entity<SAN_PHAM>()
                .HasMany(e => e.HINH_ANH)
                .WithOptional(e => e.SAN_PHAM)
                .HasForeignKey(e => e.SAN_PHAM_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TAI_KHOAN>()
                .Property(e => e.TEN_TAI_KHOAN)
                .IsUnicode(false);

            modelBuilder.Entity<TAI_KHOAN>()
                .Property(e => e.MAT_KHAU)
                .IsUnicode(false);

            modelBuilder.Entity<TAI_KHOAN>()
                .Property(e => e.QUYEN_HAN)
                .IsUnicode(false);

            modelBuilder.Entity<TAI_KHOAN>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<THONG_TIN_DON_HANG>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<THONG_TIN_TAI_KHOAN>()
                .Property(e => e.TEN_TAI_KHOAN)
                .IsUnicode(false);

            modelBuilder.Entity<THONG_TIN_TAI_KHOAN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<THONG_TIN_TAI_KHOAN>()
                .Property(e => e.ANH_DAI_DIEN)
                .IsUnicode(false);
        }
    }
}

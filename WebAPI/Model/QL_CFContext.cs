using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAPI.Model
{
    public partial class QL_CFContext : DbContext
    {
        public QL_CFContext()
        {
        }

        public QL_CFContext(DbContextOptions<QL_CFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CtSpSize> CtSpSizes { get; set; }
        public virtual DbSet<Ctdonhang> Ctdonhangs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Loai> Loais { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-IDE52KCV;Database=QL_CF;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CtSpSize>(entity =>
            {
                entity.HasKey(e => e.Ctsizeid)
                    .HasName("PK__ct_sp_si__6C965FB20AAD1A7E");

                entity.ToTable("ct_sp_size");

                entity.Property(e => e.Ctsizeid).HasColumnName("CTSIZEId");

                entity.Property(e => e.IdSize).HasColumnName("ID_SIZE");

                entity.Property(e => e.IdSp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ID_SP");

                entity.HasOne(d => d.IdSizeNavigation)
                    .WithMany(p => p.CtSpSizes)
                    .HasForeignKey(d => d.IdSize)
                    .HasConstraintName("FK_CT_SIZE");

                entity.HasOne(d => d.IdSpNavigation)
                    .WithMany(p => p.CtSpSizes)
                    .HasForeignKey(d => d.IdSp)
                    .HasConstraintName("FK_CT_SANPHAM");
            });

            modelBuilder.Entity<Ctdonhang>(entity =>
            {
                entity.ToTable("CTDONHANG");

                entity.Property(e => e.CtdonHangId).HasColumnName("CTDonHangId");

                entity.Property(e => e.DonHangId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SanPhamId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Size)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.DonHang)
                    .WithMany(p => p.Ctdonhangs)
                    .HasForeignKey(d => d.DonHangId)
                    .HasConstraintName("FK_CT_DONHANG");

                entity.HasOne(d => d.SanPham)
                    .WithMany(p => p.Ctdonhangs)
                    .HasForeignKey(d => d.SanPhamId)
                    .HasConstraintName("FK_CT_SP");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.ToTable("DonHang");

                entity.Property(e => e.DonHangId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.KhachHangId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTaoDon).HasColumnType("date");

                entity.Property(e => e.NhanVienId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TinhTrang).HasMaxLength(50);

                entity.HasOne(d => d.KhachHang)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.KhachHangId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DonHang_KhachHang");

                entity.HasOne(d => d.NhanVien)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.NhanVienId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DonHang_NhanVien");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__KHACHHAN__B15BE12FB3006BB4");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PHONE")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Loai>(entity =>
            {
                entity.ToTable("LOAI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__NhanVien__B15BE12FBBCB904C");

                entity.ToTable("NhanVien");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.Property(e => e.Anh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ANH");

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.GioiTinh).HasMaxLength(10);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PHONE")
                    .IsFixedLength(true);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLE")
                    .HasDefaultValueSql("('Employee')");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.ToTable("SANPHAM");

                entity.Property(e => e.Sanphamid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SANPHAMID");

                entity.Property(e => e.Anh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ANH");

                entity.Property(e => e.HanSuDung).HasColumnType("date");

                entity.Property(e => e.IdLoai).HasColumnName("ID_LOAI");

                entity.Property(e => e.IdSize).HasColumnName("ID_SIZE");

                entity.Property(e => e.TenSp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TenSP");

                entity.HasOne(d => d.IdLoaiNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.IdLoai)
                    .HasConstraintName("FK_SANPHAM_LOAI");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("SIZE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NAME")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

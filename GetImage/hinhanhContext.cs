using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GetImage
{
    public partial class hinhanhContext : DbContext
    {
        public hinhanhContext()
        {
        }

        public hinhanhContext(DbContextOptions<hinhanhContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Image> Image { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=192.168.10.225;database=hinhanh;user=root", x => x.ServerVersion("10.4.14-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.IdHinh)
                    .HasName("PRIMARY");

                entity.ToTable("image");

                entity.Property(e => e.IdHinh)
                    .HasColumnName("ID_hinh")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Hinh).IsRequired();

                entity.Property(e => e.TenHinh)
                    .IsRequired()
                    .HasColumnName("Ten_Hinh")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

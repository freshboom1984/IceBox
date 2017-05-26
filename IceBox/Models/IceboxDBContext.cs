using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IceBox.Models
{
    public partial class IceboxDBContext : DbContext
    {
        public virtual DbSet<NewsTable> NewsTable { get; set; }
        public virtual DbSet<ProductTable> ProductTable { get; set; }
        public virtual DbSet<TypeTable> TypeTable { get; set; }

        public IceboxDBContext(DbContextOptions<IceboxDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsTable>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK_News_table");

                entity.ToTable("News_table");

                entity.Property(e => e.ObjId).ValueGeneratedNever();

                entity.Property(e => e.Buttoncontext).HasColumnType("nchar(50)");

                entity.Property(e => e.Img).HasColumnType("nchar(50)");

                entity.Property(e => e.Name).HasColumnType("nchar(50)");
            });

            modelBuilder.Entity<ProductTable>(entity =>
            {
                entity.ToTable("Product_table");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Chigh).HasColumnType("nchar(500)");

                entity.Property(e => e.Clow)
                    .IsRequired()
                    .HasColumnType("nchar(500)");

                entity.Property(e => e.Ename).HasColumnType("nchar(40)");

                entity.Property(e => e.Hdiscribe).HasColumnType("nchar(500)");

                entity.Property(e => e.Hpicture)
                    .IsRequired()
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.Sdisvribe).HasColumnType("nchar(1500)");

                entity.Property(e => e.Spicture1)
                    .IsRequired()
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.Spicture2)
                    .IsRequired()
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.Svideo).HasColumnType("nchar(100)");
            });

            modelBuilder.Entity<TypeTable>(entity =>
            {
                entity.ToTable("Type_table");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Type).HasColumnType("nchar(15)");
            });
        }
    }
}
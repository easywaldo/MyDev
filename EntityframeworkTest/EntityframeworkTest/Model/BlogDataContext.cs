using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityframeworkTest.Model
{
    public partial class BlogDataContext : DbContext
    {
        public virtual DbSet<BlogArticle> BlogArticle { get; set; }
        public virtual DbSet<BlogUsers> BlogUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=JinamLocalTest;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogArticle>(entity =>
            {
                entity.HasKey(e => e.ArticleNo);

                entity.Property(e => e.ArticleNo).ValueGeneratedNever();

                entity.Property(e => e.Content)
                    .HasColumnName("Content ")
                    .HasColumnType("ntext");

                entity.Property(e => e.WriteUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.WriteUserNavigation)
                    .WithMany(p => p.BlogArticle)
                    .HasForeignKey(d => d.WriteUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlogArticle_ToTable");
            });

            modelBuilder.Entity<BlogUsers>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BlogUrl)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}

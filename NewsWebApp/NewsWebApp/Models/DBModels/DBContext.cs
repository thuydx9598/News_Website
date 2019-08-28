using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NewsWebApp.Models.DBModels
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catagory> Catagory { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Subscriber> Subscriber { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=35.244.72.51;Initial Catalog=NewsWebApp;Persist Security Info=True;User ID=xuanthuy;Password=L@mV0@nhNh3Th@nh");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Catagory>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Message).HasMaxLength(2000);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.SentDate).HasColumnType("datetime");

                entity.Property(e => e.Subject).HasMaxLength(300);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AuthorId).HasColumnName("Author_Id");

                entity.Property(e => e.CatagoryId).HasColumnName("Catagory_Id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("ImageURL")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Post_User");

                entity.HasOne(d => d.Catagory)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.CatagoryId)
                    .HasConstraintName("FK_Post_Category");
            });

            modelBuilder.Entity<Subscriber>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FullName).HasMaxLength(200);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
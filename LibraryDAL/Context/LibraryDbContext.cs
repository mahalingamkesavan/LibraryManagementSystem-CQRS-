using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LibraryUtil.Models;

namespace LibraryDAL.Context
{
    public partial class LibraryDbContext : DbContext
    {
        public LibraryDbContext()
        {
        }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddressDetail> AddressDetails { get; set; } = null!;
        public virtual DbSet<BookDetail> BookDetails { get; set; } = null!;
        public virtual DbSet<BookType> BookTypes { get; set; } = null!;
        public virtual DbSet<IssuedBook> IssuedBooks { get; set; } = null!;
        public virtual DbSet<UserRegistration> UserRegistrations { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressDetail>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK__AddressD__091C2AFB3D66CECF");

                entity.ToTable("AddressDetail");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate).HasColumnName("Created_Date");

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");

                entity.Property(e => e.UpdatedDate).HasColumnName("Updated_Date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AddressDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AddressDe__UserI__671F4F74");
            });

            modelBuilder.Entity<BookDetail>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__BookDeta__3DE0C22793894B5A");

                entity.ToTable("BookDetail");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BookName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasPrecision(0)
                    .HasColumnName("Created_Date");

                entity.Property(e => e.TypeOfBook)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");

                entity.Property(e => e.UpdatedDate)
                    .HasPrecision(0)
                    .HasColumnName("Updated_Date");
            });

            modelBuilder.Entity<BookType>(entity =>
            {
                entity.ToTable("BookType");

                entity.HasIndex(e => e.BookTypeName, "UQ__BookType__CF38B41E7FC5D499")
                    .IsUnique();

                entity.Property(e => e.BookTypeId).HasColumnName("BookTypeID");

                entity.Property(e => e.BookTypeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasPrecision(0)
                    .HasColumnName("Created_Date");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");

                entity.Property(e => e.UpdatedDate)
                    .HasPrecision(0)
                    .HasColumnName("Updated_Date");
            });

            modelBuilder.Entity<IssuedBook>(entity =>
            {
                entity.ToTable("IssuedBook");

                entity.Property(e => e.IssuedBookId).HasColumnName("IssuedBookID");

                entity.Property(e => e.BooKid).HasColumnName("BooKID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasPrecision(0)
                    .HasColumnName("Created_Date");

                entity.Property(e => e.LateDate).HasColumnName("lateDate");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");

                entity.Property(e => e.UpdatedDate)
                    .HasPrecision(0)
                    .HasColumnName("Updated_Date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.BooK)
                    .WithMany(p => p.IssuedBooks)
                    .HasForeignKey(d => d.BooKid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__IssuedBoo__BooKI__09A971A2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.IssuedBooks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__IssuedBoo__UserI__681373AD");
            });

            modelBuilder.Entity<UserRegistration>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserRegi__1788CCAC00C6D317");

                entity.ToTable("UserRegistration");

                entity.HasIndex(e => e.PhoneNumber, "UQ__UserRegi__85FB4E3863CE6D0D")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__UserRegi__A9D1053463835295")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ApprovedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasPrecision(0)
                    .HasColumnName("Created_Date");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notify).HasDefaultValueSql("('FALSE')");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");

                entity.Property(e => e.UpdatedDate)
                    .HasPrecision(0)
                    .HasColumnName("Updated_Date");

                entity.Property(e => e.UserStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

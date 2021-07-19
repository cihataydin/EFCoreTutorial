using System;
using EFCoreTutorail.Data.Models;
using EFCoreTutorial.Common;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorail.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public ApplicationDbContext()
        {

        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentAddress> StudentAddresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // make the configurations
                optionsBuilder.UseSqlServer(StringConstants.DbConnectinString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            /* This is another way to customize the table
            modelBuilder.Entity<Student>().Property(i => i.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .UseIdentityColumn()
                .IsRequired();

            modelBuilder.Entity<Student>().Property(i => i.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);
            */


            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("students");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").UseIdentityColumn().IsRequired();
                entity.Property(i => i.FirstName).HasColumnName("first_name").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.LastName).HasColumnName("last_name").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.Number).HasColumnName("number");
                entity.Property(i => i.BirthDate).HasColumnName("birth_date");
                entity.Property(i => i.AddressId).HasColumnName("address_id");

                entity.HasMany(i => i.Books).WithOne(i => i.Student).HasForeignKey(i => i.StudentId).HasConstraintName("student_book_id_fk");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teachers");

                entity.Property(i => i.Id).HasColumnName("id").UseIdentityColumn();
                entity.Property(i => i.FirstName).HasColumnName("first_name").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.LastName).HasColumnName("last_name").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.BirthDate).HasColumnName("birth_date");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("courses");

                entity.Property(i => i.Id).HasColumnName("id").UseIdentityColumn();
                entity.Property(i => i.Name).HasColumnName("name").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.IsActive).HasColumnName("is_active");
            });

            modelBuilder.Entity<StudentAddress>(entity =>
            {
                entity.ToTable("student_addresses");

                entity.Property(i => i.Id).HasColumnName("id").UseIdentityColumn().ValueGeneratedOnAdd();
                entity.Property(i => i.City).HasColumnName("city").HasMaxLength(50);
                entity.Property(i => i.District).HasColumnName("district").HasMaxLength(100);
                entity.Property(i => i.Country).HasColumnName("country").HasMaxLength(50);
                entity.Property(i => i.FullAddress).HasColumnName("full_address").HasMaxLength(1000);
                entity.Property(i => i.StudentId).HasColumnName("student_id");

                entity.HasOne(i => i.Student).WithOne(i => i.StudentAddress)
                    .HasForeignKey<StudentAddress>(i => i.StudentId).HasConstraintName("student_address_id_fk");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").UseIdentityColumn().IsRequired();
                entity.Property(i => i.Name).HasColumnName("name").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.Author).HasColumnName("author").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.StudentId).HasColumnName("student_id");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

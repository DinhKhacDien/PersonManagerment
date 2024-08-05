using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEndApp.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Professor> Professors { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-045KIG4Q\\SQLEXPRESS;Database=BaiTapLayDiem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Person__AddressI__4BAC3F29");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.ToTable("Professor");

                entity.Property(e => e.ProfessorId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProfessorID");

                entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.ProfessorNavigation)
                    .WithOne(p => p.Professor)
                    .HasForeignKey<Professor>(d => d.ProfessorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professor__Profe__5165187F");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId)
                    .ValueGeneratedNever()
                    .HasColumnName("StudentID");

                entity.Property(e => e.AverageMark).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.StudentNumber).HasMaxLength(50);

                entity.HasOne(d => d.StudentNavigation)
                    .WithOne(p => p.Student)
                    .HasForeignKey<Student>(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Student__Student__4E88ABD4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

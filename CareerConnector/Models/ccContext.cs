using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CareerConnector.Models;

public partial class ccContext : DbContext
{
    public ccContext()
    {
    }

    public ccContext(DbContextOptions<ccContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Employer> Employers { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobApplication> JobApplications { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserJob> UserJobs { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
 //       => optionsBuilder.UseSqlServer("Server=localhost;database=CareerConnector;user id=sa; Password=CareerConnectorDB1;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("Applications_pk");

            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.Company)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Skills)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<Employer>(entity =>
        {
            entity.HasKey(e => e.EmployerId).HasName("Employers_pk");

            entity.Property(e => e.EmployerId).HasColumnName("EmployerID");
            entity.Property(e => e.Company)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FIrstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("Jobs_pk");

            entity.Property(e => e.JobId).HasColumnName("JobID");
            entity.Property(e => e.City)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("CIty");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EmployerId).HasColumnName("EmployerID");
            entity.Property(e => e.JobType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pay)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Employer).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.EmployerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Job_Employer");
        });

        modelBuilder.Entity<JobApplication>(entity =>
        {
            entity.HasKey(e => new { e.JobId, e.ApplicationId }).HasName("JobApplications_pk");

            entity.Property(e => e.JobId).HasColumnName("JobID");
            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("Users_pk");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.City)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Education)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserJob>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.JobId }).HasName("UserJobs_pk");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.JobId).HasColumnName("JobID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

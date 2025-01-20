using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BusinessObjects;

namespace DataAccessObjects;

public partial class FindingHealthcareSystemContext : DbContext
{
    public FindingHealthcareSystemContext()
    {
    }

    public FindingHealthcareSystemContext(DbContextOptions<FindingHealthcareSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Expertise> Expertises { get; set; }

    public virtual DbSet<Facility> Facilities { get; set; }

    public virtual DbSet<FacilityDepartment> FacilityDepartments { get; set; }

    public virtual DbSet<FacilityType> FacilityTypes { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientUnderlyingDisease> PatientUnderlyingDiseases { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PrivateService> PrivateServices { get; set; }

    public virtual DbSet<Professional> Professionals { get; set; }

    public virtual DbSet<ProfessionalSpecialty> ProfessionalSpecialties { get; set; }

    public virtual DbSet<PublicService> PublicServices { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Specialty> Specialties { get; set; }

    public virtual DbSet<UnderlyingDisease> UnderlyingDiseases { get; set; }

    public virtual DbSet<User> Users { get; set; }

    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
        return configuration["ConnectionStrings:DefaultConnectionString"];
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(GetConnectionString());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCA2E8E5C5C8");

            entity.ToTable("Appointment");

            entity.Property(e => e.AppointmentId)
                .ValueGeneratedNever()
                .HasColumnName("AppointmentID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.ProfessionalId).HasColumnName("ProfessionalID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_Appointment_PatientID");

            entity.HasOne(d => d.Payment).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK_Appointment_PaymentID");

            entity.HasOne(d => d.Professional).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ProfessionalId)
                .HasConstraintName("FK_Appointment_ProfessionalID");

            entity.HasOne(d => d.Service).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_Appointment_ServiceID");
        });

        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.ArticleId).HasName("PK__Article__9C6270C8131943E1");

            entity.ToTable("Article");

            entity.Property(e => e.ArticleId)
                .ValueGeneratedNever()
                .HasColumnName("ArticleID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.Articles)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Article_CategoryID");
        });

        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attachme__3214EC27FDBA75D2");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.MedicalRecordId).HasColumnName("MedicalRecordID");

            entity.HasOne(d => d.MedicalRecord).WithMany(p => p.Attachments)
                .HasForeignKey(d => d.MedicalRecordId)
                .HasConstraintName("FK_Attachments_MedicalRecordID");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2B5DF65A07");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("CategoryID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCD78C2CDD5");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId)
                .ValueGeneratedNever()
                .HasColumnName("DepartmentID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Expertise>(entity =>
        {
            entity.HasKey(e => e.ExpertiseId).HasName("PK__Expertis__909D2E81CC9E6910");

            entity.ToTable("Expertise");

            entity.Property(e => e.ExpertiseId)
                .ValueGeneratedNever()
                .HasColumnName("ExpertiseID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Facility>(entity =>
        {
            entity.HasKey(e => e.FacilityId).HasName("PK__Facility__5FB08B94DEECDB0D");

            entity.ToTable("Facility");

            entity.Property(e => e.FacilityId)
                .ValueGeneratedNever()
                .HasColumnName("FacilityID");
            entity.Property(e => e.Commune).HasMaxLength(255);
            entity.Property(e => e.District).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Province).HasMaxLength(255);
            entity.Property(e => e.TypeId).HasColumnName("TypeID");

            entity.HasOne(d => d.Type).WithMany(p => p.Facilities)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK_Facility_TypeID");
        });

        modelBuilder.Entity<FacilityDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Facility__3214EC273E3DD383");

            entity.ToTable("FacilityDepartment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.FacilityId).HasColumnName("FacilityID");

            entity.HasOne(d => d.Department).WithMany(p => p.FacilityDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_FacilityDepartment_DepartmentID");

            entity.HasOne(d => d.Facility).WithMany(p => p.FacilityDepartments)
                .HasForeignKey(d => d.FacilityId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_FacilityDepartment_FacilityID");
        });

        modelBuilder.Entity<FacilityType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__Facility__516F0395AAA554AD");

            entity.ToTable("FacilityType");

            entity.Property(e => e.TypeId)
                .ValueGeneratedNever()
                .HasColumnName("TypeID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(e => e.MedicalRecordId).HasName("PK__MedicalR__4411BBC25F09F9F9");

            entity.ToTable("MedicalRecord");

            entity.Property(e => e.MedicalRecordId)
                .ValueGeneratedNever()
                .HasColumnName("MedicalRecordID");
            entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");

            entity.HasOne(d => d.Appointment).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.AppointmentId)
                .HasConstraintName("FK_MedicalRecord_AppointmentID");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patient__970EC34671CBD8A6");

            entity.ToTable("Patient");

            entity.Property(e => e.PatientId)
                .ValueGeneratedNever()
                .HasColumnName("PatientID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Patients)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Patient_UserID");
        });

        modelBuilder.Entity<PatientUnderlyingDisease>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PatientU__3214EC2722BD4AD0");

            entity.ToTable("PatientUnderlyingDisease");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.UnderlyingDiseaseId).HasColumnName("UnderlyingDiseaseID");

            entity.HasOne(d => d.Patient).WithMany(p => p.PatientUnderlyingDiseases)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PatientUnderlyingDisease_PatientID");

            entity.HasOne(d => d.UnderlyingDisease).WithMany(p => p.PatientUnderlyingDiseases)
                .HasForeignKey(d => d.UnderlyingDiseaseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PatientUnderlyingDisease_UnderlyingDiseaseID");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__9B556A58D411C21D");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId)
                .ValueGeneratedNever()
                .HasColumnName("PaymentID");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(255);
            entity.Property(e => e.PaymentStatus).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(19, 0)");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(255)
                .HasColumnName("TransactionID");
        });

        modelBuilder.Entity<PrivateService>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__PrivateS__C51BB0EA895DDDB1");

            entity.ToTable("PrivateService");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("ServiceID");
            entity.Property(e => e.ProfessionalId).HasColumnName("ProfessionalID");

            entity.HasOne(d => d.Professional).WithMany(p => p.PrivateServices)
                .HasForeignKey(d => d.ProfessionalId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PrivateService_ProfessionalID");

            entity.HasOne(d => d.Service).WithOne(p => p.PrivateService)
                .HasForeignKey<PrivateService>(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrivateService_ServiceID");
        });

        modelBuilder.Entity<Professional>(entity =>
        {
            entity.HasKey(e => e.ProfessionalId).HasName("PK__Professi__B242EF48CE789454");

            entity.ToTable("Professional");

            entity.HasIndex(e => e.UserId, "UQ__Professi__1788CCAD6131B31F").IsUnique();

            entity.Property(e => e.ProfessionalId)
                .ValueGeneratedNever()
                .HasColumnName("ProfessionalID");
            entity.Property(e => e.Commune).HasMaxLength(255);
            entity.Property(e => e.Degree).HasMaxLength(255);
            entity.Property(e => e.District).HasMaxLength(255);
            entity.Property(e => e.Experience).HasMaxLength(255);
            entity.Property(e => e.ExpertiseId).HasColumnName("ExpertiseID");
            entity.Property(e => e.Province).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.WorkingHours).HasMaxLength(255);

            entity.HasOne(d => d.Expertise).WithMany(p => p.Professionals)
                .HasForeignKey(d => d.ExpertiseId)
                .HasConstraintName("FK_Professional_ExpertiseID");

            entity.HasOne(d => d.User).WithOne(p => p.Professional)
                .HasForeignKey<Professional>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Professional_UserID");
        });

        modelBuilder.Entity<ProfessionalSpecialty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Professi__3214EC275EB5922B");

            entity.ToTable("ProfessionalSpecialty");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ProfessionalId).HasColumnName("ProfessionalID");
            entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

            entity.HasOne(d => d.Professional).WithMany(p => p.ProfessionalSpecialties)
                .HasForeignKey(d => d.ProfessionalId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ProfessionalSpecialty_ProfessionalID");

            entity.HasOne(d => d.Specialty).WithMany(p => p.ProfessionalSpecialties)
                .HasForeignKey(d => d.SpecialtyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ProfessionalSpecialty_SpecialtyID");
        });

        modelBuilder.Entity<PublicService>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__PublicSe__C51BB0EA8701171C");

            entity.ToTable("PublicService");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("ServiceID");
            entity.Property(e => e.FacilityId).HasColumnName("FacilityID");

            entity.HasOne(d => d.Facility).WithMany(p => p.PublicServices)
                .HasForeignKey(d => d.FacilityId)
                .HasConstraintName("FK_PublicService_FacilityID");

            entity.HasOne(d => d.Service).WithOne(p => p.PublicService)
                .HasForeignKey<PublicService>(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PublicService_ServiceID");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Review__74BC79AE840B2DDB");

            entity.ToTable("Review");

            entity.Property(e => e.ReviewId)
                .ValueGeneratedNever()
                .HasColumnName("ReviewID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.ProfessionalId).HasColumnName("ProfessionalID");

            entity.HasOne(d => d.Patient).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_Review_PatientID");

            entity.HasOne(d => d.Professional).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProfessionalId)
                .HasConstraintName("FK_Review_ProfessionalID");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__C51BB0EAB0401EFD");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("ServiceID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(19, 0)");
        });

        modelBuilder.Entity<Specialty>(entity =>
        {
            entity.HasKey(e => e.SpecialtyId).HasName("PK__Specialt__D768F6485F83ADF1");

            entity.ToTable("Specialty");

            entity.Property(e => e.SpecialtyId)
                .ValueGeneratedNever()
                .HasColumnName("SpecialtyID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<UnderlyingDisease>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Underlyi__3214EC27289EBBE8");

            entity.ToTable("UnderlyingDisease");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC22F7586E");

            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Fullname).HasMaxLength(255);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

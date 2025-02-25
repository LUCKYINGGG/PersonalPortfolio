﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StarTEDSystem.Entities;

namespace StarTEDSystem.DAL;

// add extra layer of security by changing public access to internal, limit the accessibility.
internal partial class StarTEDContext : DbContext
{
    public StarTEDContext(DbContextOptions<StarTEDContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AssessmentType> AssessmentTypes { get; set; }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<CampusVenue> CampusVenues { get; set; }

    public virtual DbSet<ClassMember> ClassMembers { get; set; }

    public virtual DbSet<ClassOffering> ClassOfferings { get; set; }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<ClubActivity> ClubActivities { get; set; }

    public virtual DbSet<ClubMember> ClubMembers { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<GradeAssignment> GradeAssignments { get; set; }

    public virtual DbSet<Offering> Offerings { get; set; }

    public virtual DbSet<PlannedAssessment> PlannedAssessments { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Program> Programs { get; set; }

    public virtual DbSet<ProgramCourse> ProgramCourses { get; set; }

    public virtual DbSet<PropertyOwner> PropertyOwners { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<RentalPayment> RentalPayments { get; set; }

    public virtual DbSet<RentalType> RentalTypes { get; set; }

    public virtual DbSet<Renter> Renters { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<SchoolTerm> SchoolTerms { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAddress> StudentAddresses { get; set; }

    public virtual DbSet<StudentPayment> StudentPayments { get; set; }

    public virtual DbSet<WorkingVersion> WorkingVersions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressID).HasName("PK_dbo.Addresses");

            entity.ToTable(tb => tb.HasTrigger("Trigger_Addresses_CountryCode"));

            entity.Property(e => e.CountryCode).IsFixedLength();
            entity.Property(e => e.Street).HasDefaultValue("TBA");

            entity.HasOne(d => d.LandLord).WithMany(p => p.Addresses).HasConstraintName("FK_dbo.Addresses_dbo.PropertyOwners_LandlordID");
        });

        modelBuilder.Entity<AssessmentType>(entity =>
        {
            entity.HasKey(e => e.AssessmentTypeID).HasName("PK__Assessme__3368D75110F6365D");
        });

        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentID).HasName("PK_dbo.Assignments");

            entity.HasOne(d => d.Offering).WithMany(p => p.Assignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Assignments_dbo.Offerings_OfferingID");
        });

        modelBuilder.Entity<CampusVenue>(entity =>
        {
            entity.HasKey(e => e.CampusVenueID).HasName("PK__CampusVe__5902141F017FF985");
        });

        modelBuilder.Entity<ClassMember>(entity =>
        {
            entity.HasKey(e => e.RegistrationID).HasName("PK_dbo.ClassMembers");

            entity.HasOne(d => d.OfferingSection).WithMany(p => p.ClassMembers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.ClassMembers_dbo.ClassOfferings_OfferingSectionID");

            entity.HasOne(d => d.StudentNumberNavigation).WithMany(p => p.ClassMembers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.ClassMembers_dbo.Students_StudentNumber");
        });

        modelBuilder.Entity<ClassOffering>(entity =>
        {
            entity.HasKey(e => e.ClassOfferingID).HasName("PK_dbo.ClassOfferings");

            entity.HasOne(d => d.Employee).WithMany(p => p.ClassOfferings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.ClassOfferings_dbo.Employees_EmployeeID");

            entity.HasOne(d => d.Offering).WithMany(p => p.ClassOfferings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.ClassOfferings_dbo.Offerings_OfferingID");
        });

        modelBuilder.Entity<Club>(entity =>
        {
            entity.HasKey(e => e.ClubID).HasName("PK_dbo.Clubs");

            entity.HasOne(d => d.Employee).WithMany(p => p.Clubs).HasConstraintName("FK_dbo.Clubs_dbo.Employees_EmployeeID");
        });

        modelBuilder.Entity<ClubActivity>(entity =>
        {
            entity.HasKey(e => e.ActivityID).HasName("PK_dbo.ClubActivities");

            entity.ToTable(tb => tb.HasTrigger("Trigger_ClubActivities_CampusVenue"));

            entity.HasOne(d => d.CampusVenue).WithMany(p => p.ClubActivities).HasConstraintName("FK_dbo.ClubActivities_dbo.CampusVenue_CampusVenueID");

            entity.HasOne(d => d.Club).WithMany(p => p.ClubActivities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.ClubActivities_dbo.Clubs_ClubID");
        });

        modelBuilder.Entity<ClubMember>(entity =>
        {
            entity.HasKey(e => e.MemberID).HasName("PK_dbo.ClubMembers");

            entity.HasOne(d => d.Club).WithMany(p => p.ClubMembers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.ClubMembers_dbo.Clubs_ClubID");

            entity.HasOne(d => d.Role).WithMany(p => p.ClubMembers).HasConstraintName("FK_dbo.ClubMembers_dbo.Roles_RoleID");

            entity.HasOne(d => d.StudentNumberNavigation).WithMany(p => p.ClubMembers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.ClubMembers_dbo.Students_StudentNumber");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryCode).HasName("PK_dbo.Countries");

            entity.Property(e => e.CountryCode).IsFixedLength();
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseID).HasName("PK_dbo.Courses");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeID).HasName("PK_dbo.Employees");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Employees_dbo.Positions_PositionID");

            entity.HasOne(d => d.Program).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Employees_dbo.Programs_ProgramID");
        });

        modelBuilder.Entity<GradeAssignment>(entity =>
        {
            entity.HasKey(e => e.GradeID).HasName("PK_dbo.GradeAssignments");

            entity.HasOne(d => d.Assignment).WithMany(p => p.GradeAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.GradeAssignments_dbo.Assignments_AssignmentID");

            entity.HasOne(d => d.Registration).WithMany(p => p.GradeAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.GradeAssignments_dbo.ClassMembers_RegistrationID");
        });

        modelBuilder.Entity<Offering>(entity =>
        {
            entity.HasKey(e => e.OfferingID).HasName("PK_dbo.Offerings");

            entity.Property(e => e.Semester).IsFixedLength();

            entity.HasOne(d => d.ProgramCourse).WithMany(p => p.Offerings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Offerings_dbo.ProgramCourses_ProgramCourseID");

            entity.HasOne(d => d.SemesterNavigation).WithMany(p => p.Offerings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Offerings_dbo.SchoolTerms_Semester");
        });

        modelBuilder.Entity<PlannedAssessment>(entity =>
        {
            entity.HasKey(e => e.AssessmentID).HasName("PK_dbo.PlannedAssessments");

            entity.HasOne(d => d.AssessmentType).WithMany(p => p.PlannedAssessments).HasConstraintName("FK_dbo.PlannedAssessments_dbo.AssessmentTypes_AssessmentTypeID");

            entity.HasOne(d => d.Course).WithMany(p => p.PlannedAssessments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.PlannedAssessments_dbo.Courses_CourseID");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionID).HasName("PK_dbo.Positions");

            entity.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation).HasConstraintName("FK_dbp.Positions_ReportsTo");
        });

        modelBuilder.Entity<Program>(entity =>
        {
            entity.HasKey(e => e.ProgramID).HasName("PK_dbo.Programs");

            entity.HasOne(d => d.SchoolCodeNavigation).WithMany(p => p.Programs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Programs_dbo.Schools_SchoolCode");
        });

        modelBuilder.Entity<ProgramCourse>(entity =>
        {
            entity.HasKey(e => e.ProgramCourseID).HasName("PK_dbo.ProgramCourses");

            entity.HasOne(d => d.Course).WithMany(p => p.ProgramCourses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.ProgramCourses_dbo.Courses_CourseID");

            entity.HasOne(d => d.Program).WithMany(p => p.ProgramCourses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.ProgramCourses_dbo.Programs_ProgramID");
        });

        modelBuilder.Entity<PropertyOwner>(entity =>
        {
            entity.HasKey(e => e.LandlordID).HasName("PK_dbo.PropertyOwners");

            entity.Property(e => e.ContactNumber).IsFixedLength();
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.RentalID).HasName("PK_dbo.RentalAgreements");

            entity.Property(e => e.MaxVacancy).HasDefaultValue((byte)4);
            entity.Property(e => e.MonthlyRent).HasComment("Monthly rent for the entire unit, regardless of the number of renters");
            entity.Property(e => e.Vacancies).HasDefaultValue((byte)2);

            entity.HasOne(d => d.Address).WithMany(p => p.Rentals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.RentalAgreements_dbo.Addresses_AddressID");

            entity.HasOne(d => d.RentalType).WithMany(p => p.Rentals).HasConstraintName("FK_dbo.RentalAgreements_dbo.RentalTypes_RentalTypeID");
        });

        modelBuilder.Entity<RentalPayment>(entity =>
        {
            entity.HasKey(e => e.PaymentID).HasName("PK_dbo.RentalPayments");

            entity.Property(e => e.PaymentID).ValueGeneratedNever();

            entity.HasOne(d => d.Rental).WithMany(p => p.RentalPayments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.RentalPayments_dbo.RentalAgreements_RentalAgreementID");
        });

        modelBuilder.Entity<RentalType>(entity =>
        {
            entity.HasKey(e => e.RentalTypeID).HasName("PK__RentalTy__DECD558EDA4FDE5B");
        });

        modelBuilder.Entity<Renter>(entity =>
        {
            entity.HasKey(e => e.RenterID).HasName("PK_dbo.Renters");

            entity.Property(e => e.EmergencyContactNumber).IsFixedLength();

            entity.HasOne(d => d.Rental).WithMany(p => p.Renters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Renters_dbo.RentalAgreements_RentalAgreementID");

            entity.HasOne(d => d.StudentNumberNavigation).WithMany(p => p.Renters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Renters_dbo.Students_StudentNumber");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleID).HasName("PK__Roles__8AFACE3A20EEC5BC");
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.SchoolCode).HasName("PK_dbo.Schools");
        });

        modelBuilder.Entity<SchoolTerm>(entity =>
        {
            entity.HasKey(e => e.Semester).HasName("PK_dbo.SchoolTerms");

            entity.Property(e => e.Semester).IsFixedLength();
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentNumber).HasName("PK_dbo.Students");

            entity.Property(e => e.StudentNumber).ValueGeneratedNever();
            entity.Property(e => e.CountryCode)
                .HasDefaultValue("CA")
                .IsFixedLength();
            entity.Property(e => e.Gender).IsFixedLength();

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.Students)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Students_dbo.Countries_CountryCode");
        });

        modelBuilder.Entity<StudentAddress>(entity =>
        {
            entity.HasKey(e => e.StudentAddressID).HasName("PK_dbo.StudentAddresses");

            entity.Property(e => e.IsPrimaryResidence).HasDefaultValue(true);

            entity.HasOne(d => d.Address).WithMany(p => p.StudentAddressAddresses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.StudentAddresses_dbo.Addresses_AddressID");

            entity.HasOne(d => d.ForwardingAddress).WithMany(p => p.StudentAddressForwardingAddresses).HasConstraintName("FK_dbo.StudentAddresses_dbo.Addresses_ForwardingAddressID");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentAddresses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.StudentAddresses_dbo.Students_StudentID");
        });

        modelBuilder.Entity<StudentPayment>(entity =>
        {
            entity.HasKey(e => e.PaymentNumber).HasName("PK_dbo.StudentPayments");

            entity.HasOne(d => d.StudentNumberNavigation).WithMany(p => p.StudentPayments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.StudentPayments_dbo.Students_StudentNumber");
        });

        modelBuilder.Entity<WorkingVersion>(entity =>
        {
            entity.HasKey(e => e.VersionID).HasName("PK_dbo.WorkingVersions");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
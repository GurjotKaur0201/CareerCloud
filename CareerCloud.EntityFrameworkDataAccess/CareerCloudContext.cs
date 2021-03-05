using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CareerCloud.Pocos;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {
        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-JVNP70QS\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicantEducationPoco>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<ApplicantEducationPoco>()
                .HasOne(a => a.ApplicantProfile)
                .WithMany(b => b.ApplicantEducations)
                .HasForeignKey(a => a.Applicant);
            modelBuilder.Entity<ApplicantEducationPoco>()
                .Property(a => a.TimeStamp)
                .IsRowVersion();
            modelBuilder.Entity<ApplicantJobApplicationPoco>()
                .HasKey(t=>t.Id);
            modelBuilder.Entity<ApplicantJobApplicationPoco>()
               .Property(a => a.TimeStamp)
               .IsRowVersion();
            modelBuilder.Entity<ApplicantJobApplicationPoco>()
                .HasOne(a => a.ApplicantProfile)
                .WithMany(b => b.ApplicantJobApplications)
                .HasForeignKey(a => a.Applicant);
            modelBuilder.Entity<ApplicantJobApplicationPoco>()
                .HasOne(a => a.CompanyJob)
                .WithMany(b => b.ApplicantJobApplications)
                .HasForeignKey(a => a.Job);
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasKey(t=>t.Id);
            modelBuilder.Entity<ApplicantProfilePoco>()
               .Property(a => a.TimeStamp)
               .IsRowVersion();
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasOne(a => a.SystemCountryCode)
                .WithMany(b => b.ApplicantProfiles)
                .HasForeignKey(a => a.Country);
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasOne(a => a.SecurityLogin)
                .WithMany(b => b.ApplicantProfiles)
                .HasForeignKey(a => a.Login);
            modelBuilder.Entity<ApplicantResumePoco>()
                .HasKey(t =>t.Id);
            modelBuilder.Entity<ApplicantResumePoco>()
                .HasOne(a => a.ApplicantProfile)
                .WithMany(b => b.ApplicantResumes)
                .HasForeignKey(a => a.Applicant);
            modelBuilder.Entity<ApplicantSkillPoco>()
               .HasKey(t => t.Id);
            modelBuilder.Entity<ApplicantSkillPoco>()
               .Property(a => a.TimeStamp)
               .IsRowVersion();
            modelBuilder.Entity<ApplicantSkillPoco>()
                .HasOne(a => a.ApplicantProfile)
                .WithMany(b => b.ApplicantSkills)
                .HasForeignKey(a => a.Applicant);
            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
               .HasKey(t => t.Id);
            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
               .Property(a => a.TimeStamp)
               .IsRowVersion();
            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
                .HasOne(a => a.ApplicantProfile)
                .WithMany(b => b.ApplicantWorkHistorys)
                .HasForeignKey(a => a.Applicant);
            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
               .HasOne(a => a.SystemCountryCode)
               .WithMany(b => b.ApplicantWorkHistorys)
               .HasForeignKey(a => a.CountryCode);
            modelBuilder.Entity<CompanyDescriptionPoco>()
               .HasKey(t => t.Id);
            modelBuilder.Entity<CompanyDescriptionPoco>()
               .Property(a => a.TimeStamp)
               .IsRowVersion();
            modelBuilder.Entity<CompanyDescriptionPoco>()
                .HasOne(a => a.CompanyProfile)
                .WithMany(b => b.CompanyDescriptions)
                .HasForeignKey(a=>a.Company);
            modelBuilder.Entity<CompanyDescriptionPoco>()
                .HasOne(a => a.SystemLanguageCode)
                .WithMany(b => b.CompanyDescriptions)
                .HasForeignKey(a => a.LanguageId);
            modelBuilder.Entity<CompanyJobEducationPoco>()
               .HasKey(t => t.Id);
            modelBuilder.Entity<CompanyJobEducationPoco>()
               .Property(a => a.TimeStamp)
               .IsRowVersion();
            modelBuilder.Entity<CompanyJobEducationPoco>()
                .HasOne(a => a.CompanyJob)
                .WithMany(b => b.CompanyJobEducations)
                .HasForeignKey(a => a.Job);
            modelBuilder.Entity<CompanyJobSkillPoco>()
               .HasKey(t => t.Id);
            modelBuilder.Entity<CompanyJobSkillPoco>()
               .Property(a => a.TimeStamp)
               .IsRowVersion();
            modelBuilder.Entity<CompanyJobSkillPoco>()
                .HasOne(a => a.CompanyJob)
                .WithMany(b => b.CompanyJobSkills)
                .HasForeignKey(a => a.Job);
            modelBuilder.Entity<CompanyJobPoco>()
               .HasKey(t => t.Id);
            modelBuilder.Entity<CompanyJobPoco>()
               .Property(a => a.TimeStamp)
               .IsRowVersion();
            modelBuilder.Entity<CompanyJobPoco>()
                .HasOne(a => a.CompanyProfile)
                .WithMany(b => b.CompanyJobs)
                .HasForeignKey(a => a.Company);
            modelBuilder.Entity<CompanyJobDescriptionPoco>()
               .HasKey(t => t.Id);
            modelBuilder.Entity<CompanyJobDescriptionPoco>()
               .Property(a => a.TimeStamp)
               .IsRowVersion();
            modelBuilder.Entity<CompanyJobDescriptionPoco>()
                .HasOne(a => a.CompanyJob)
                .WithMany(b => b.CompanyJobDescriptions)
                .HasForeignKey(a => a.Job);
            modelBuilder.Entity<CompanyLocationPoco>()
               .HasKey(t => t.Id);
            modelBuilder.Entity<CompanyLocationPoco>()
               .Property(a => a.TimeStamp)
               .IsRowVersion();
            modelBuilder.Entity<CompanyLocationPoco>()
                .HasOne(a => a.CompanyProfile)
                .WithMany(b => b.CompanyLocations)
                .HasForeignKey(a => a.Company);
            modelBuilder.Entity<CompanyProfilePoco>()
               .HasKey(t => t.Id);
            modelBuilder.Entity<CompanyProfilePoco>()
               .Property(a => a.TimeStamp)
               .IsRowVersion();
            modelBuilder.Entity<SecurityLoginPoco>()
               .HasKey(t => t.Id);
            modelBuilder.Entity<SecurityLoginPoco>()
               .Property(a => a.TimeStamp)
               .IsRowVersion();
            modelBuilder.Entity<SecurityLoginsLogPoco>()
               .HasKey(t => t.Id);
            modelBuilder.Entity<SecurityLoginsLogPoco>()
                .HasOne(a => a.SecurityLogin)
                .WithMany(b => b.SecurityLoginsLogs)
                .HasForeignKey(a => a.Login);
            modelBuilder.Entity<SecurityLoginsRolePoco>()
               .HasKey(t => t.Id);
            modelBuilder.Entity<SecurityLoginsRolePoco>()
               .Property(a => a.TimeStamp)
               .IsRowVersion();
            modelBuilder.Entity<SecurityLoginsRolePoco>()
                .HasOne(a => a.SecurityLogin)
                .WithMany(b => b.SecurityLoginsRoles)
                .HasForeignKey(a => a.Login);
            modelBuilder.Entity<SecurityLoginsRolePoco>()
               .HasOne(a => a.SecurityRole)
               .WithMany(b => b.SecurityLoginsRoles)
               .HasForeignKey(a => a.Role);
            modelBuilder.Entity<SecurityRolePoco>()
               .HasKey(t => t.Id);
            modelBuilder.Entity<SystemCountryCodePoco>()
               .HasKey(t => t.Code);
            modelBuilder.Entity<SystemLanguageCodePoco>()
               .HasKey(t => t.LanguageID);

















            base.OnModelCreating(modelBuilder);
        }
    }
}

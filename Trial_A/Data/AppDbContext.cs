using Microsoft.EntityFrameworkCore;
using Trial_A.Models;

namespace Trial_A.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<CandidateProfile> CandidateProfiles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Application>()
                .HasIndex(c => new
                {
                    c.JobId,
                    c.CandidateProfileId
                }
                ).IsUnique();




            modelBuilder.Entity<User>()
                .HasOne(c => c.CandidateProfile)
                .WithOne(c => c.Candidate)
                .HasForeignKey<CandidateProfile>(c => c.CandidateId);

            modelBuilder.Entity<User>()
                .HasMany(c => c.Companies)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Jobs)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId);

            modelBuilder.Entity<CandidateProfile>()
                .HasMany(c => c.Applications)
                .WithOne(c => c.CandidateProfile)
                .HasForeignKey(c => c.CandidateProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Job>()
                .HasMany(c => c.Applications)
                .WithOne(c => c.Job)
                .HasForeignKey(c => c.JobId);



            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed@example.com",
                    Password = "123456",
                    Role = "Candidate",
                    CreateAt = new DateTime(2026,9,1),
                },
                new User
                {
                    Id = 2,
                    FullName = "Ahmed Hassan2",
                    Email = "ahmed2@example.com",
                    Password = "123456",
                    Role = "Candidate",
                    CreateAt = new DateTime(2026,10,1),
                },
                new User
                {
                    Id = 3,
                    FullName = "Sara Mohammed",
                    Email = "sara@example.com",
                    Password = "123456",
                    Role = "Employer",
                    CreateAt = new DateTime(2026,9,2),
                },
                new User
                {
                    Id = 4,
                    FullName = "Sara Mohammed2",
                    Email = "sara2@example.com",
                    Password = "123456",
                    Role = "Employer",
                    CreateAt = new DateTime(2026,9,5),
                },
                new User
                {
                    Id = 5,
                    FullName = "Omar Ali",
                    Email = "omar@example.com",
                    Password = "123456",
                    Role = "Admin",
                    CreateAt = new DateTime(2026,9,3),
                }
            );

            modelBuilder.Entity<CandidateProfile>().HasData(
                new CandidateProfile
                {
                    Id = 1,
                    Phone = "011234567890",
                    ResumeUrl = "url1.com",
                    Skill = "Asp.Net",
                    YearsOfExperience = 3,
                    CandidateId = 1,
                },
                new CandidateProfile
                {
                    Id = 2,
                    Phone = "0112345690",
                    ResumeUrl = "url2.com",
                    Skill = "Java",
                    YearsOfExperience = 2,
                    CandidateId = 2,
                }
            );

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "Tech1",
                    Description = "Desc1",
                    Website = "web1.com",
                    Location = "Cairo",
                    UserId = 3
                },
                new Company
                {
                    Id = 2,
                    Name = "Tech2",
                    Description = "Desc2",
                    Website = "web2.com",
                    Location = "Giza",
                    UserId = 4
                }
            );

            modelBuilder.Entity<Job>().HasData(
                new Job
                {
                    Id = 1,
                    Title = "BackEnd",
                    Description = "Desc1",
                    Salary = 30000,
                    Location = "Cairo",
                    EmploymentType = "FullTime",
                    PostedDate = new DateTime(2026, 10, 1),
                    DeadLine = new DateTime(2026, 11,1),
                    Status = "Open",
                    CompanyId = 1,
                },
                new Job
                {
                    Id = 2,
                    Title = "Backend",
                    Description = "Desc2",
                    Salary = 40000,
                    Location = "Cairo",
                    EmploymentType = "PartTime",
                    PostedDate = new DateTime(2026, 10, 1),
                    DeadLine = new DateTime(2026, 11,1),
                    Status = "Open",
                    CompanyId = 2,
                }
            );

            modelBuilder.Entity<Application>().HasData(
                new Application
                {
                    Id = 1,
                    ApplicationDate = new DateTime(2026, 10, 5),
                    Status = "Pending",
                    CoverLetter = "cover1",
                    CandidateProfileId = 1,
                    JobId = 1,
                },
                new Application
                {
                    Id = 2,
                    ApplicationDate = new DateTime(2026, 10, 5),
                    Status = "UnderReview",
                    CoverLetter = "cover2",
                    CandidateProfileId = 2,
                    JobId = 2,
                }
            );
        }
    }
}

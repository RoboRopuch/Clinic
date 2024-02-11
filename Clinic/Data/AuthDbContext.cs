using Clinic.Models.Domain_Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Clinic.Data
{
    public class AuthDbContext : IdentityDbContext

    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }


        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visits> Visits { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ... other configurations ...

            // Configure the relationship between Doctor and IdentityUser
            builder.Entity<Doctor>()
                .HasOne(d => d.User)
                .WithOne()
                .HasForeignKey<Doctor>(d => d.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the relationship between Patient and IdentityUser
            builder.Entity<Patient>()
                .HasOne(d => d.User)
                .WithOne()
                .HasForeignKey<Patient>(d => d.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the relationship between Visits and Patient
            builder.Entity<Visits>()
                .HasOne(v => v.Patient)
                .WithMany(d => d.Visits)
                .HasForeignKey(v => v.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull); // Change to ClientSetNull

            // Configure the relationship between Visits and Doctor
            builder.Entity<Visits>()
                .HasOne(v => v.Doctor)
                .WithMany(d => d.Visits)
                .HasForeignKey(v => v.DoctorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the relationship between Shifts and Doctor
            builder.Entity<Schedule>()
                .HasOne(s => s.Doctor)
                .WithMany(d => d.Shifts)
                .HasForeignKey(s => s.DoctorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Visits>()
                .Property(v => v.RowVersion)
                .IsConcurrencyToken();

            var adminRoleId = "f7a96128-02a7-4ab3-baa6-48e3bd2a4c7a";
            var userRoleId = "970cafb7-19b1-44f7-b049-470da43e8dac";
            var preUserRoleID = "ab32a7e8-7252-4500-8cb5-ad5c11522d6f";
            var doctorRoleID = "b29db713-b2a2-4114-bfb6-d6653280e9d0";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name= "admin",
                    NormalizedName= "admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId

                },

                new IdentityRole
                {
                    Name = "PreUser",
                    NormalizedName = "PreUser",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                },

                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = preUserRoleID,
                    ConcurrencyStamp = preUserRoleID
                },

                new IdentityRole
                {
                    Name = "Doctor",
                    NormalizedName = "Doctor",
                    Id = doctorRoleID,
                    ConcurrencyStamp = doctorRoleID
                }

            };

            builder.Entity<IdentityRole>().HasData(roles);

            var adminId = "7a259adc-a16f-466e-8da6-06214a9f6803";

            var admin = new IdentityUser
            {
                UserName = "admin",
                Email = "admin@clinic.com",
                NormalizedEmail = "admin@clinic.com".ToUpper(),
                NormalizedUserName = "admin".ToUpper(),
                Id = adminId

            };

            var passwordHasher = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Clinic123#");


            builder.Entity<IdentityUser>().HasData(admin);

            var AdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminId
                },
            };

            builder.Entity<IdentityUserRole<string>>().HasData(AdminRoles);


        }



    }

}

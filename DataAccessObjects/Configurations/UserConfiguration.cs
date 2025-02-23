using BusinessObjects.Entities;
using BusinessObjects.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
/*            builder.HasKey(e => e.Id);

            builder.Property(e => e.Email).HasMaxLength(255);
            builder.Property(e => e.Fullname).HasMaxLength(255);
            builder.Property(e => e.Gender).HasMaxLength(50);
            builder.Property(e => e.PhoneNumber).HasMaxLength(50);

            builder.Property(e => e.Role)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(e => e.Status)
                .HasConversion<string>()
            .HasMaxLength(20);*/

            builder.HasData(
            new User
            {
                Id = 1,
                Fullname = "John Doe",
                Email = "john.doe@example.com",
                Password = "admin123",
                PhoneNumber = "0123456789",
                Role = Role.Admin,
                Gender = "Male",
                Birthday = new DateOnly(1990, 5, 10),
                Status = UserStatus.Active,
            },
            new User
            {
                Id = 2,
                Fullname = "Jane Smith",
                Email = "jane.smith@example.com",
                Password = "user123",
                PhoneNumber = "0987654321",
                Role = Role.Professional,
                Gender = "Female",
                Birthday = new DateOnly(1995, 8, 15),
                Status = UserStatus.Active,
            },
            new User
            {
                Id = 3,
                Fullname = "Alice Johnson",
                Email = "alice.johnson@example.com",
                Password = "password789",
                PhoneNumber = "0112233445",
                Role = Role.Patient,
                Gender = "Female",
                Birthday = new DateOnly(2000, 3, 22),
                Status = UserStatus.Inactive,
            },
            new User
            {
                Id = 4,
                Fullname = "Bob Williams",
                Email = "bob.williams@example.com",
                Password = "securepass",
                PhoneNumber = "0223344556",
                Role = Role.Patient,
                Gender = "Male",
                Birthday = new DateOnly(1992, 7, 5),
                Status = UserStatus.Active,
            },
            new User
            {
                Id = 5,
                Fullname = "Eve Adams",
                Email = "eve.adams@example.com",
                Password = "mypassword",
                PhoneNumber = "0334455667",
                Role = Role.Patient,
                Gender = "Female",
                Birthday = new DateOnly(1988, 11, 30),
                Status = UserStatus.Active,
            }
        );
        }
    }
}

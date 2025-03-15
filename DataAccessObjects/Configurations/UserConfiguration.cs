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
            builder.HasKey(x => x.Id);


            builder.HasOne(u => u.Patient)
                   .WithOne(p => p.User)
                   .HasForeignKey<Patient>(p => p.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.Professional)
                 .WithOne(p => p.User)
                 .HasForeignKey<Professional>(p => p.UserId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Articles)
                .WithOne(a => a.CreatedBy)
                .HasForeignKey(a => a.CreatedById)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                 new User
                 {
                     Id = 1,
                     Role = Role.Admin,
                     Fullname = "Admin",
                     Email = "admin@example.com",
                     Password = "ad123456",
                     PhoneNumber = "0901234567",
                     Gender = "Nam",
                     Birthday = new DateOnly(1990, 1, 1),
                     Status = UserStatus.Active
                 },
                 new User
                 {
                    Id = 2,
                    Role = Role.Patient,
                    Fullname = "Trần Thị B",
                    Email = "patient1@example.com",
                    Password = "pa123456",
                    PhoneNumber = "0902345678",
                    Gender = "Nữ",
                    Birthday = new DateOnly(1995, 5, 20),
                    Status = UserStatus.Active
                 },
                new User
                {
                Id = 3,
                Role = Role.Patient,
                Fullname = "Nguyễn Thị C",
                Email = "patient2@example.com",
                Password = "pa123456",
                PhoneNumber = "0903456789",
                Gender = "Nữ",
                Birthday = new DateOnly(1996, 10, 12),
                Status = UserStatus.Active
                },
                new User
                {
                Id = 4,
                Role = Role.Professional,
                Fullname = "Lê Minh D",
                Email = "professional1@example.com",
                Password = "pro123456",
                PhoneNumber = "0904567890",
                Gender = "Nam",
                Birthday = new DateOnly(1985, 3, 15),
                Status = UserStatus.Active
                },
                new User
                {
                Id = 5,
                Role = Role.Professional,
                Fullname = "Phan Minh E",
                Email = "professional2@example.com",
                Password = "pro123456",
                PhoneNumber = "0905678901",
                Gender = "Nam",
                Birthday = new DateOnly(1987, 7, 30),
                Status = UserStatus.Inactive
                }
            );
        }
    }
}

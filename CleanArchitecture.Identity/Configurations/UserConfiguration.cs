using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                 new ApplicationUser
                 {
                     Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                     Email = "admin@admin.com",
                     NormalizedEmail = "ADMIN@ADMIN.COM",
                     FirstName = "System",
                     LastName = "Admin",
                     UserName = "admin@admin.com",
                     NormalizedUserName = "ADMIN@ADMIN.COM",
                     PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
                     EmailConfirmed = true
                 },
                 new ApplicationUser
                 {
                     Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                     Email = "user@admin.com",
                     NormalizedEmail = "USER@USER.COM",
                     FirstName = "System",
                     LastName = "User",
                     UserName = "user@user.com",
                     NormalizedUserName = "USER@USER.COM",
                     PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
                     EmailConfirmed = true
                 }
            );
        }
    }
}

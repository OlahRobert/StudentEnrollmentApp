using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentEnrollment.Data;

internal class SchoolUserConfigration : IEntityTypeConfiguration<SchoolUser>
{
    public void Configure(EntityTypeBuilder<SchoolUser> builder)
    {
        var hasher = new PasswordHasher<SchoolUser>();
        builder.HasData(
             new SchoolUser
             {
                 Id = "2f55dc54-68c9-443e-a44c-526d6a64a061",
                 Email = "schooladmin@localhost.com",
                 NormalizedEmail = "SCHOOLADMIN@LOCAHOST.COM",
                 NormalizedUserName = "SCHOOLADMIN@LOCAHOST.COM",
                 UserName = "schooladmin@localhost.com",
                 FirstName = "School",
                 LastName = "Admin",
                 PasswordHash = hasher.HashPassword(null, "P@sswrod1"),
                 EmailConfirmed = true
             },
             new SchoolUser
             {
                 Id = "8f9670f9-b286-4222-bf59-e99dc37511f4",
                 Email = "schooluser@localhost.com",
                 NormalizedEmail = "SCHOOLUSER@LOCAHOST.COM",
                 NormalizedUserName = "SCHOOLUSER@LOCAHOST.COM",
                 UserName = "schooluser@localhost.com",
                 FirstName = "School",
                 LastName = "User",
                 PasswordHash = hasher.HashPassword(null, "P@sswrod1"),
                 EmailConfirmed = true
             }
            ); ;
    }
}


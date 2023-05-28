using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentEnrollment.Data.Configurations
{
    internal class RoleConfigration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                 new IdentityRole
                 {
                     Id = "7a7f98ed-9e6f-491e-ac1c-7f10e40378c2",
                     Name = "Administrator",
                     NormalizedName = "ADMINISTRATOR"
                 },
                 new IdentityRole
                 {
                     Id = "581a8514-de3d-42f8-be90-5497c4411055",
                     Name = "User",
                     NormalizedName = "USER"
                 }
                );
        }
    }

}

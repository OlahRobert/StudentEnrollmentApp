using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentEnrollment.Data.Configurations
{
    internal class UserRoleConfigration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                 new IdentityUserRole<string>
                 {
                     RoleId = "7a7f98ed-9e6f-491e-ac1c-7f10e40378c2",
                     UserId = "2f55dc54-68c9-443e-a44c-526d6a64a061",
                 },
                 new IdentityUserRole<string>
                 {
                     RoleId = "581a8514-de3d-42f8-be90-5497c4411055",
                     UserId = "8f9670f9-b286-4222-bf59-e99dc37511f4",
                 }
                );
        }
    }

}

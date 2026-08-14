using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using SecureClicker.Data.Models;

namespace SecureClicker.Data;

public class ApplicationModelConfiguration
    : IEntityTypeConfiguration<ProfileApplicationData>
{
    public void Configure(EntityTypeBuilder<ProfileApplicationData> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<IdentityUser>()
            .WithOne()
            .HasForeignKey<ProfileApplicationData>(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
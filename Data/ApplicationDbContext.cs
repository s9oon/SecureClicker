using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecureClicker.Data.Models;

namespace SecureClicker.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<ProfileApplicationData> ProfileApplicationData { get; set; } = null!;
    
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
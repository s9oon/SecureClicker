using Microsoft.EntityFrameworkCore;
using SecureClicker.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace SecureClicker.Data;

public class ApplicationDbContext : DbContext 
{

    public DbSet<IdentityUser> Users { get; set; } = null!;
    public DbSet<ProfileApplicationData> ProfileApplicationData { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) 
    {
    }
} 

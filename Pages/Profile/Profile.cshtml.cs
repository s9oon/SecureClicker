using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecureClicker.Data;
using SecureClicker.Data.Models;

namespace SecureClicker.Pages;

[Authorize]
public class ProfileModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public int Clicks { get; set; }

    public ProfileModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var profile = await _context.ProfileApplicationData.FindAsync(userId);

        Clicks = profile?.Clicks ?? 0;
    }
    public async Task<IActionResult> OnPostClickAsync()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var profile = await _context.ProfileApplicationData.FindAsync(userId);

        if (profile == null)
        {
            return NotFound();
        }

        profile.Clicks++;

        await _context.SaveChangesAsync();

        return new JsonResult(new
        {
            clicks = profile.Clicks
        });
    }
}
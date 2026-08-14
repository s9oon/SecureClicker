using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecureClicker.Data;
using SecureClicker.Data.Models;

namespace SecureClicker.Pages.Authentication;

public class SignUp : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public SignUp(
        ApplicationDbContext context,
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [BindProperty]
    [Required]
    public string Username { get; set; } = "";

    [BindProperty]
    [Required]
    public string Password { get; set; } = "";

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // Add Asyncronous logic to signup button here
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Please fill in all fields.");
            return Page();
        }

        var user = new IdentityUser
        {
            UserName = Username
        };

        var result = await _userManager.CreateAsync(user, Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return Page();
        }

        var applicationData = new ProfileApplicationData
        {
            Id = user.Id,
            Clicks = 0
        };

        _context.ProfileApplicationData.Add(applicationData);

        await _context.SaveChangesAsync();

        await _signInManager.SignInAsync(
            user,
            isPersistent: true);

        return Redirect("/Profile");
    }
}
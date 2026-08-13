using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecureClicker.Data;
using SecureClicker.Data.Models;
using SecureClicker.Authentication;

namespace SecureClicker.Pages.Authentication;


public class SignUp : PageModel
{
    private readonly ApplicationDbContext _context;

    public SignUp(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public string Username { get; set; } = "";

    [BindProperty]
    public string Password { get; set; } = "";

    public void OnGet()
    {
    }

    public void OnPost()
    {
        // Authentication logic goes here
        var user = new IdentityUser
        {
            UserName = Username,
        };

        user.PasswordHash = AuthenticationService.HashPassword(user, Password);

        _context.Users.Add(user);

        var applicationData = new ProfileApplicationData
        {
            Id = user.Id,
            Clicks = 0
        };

        _context.ProfileApplicationData.Add(applicationData);

        _context.SaveChanges();
    }
}
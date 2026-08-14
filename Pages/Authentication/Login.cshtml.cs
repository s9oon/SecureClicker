namespace SecureClicker.Pages.Authentication;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.Identity;

public class Login : PageModel
{
    [BindProperty]
    [Required]
    public string Username { get; set; } = "";

    [BindProperty]
    [Required]
    public string Password { get; set; } = "";

    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public Login(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
    {   
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // Add Asyncronous logic to login button here

        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Please fill in all fields.");
            return Page();
        }

        var user = await _userManager.FindByNameAsync(Username);

        if (user == null)
        {
            ModelState.AddModelError("", "Invalid username or password.");
            return Page();
        }

        var result = await _signInManager.PasswordSignInAsync(
            user,
            Password,
            isPersistent: true,
            lockoutOnFailure: true);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Invalid username or password.");
            return Page();
        }

        return Redirect("/Profile");
    }   
}
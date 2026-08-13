using Microsoft.AspNetCore.Identity;

namespace SecureClicker.Authentication;

public class AuthenticationService
{
    private static readonly PasswordHasher<IdentityUser> _hasher = new();

    public static string HashPassword(IdentityUser user, string password)
    {
        return _hasher.HashPassword(user, password);
    }
}
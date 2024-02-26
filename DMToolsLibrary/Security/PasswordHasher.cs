using DMTools.Database;
using DMTools.Database.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolsLibrary.Security;

/// <summary>
/// Hashes and verifies passwords.
/// </summary>
internal class PasswordHasher
{
    /// <summary>
    /// The actual password hasher.
    /// </summary>
    private IPasswordHasher<User> passwordHasher;

    /// <summary>
    /// Creates an instance of the pass slinging - hash slinging - mash singing - password hasher
    /// </summary>
    internal PasswordHasher()
    {
        passwordHasher = new PasswordHasher<User>();
    }

    /// <summary>
    /// Hashes a password and gives it to the user object (for storage in db)
    /// </summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    internal User HashPassword(User user, string password)
    {
        user.Password = passwordHasher.HashPassword(user, password);

        return user;
    }

    internal (bool, User?) VerifyPassword(User user, string hashedPassword, string providedPassword)
    {
        PasswordVerificationResult isVerified = passwordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);

        // return true when necessary. Otherwise, return false in case of anything else
        switch (isVerified)
        {
            case PasswordVerificationResult.Success:
                return (true, null);
            case PasswordVerificationResult.SuccessRehashNeeded:
                user = this.HashPassword(user, providedPassword);
                return (true, user);
            case PasswordVerificationResult.Failed:
            default:
                return (false, null);
        }
    }
}

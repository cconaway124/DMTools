using DMTools.Database.Entities;
using DMTools.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DMToolsLibrary.Enums.LibraryEnums;

namespace DMToolsLibrary.Security;

/// <summary>
/// Handles authentication of the user.
/// </summary>
public class Authenticator
{
    /// <summary>
    /// The database.
    /// </summary>
    private readonly DmtoolsContext _dmToolsContext;

    /// <summary>
    /// Creates an instance of the db.
    /// </summary>
    /// <param name="dmtoolsContext"> The injected DB.</param>
    public Authenticator(DmtoolsContext dmtoolsContext)
    {
        _dmToolsContext = dmtoolsContext;
    }

    /// <summary>
    /// Authenticates the user.
    /// </summary>
    /// <param name="loginUser"> The user to authenticate. </param>
    /// <returns> Whether or not the user successfully logged in. </returns>
    public UserLoginType Authorize(User loginUser)
    {
        User user = _dmToolsContext.Users.FirstOrDefault(user => user.UserName == loginUser.UserName || user.UserName == loginUser.UserEmail);

        // stop if user name or email is not in db
        if (user == null)
        {
            return UserLoginType.NotFound;
        }

        // get whether password was correct or not
        PasswordHasher hasher = new PasswordHasher();
        (bool isCorrectPassword, User? foundUser) = hasher.VerifyPassword(loginUser, user.Password, loginUser.Password);

        // go no further is the user is not found
        if (!isCorrectPassword)
        {
            return UserLoginType.WrongPassword;
        }
        
        // if not null, we found an out of date hash alg, so update hashed pass
        if (foundUser != null)
        {
            user = hasher.HashPassword(user, loginUser.Password);
            _dmToolsContext.Update(user);
            _dmToolsContext.SaveChangesAsync();
        }

        return UserLoginType.Success;
    }
}

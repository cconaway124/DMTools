using DMTools.Database;
using DMTools.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolsLibrary.Security;

public class UserFunctions : IUserFunctions
{
    private readonly DmtoolsContext _dmtoolsContext;

    public UserFunctions(DmtoolsContext dmtoolsContext)
    {
        _dmtoolsContext = dmtoolsContext;
    }

    public bool CreateUser(User user)
    {
        // user already exists
        User exist = _dmtoolsContext.Users.FirstOrDefault(existUser => existUser.UserEmail == user.UserEmail);
        if (exist != null)
        {
            return false;
        }

        PasswordHasher hasher = new PasswordHasher();
        user = hasher.HashPassword(user, user.Password);
        user.UserGuid = Guid.NewGuid();

        try
        {
            _dmtoolsContext.Users.Add(user);
            _dmtoolsContext.SaveChanges();
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }

}

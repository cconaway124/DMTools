using DMTools.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.Security;

public interface IAuthenticator
{
    public UserLoginType Authorize(User loginUser);
}

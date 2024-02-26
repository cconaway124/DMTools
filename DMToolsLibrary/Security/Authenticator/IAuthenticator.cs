using DMTools.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DMToolsLibrary.Enums.LibraryEnums;

namespace DMToolsLibrary.Security;

public interface IAuthenticator
{
    public UserLoginType Authorize(User loginUser);
}

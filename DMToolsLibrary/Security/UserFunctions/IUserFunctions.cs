using DMTools.Database.Entities;

namespace DMToolsLibrary.Security;

public interface IUserFunctions
{
    public bool CreateUser(User user);
}

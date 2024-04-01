using DMTools.Database.Entities;

namespace DMTools.Security;

public interface IUserFunctions
{
    public bool CreateUser(User user);
}

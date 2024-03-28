using System.Security.Claims;
using System.Threading.Tasks;
using DMTools.Database;
using DMTools.Database.Entities;
using DMTools.Security;
using Microsoft.AspNetCore.Components.Authorization;
using static DMTools.Shared.Enums.LibraryEnums;


namespace DMTools.Blazor;

public class DmToolsAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly DmtoolsContext dmToolsContext;
    private readonly IAuthenticator authenticator;

    private ClaimsPrincipal? user;

    public DmToolsAuthenticationStateProvider(DmtoolsContext dmToolsContext, IAuthenticator authenticator)
    {
        this.dmToolsContext = dmToolsContext;
        this.authenticator = authenticator;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();
        var user = new ClaimsPrincipal(identity);

        return Task.FromResult(new AuthenticationState(this.user ?? user));
    }

    public UserLoginType AuthenticateUser(User user)
    {

        if (authenticator.Authorize(user) != UserLoginType.Success)
        {
            return UserLoginType.NotFound;
        }

        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, user.UserName),
        }, "Custom Authentication");

        var claimUser = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(claimUser)));
        this.user = claimUser;

        return UserLoginType.Success;
    }
}

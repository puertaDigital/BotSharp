using BotSharp.Abstraction.Users;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BotSharp.Core.Users.Services;

public class UserIdentity : IUserIdentity
{
    private readonly IHttpContextAccessor _contextAccessor;
    private IEnumerable<Claim> _claims => _contextAccessor.HttpContext.User.Claims;

    public UserIdentity(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }


    public string Id => _claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

    public string Email => _claims.First(x => x.Type == ClaimTypes.Email).Value;

    public string FirstName => _claims.First(x => x.Type == ClaimTypes.GivenName).Value;

    public string LastName => _claims.First(x => x.Type == ClaimTypes.Surname).Value;
}

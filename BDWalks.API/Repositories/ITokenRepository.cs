using Microsoft.AspNetCore.Identity;

namespace BDWalks.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}

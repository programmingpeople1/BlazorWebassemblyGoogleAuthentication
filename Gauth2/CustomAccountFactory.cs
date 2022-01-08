using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

namespace Gauth2
{
    public class CustomAccountFactory : AccountClaimsPrincipalFactory<CustomUserAccount>
    {
        public CustomAccountFactory(IAccessTokenProviderAccessor accessor) : base(accessor)
        {}

        public override async ValueTask<ClaimsPrincipal> CreateUserAsync(CustomUserAccount account, RemoteAuthenticationUserOptions options)
        {
            var initialUser = await base.CreateUserAsync(account, options);

            if (initialUser.Identity.IsAuthenticated)
            {
                ((ClaimsIdentity) initialUser.Identity).AddClaim(new Claim(ClaimTypes.Email, account.Email));
                ((ClaimsIdentity) initialUser.Identity).AddClaim(new Claim(ClaimTypes.Uri, account.Picture, ClaimValueTypes.String));
            }

            return initialUser;
        }
    }
}
using System;
using System.Security.Claims;
using System.Security.Principal;

namespace ClubIS.IdentityStore
{
    public static class IdentityExtensions
    {
        public static int GetUserId(this IIdentity identity)
        {
            Claim claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null)
            {
                throw new ArgumentException("Cannot get UserId for Unauthenticated user");
            }
            return int.Parse(claim.Value);
        }
    }
}

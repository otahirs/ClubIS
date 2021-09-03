using System;
using System.Security.Claims;
using System.Security.Principal;

namespace ClubIS.CoreLayer
{
    public static class IdentityExtensions
    {
        public static int GetUserId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null)
                throw new ArgumentException("Cannot get UserId for Unauthenticated user");
            return int.Parse(claim.Value);
        }
    }
}
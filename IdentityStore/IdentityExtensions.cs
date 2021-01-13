using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace ClubIS.IdentityStore
{
    public static class IdentityExtensions
    {
        public static int GetUserId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null)
            {
                throw new ArgumentException("Cannot get UserId for Authenticated user");
            }
            return int.Parse(claim.Value);
        }
    }
}

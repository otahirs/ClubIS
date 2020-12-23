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
            // Test for null to avoid issues during local testing
            return (claim != null) ? int.Parse(claim.Value) : -1;
        }
    }
}

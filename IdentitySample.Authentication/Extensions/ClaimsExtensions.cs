using System;
using System.Security.Claims;
using System.Security.Principal;

namespace IdentitySample.Authentication.Extensions;

public static class ClaimsExtensions
{
    public static string GetClaimValue(this IPrincipal user, string claimType)
    {
        return ((ClaimsPrincipal)user).FindFirst(claimType)?.Value;
    }


    public static string GetUserId(this IPrincipal user)
    {
        return GetClaimValue(user, ClaimTypes.NameIdentifier);
    }
}


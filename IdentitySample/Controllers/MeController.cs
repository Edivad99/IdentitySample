using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdentitySample.Authentication;
using IdentitySample.Authentication.Extensions;

namespace IdentitySample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MeController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult GetMe()
    {
        var userId = User.GetUserId();
        var userName = User.GetClaimValue(ClaimTypes.Name);
        var isAdministrator = User.IsInRole(RoleNames.Administrator);

        return NoContent();
    }
}

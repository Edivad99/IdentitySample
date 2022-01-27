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
public class InvoicesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetInvoices()
    {
        return NoContent();
    }

    [HttpPost]
    public IActionResult SaveInvoice()
    {
        return NoContent();
    }
}

using System;
using System.Text;
using System.Security.Claims;
using IdentitySample.BusinessLayer.Settings;
using IdentitySample.Shared.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using IdentitySample.Authentication;

namespace IdentitySample.BusinessLayer.Services;

public class IdentityService : IIdentityService
{
    private readonly JwtSettings jwtSettings;

    public IdentityService(IOptions<JwtSettings> jwtSettingsOptions)
    {
        this.jwtSettings = jwtSettingsOptions.Value;
    }

    public Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        if (request.Username == request.Password)
        {
            //Nei claims puoi aggiungere tutte le informazioni utili che ritieni possano servirti
            //User id del db, username ecc.
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, request.Username),
                new Claim(ClaimTypes.Role, RoleNames.Administrator)
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecurityKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(jwtSettings.Issuer, jwtSettings.Audience, claims,
                DateTime.UtcNow, DateTime.UtcNow.AddDays(10), signingCredentials);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            var response = new AuthResponse { AccessToken = accessToken };
            return Task.FromResult(response);
        }

        return Task.FromResult<AuthResponse>(null); 
    }
}

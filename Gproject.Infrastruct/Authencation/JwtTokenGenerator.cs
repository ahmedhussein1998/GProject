using Gproject.Application.Common.Interfaces.Authentication;
using Gproject.Application.Common.Interfaces.Services;
using Gproject.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gproject.Infrastruct.Authencation;
public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDataTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDataTimeProvider dateTimeProvider,IOptions<JwtSettings> jwtSettings)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtSettings.Value;
    }
    public string GenerateToken(User user)
    {
        var signingCredintial = new SigningCredentials(
                                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                                SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
           new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
           new Claim(JwtRegisteredClaimNames.GivenName, user.FristName),
           new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
           new Claim(JwtRegisteredClaimNames.Jti ,Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddDays(_jwtSettings.ExpiryDays),
            claims: claims,
            signingCredentials: signingCredintial);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}


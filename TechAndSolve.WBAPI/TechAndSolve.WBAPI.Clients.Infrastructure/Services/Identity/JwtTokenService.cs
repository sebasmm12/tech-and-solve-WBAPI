using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TechAndSolve.WBAPI.Clients.Application.Auth.Dtos;
using TechAndSolve.WBAPI.Clients.Application.Auth.Services;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace TechAndSolve.WBAPI.Clients.Infrastructure.Services.Identity;

public class JwtTokenService
    (IConfiguration configuration): ITokenService
{
    public string Generate(TokenGenerationDto tokenGenerationDto)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Name, tokenGenerationDto.userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, tokenGenerationDto.email),
            new Claim(ClaimTypes.Role, tokenGenerationDto.role)
        };

        var jwtKey = configuration["Jwt:Key"]!;
        var issuer = configuration["Jwt:Issuer"]!;
        var audience = configuration["Jwt:Audience"]!;

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expirationDate = DateTime.UtcNow.AddMinutes(20);

        var token = new JwtSecurityTokenHandler().WriteToken(
            new JwtSecurityToken(
                claims: claims,
                expires: expirationDate,
                signingCredentials: credentials,
                issuer: issuer,
                audience: audience));

        return token;
    }
}
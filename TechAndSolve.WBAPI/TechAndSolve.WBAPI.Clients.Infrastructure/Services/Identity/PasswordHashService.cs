using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using TechAndSolve.WBAPI.Clients.Application.Auth.Dtos;
using TechAndSolve.WBAPI.Clients.Application.Auth.Services;

namespace TechAndSolve.WBAPI.Clients.Infrastructure.Services.Identity;

public class PasswordHashService : IPasswordHashService
{
    public PasswordHashDto Generate(string password)
    {
        var salt = new byte[128 / 8];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        var encryptedPassword = KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8);

        return new(
            PasswordHash: Convert.ToBase64String(encryptedPassword),
            Salt: Convert.ToBase64String(salt));
    }

    public bool Verify(string password, string salt, string passwordHash)
    {
        var encryptedPassword = KeyDerivation.Pbkdf2(
            password: password,
            salt: Convert.FromBase64String(salt),
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8);

        var computedHash = Convert.ToBase64String(encryptedPassword);

        return computedHash == passwordHash;
    }
}
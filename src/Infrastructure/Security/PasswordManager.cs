using Application.Security;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Security;

internal sealed class PasswordManager : IPasswordManager
{
    private readonly IPasswordHasher<User> _passwordHasher;

    public PasswordManager(IPasswordHasher<User> passwordHasher) => _passwordHasher = passwordHasher;

    public string Hash(string password) => _passwordHasher.HashPassword(default, password);

    public bool CompareSecuredPassword(string password, string securedPassword) =>
        _passwordHasher.VerifyHashedPassword(default, securedPassword, password) ==
        PasswordVerificationResult.Success;
}
using Vendagas.API.ORM.Entity;

namespace Vendagas.API.Application.Services.Token
{
    public interface ITokenService
    {
        string GenerateToken(string key, string issuer, string audience, UserModel user);
        //string GenerateToken(UserModel user);
        string? GetUserEmail();
        int GetUserId();

    }
}

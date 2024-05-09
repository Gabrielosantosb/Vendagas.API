using Vendagas.API.ORM.Entity;
using Vendagas.API.ORM.Model.User;

namespace Vendagas.API.Application.Services.User
{
    public interface IUserService
    {
        bool IsEmailTaken(string email);
        UserModel GetUserById();
        UserModel CreateUser(CreateUserModel createUserModel);
        Task<bool> ValidateCredentials(string email, string password);
        Task<UserModel> GetUserByEmailAsync(string email);
    }
}

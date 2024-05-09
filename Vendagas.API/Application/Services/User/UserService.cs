using Vendagas.API.Application.Services.Token;
using Vendagas.API.ORM.Entity;
using Vendagas.API.ORM.Model.User;
using Vendagas.API.ORM.Repository;

namespace Vendagas.API.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly BaseRepository<UserModel> _userRepository;
        private ITokenService _tokenService { get; }


        public UserService(BaseRepository<UserModel> userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public UserModel CreateUser(CreateUserModel createUserModel)
        {
            //Verificar se email já existe
            if (_userRepository.FindAll(e => e.Email == createUserModel.Email).Any())
            {
                throw new Exception("E-mail já está em uso.");

            }

            //Criptografa a senha
            var salt = BCrypt.Net.BCrypt.GenerateSalt(10);
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(createUserModel.Password, salt);

            UserModel newUser = new UserModel
            {
                Username = createUserModel.Username,
                Email = createUserModel.Email,
                Password = hashedPassword,                
            };

            var createdUser = _userRepository.Add(newUser);
            _userRepository.SaveChanges();
            return createdUser;

        }

        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            return await _userRepository.FindAsync(u => u.Email == email);
        }

        public UserModel GetUserById()
        {
            int userId = _tokenService.GetUserId();
            return _userRepository.GetById(userId);
        }

        public bool IsEmailTaken(string email)
        {
            return _userRepository.FindAll(e => e.Email == email).Any();

        }

        public async Task<bool> ValidateCredentials(string email, string password)
        {
            var user = await _userRepository.FindAsync(u => u.Email == email);
            if (user != null)
            {
                bool isPasswordCorrect = VerifyPassword(password, user.Password);
                return isPasswordCorrect;

            }
            return false;
        }

        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedPassword);
        }

    }
}

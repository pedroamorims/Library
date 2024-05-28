using Library.Application.ViewModels;
using Library.Core.Repositories;
using Library.Core.Services;
using MediatR;

namespace Library.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _userRepository.GetByEmailandPasswordAsync(request.Email, passwordHash);

            if (user == null)
            {
                return null;
            }

            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            var loginViewModel = new LoginViewModel(user.Email, token);

            return loginViewModel;
        }
    }
}

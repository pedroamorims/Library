using Library.Core.Repositories;
using MediatR;

namespace Library.Application.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                throw new InvalidOperationException("Usuário não encontrado");
            }

            user.Deactivate();

            await _userRepository.UpdateAsync(user);

            return Unit.Value;

        }
    }
}

using Destructurama.Attributed;
using MediatR;
using RockPaperScissorsLizardSpock.Application.Dtos.Authentication;
using RockPaperScissorsLizardSpock.Application.Interfaces.AuthService;

namespace RockPaperScissorsLizardSpock.Application.UseCases.Auth
{

        public class RegisterCommand : IRequest<UserResponseDTO>
        {
            public string UserName { get; set; }
            [NotLogged]
            public string Password { get; set; }
        }


        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, UserResponseDTO>
        {
            private readonly IIdentityService _identityService;

            public RegisterCommandHandler(IIdentityService identityService)
            {
                _identityService = identityService;
            }

        public async Task<UserResponseDTO> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.CreateUserAsync(request.UserName, request.Password);

            return new UserResponseDTO()
            {
                Id = result.userId,
                UserName = request.UserName
            };

        }
    }
}

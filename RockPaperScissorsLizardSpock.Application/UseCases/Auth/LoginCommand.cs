using Destructurama.Attributed;
using MediatR;
using RockPaperScissorsLizardSpock.Application.Dtos.Authentication;
using RockPaperScissorsLizardSpock.Application.Interfaces.AuthService;

namespace RockPaperScissorsLizardSpock.Application.UseCases.Auth
{

        public class LoginCommand : IRequest<LoginResponseDTO>
        {
            public string UserName { get; set; }
            [NotLogged]
            public string Password { get; set; }
        }


        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDTO>
        {
            private readonly ITokenGenerator _tokenGenerator;
            private readonly IIdentityService _identityService;

            public LoginCommandHandler(IIdentityService identityService, ITokenGenerator tokenGenerator)
            {
                _identityService = identityService;
                _tokenGenerator = tokenGenerator;
            }

            public async Task<LoginResponseDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
            {

                string userId = await _identityService.GetCheckedUserIdAsync(request.UserName, request.Password);
                string token = _tokenGenerator.GenerateJWTToken((userId, request.UserName, null));

                return new LoginResponseDTO()
                {
                    User = new UserResponseDTO()
                    {
                        Id = int.Parse(userId),
                        UserName = request.UserName
                    },
                    AccessToken = token
                };
            }
        }
}

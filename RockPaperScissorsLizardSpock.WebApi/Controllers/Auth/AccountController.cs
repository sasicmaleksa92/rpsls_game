using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissorsLizardSpock.Application.Dtos.Authentication;
using RockPaperScissorsLizardSpock.Application.UseCases.Auth;


namespace RockPaperScissorsLizardSpock.WebApi.Controllers.Accounts
{
    /// <summary>
    /// Controller for handling user accounts actions such as login and registration.
    /// </summary>
    [Authorize]
    [Route("api/accounts")]
    public class AccountController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;


        /// <summary>
        /// Authenticates a user and issues a JWT if the credentials are valid.
        /// </summary>
        /// <param name="request">Contains the username and password of the user attempting to log in.</param>
        /// <returns>A JWT token in the response if authentication is successful.</returns>
        /// <response code="200">Returns the authentication token on successful login.</response>
        /// <response code="400">Returns an error if the credentials are invalid.</response>
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO request)
        {
            return Ok(await _mediator.Send(new LoginCommand { UserName = request.UserName, Password = request.Password}));
        }

        /// <summary>
        /// Registers a new user with the provided credentials.
        /// </summary>
        /// <param name="request">Contains the username and password of the user to be registered.</param>
        /// <returns>A response containing the new user's ID and username if registration is successful.</returns>
        /// <response code="200">Returns the authentication token for the newly registered user.</response>
        /// <response code="400">Returns an error if registration fails due to invalid input or existing user.</response>
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<UserResponseDTO>> Register([FromBody] RegisterRequestDTO request)
        {
            return Ok(await _mediator.Send(new RegisterCommand { UserName = request.UserName, Password = request.Password }));
        }

    }
}
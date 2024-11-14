using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissorsLizardSpock.Application.Dtos;
using RockPaperScissorsLizardSpock.Application.Interfaces.Services;
using RockPaperScissorsLizardSpock.Application.UseCases.GameChoices.Queries.GetAllGameChoices;
using RockPaperScissorsLizardSpock.Application.UseCases.GameResults.Commands.CreateGameResultCommand;
using RockPaperScissorsLizardSpock.Application.UseCases.GameResults.Commands.UpdateGameResultCommand;
using RockPaperScissorsLizardSpock.Application.UseCases.GameResults.Queries.GetAllGameResultsQuery;
using RockPaperScissorsLizardSpock.Application.UseCases.GameResults.Queries.GetByPlayerIdGameResultsQuery;


namespace RockPaperScissorsLizardSpock.Controllers
{
    /// <summary>
    /// Controller responsible for handling game-related actions in the Rock-Paper-Scissors-Lizard-Spock application.
    /// </summary>
    [ApiController]
    [Route("api/game")]
    public class GameController(IMediator mediator,
        IValidator<PlayerChoiceDto> playerChoiceValidator,
        IGameChoiceService gameChoiceService,
        IGameResultService gameResultService) : ControllerBase
    {
        private readonly IGameChoiceService _gameChoiceService = gameChoiceService ?? throw new ArgumentNullException(nameof(gameChoiceService));
        private readonly IGameResultService _gameResultService = gameResultService ?? throw new ArgumentNullException(nameof(gameResultService));
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        private readonly IValidator<PlayerChoiceDto> _playerChoiceValidator = playerChoiceValidator ?? throw new ArgumentNullException(nameof(playerChoiceValidator));


        /// <summary>
        /// Retrieves all game results.
        /// </summary>
        /// <returns>A list of all games played with their results.</returns>
        /// <response code="200">Returns a list of all game results.</response>
        [HttpGet("allGames")]
        public async Task<IActionResult> GetAllGames()
        {
            return Ok(await _mediator.Send(new GetAllGameResultsQuery()));
        }

        /// <summary>
        /// Retrieves game results for a specific player by their ID.
        /// </summary>
        /// <param name="playerId">The ID of the player whose game results to retrieve.</param>
        /// <returns>A list of game results for the specified player.</returns>
        /// <response code="200">Returns the game results of the specified player.</response>
        [HttpGet]
        [Route("allPlayerGames")]
        public async Task<IActionResult> GetPlayerGamesAsync([FromQuery] int playerId)
        {
            return Ok(await _mediator.Send(new GetByPlayerIdGameResultsQuery() { PlayerId = playerId }));
        }

        /// <summary>
        /// Updates an existing game result.
        /// </summary>
        /// <param name="command">Command containing updated game result details.</param>
        /// <returns>Confirmation of the updated game result.</returns>
        /// <response code="200">Returns the updated game result.</response>
        [HttpPatch]
        [Route("updateGameResult")]
        public async Task<IActionResult> UpdateGameResult([FromBody] UpdateGameResultCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Retrieves a list of all possible game choices (e.g., Rock, Paper, Scissors, Lizard, Spock).
        /// </summary>
        /// <returns>A list of available game choices.</returns>
        /// <response code="200">Returns all possible game choices.</response>
        [Route("choices")]
        [HttpGet]
        [ProducesDefaultResponseType(typeof(List<GameChoiceDto>))]
        public async Task<ActionResult<List<GameChoiceDto>>> GetChoices()
        {
            return Ok(await _mediator.Send(new GetAllGameChoicesQuery()));
        }

        /// <summary>
        /// Retrieves a random choice from the available game choices.
        /// </summary>
        /// <returns>A random game choice.</returns>
        /// <response code="200">Returns a random game choice.</response>
        [Route("choice")]
        [ProducesDefaultResponseType(typeof(GameChoiceDto))]
        [HttpGet]
        public async Task<ActionResult<GameChoiceDto>> GetRandomChoice()
        {
            return Ok(await _gameChoiceService.GetRandomGameChoiceAsync());
        }


        /// <summary>
        /// Plays a round of Rock-Paper-Scissors-Lizard-Spock against the computer.
        /// </summary>
        /// <param name="playerChoiceDto">The player's choice for the game.</param>
        /// <returns>The result of the game round.</returns>
        /// <response code="200">Returns the game result including player and computer choices, and the result.</response>
        /// <response code="400">Returns a list of validation errors if the player's choice is invalid.</response>
        [Route("play")]
        [HttpPost]
        [ProducesDefaultResponseType(typeof(GameResultDto))]
        public async Task<ActionResult<GameResultDto>> PlayAgainstComputer([FromBody] PlayerChoiceDto playerChoiceDto)
        {
            var validationResult = _playerChoiceValidator.Validate(playerChoiceDto);
            if (validationResult.IsValid == false)
            {
                return BadRequest(validationResult.Errors);
            }
            var gameResultDto = await _gameResultService.PlayGameWithComputer(playerChoiceDto.Id);

            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                gameResultDto.PlayerId = int.Parse(User.Claims.First(x => x.Type == "UserId").Value);
                gameResultDto.IncludeInScore = true;
            }
            gameResultDto = await _mediator.Send(new CreateGameResultCommand(gameResultDto));

            return Ok(gameResultDto);

        }
    }
}

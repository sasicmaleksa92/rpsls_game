using AutoMapper;
using MediatR;
using RockPaperScissorsLizardSpock.Application.Dtos;
using RockPaperScissorsLizardSpock.Application.Interfaces;
using RockPaperScissorsLizardSpock.Application.Interfaces.Services;
using RockPaperScissorsLizardSpock.Application.UseCases.GameChoices.Queries.GetByIdGameChoice;

namespace RockPaperScissorsLizardSpock.Infrastructure.Services.Game
{
    public class GameChoiceService(IRandomNumberService randomNumberService,
        IRandomNumberGameAdapter randomNumberGameAdapter,
        IMapper mapper, IMediator mediator) : IGameChoiceService
    {
        private readonly IRandomNumberService _randomNumberService = randomNumberService;
        private readonly IRandomNumberGameAdapter _randomNumberGameAdapter = randomNumberGameAdapter;
        private readonly IMapper _mapper = mapper;
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Retrieves a random game choice by generating a random number,
        /// mapping it to a corresponding game choice ID, fetching the game choice from the 
        /// database, and mapping it to a GameChoiceDto.
        /// </summary>
        /// <returns>
        /// A Task representing the asynchronous operation. The Task result contains a 
        /// <see cref="GameChoiceDto"/> representing the random game choice.
        /// </returns>
        public async Task<GameChoiceDto> GetRandomGameChoiceAsync()
        {
            int randomNumber = await _randomNumberService.GetRandomNumberAsync();
            var randomGameChoiceId = _randomNumberGameAdapter.AdaptRange(randomNumber);
            var randomGameChoice = await _mediator.Send(new GetByIdGameChoicesQuery { Id = randomGameChoiceId});
            return _mapper.Map<GameChoiceDto>(randomGameChoice);
        }

    }

}

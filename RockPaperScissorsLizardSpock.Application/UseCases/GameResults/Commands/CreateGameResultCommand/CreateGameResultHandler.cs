using AutoMapper;
using MediatR;
using RockPaperScissorsLizardSpock.Application.Dtos;
using RockPaperScissorsLizardSpock.Application.Interfaces.Repositories;
using RockPaperScissorsLizardSpock.Domain.Entities;

namespace RockPaperScissorsLizardSpock.Application.UseCases.GameResults.Commands.CreateGameResultCommand
{
    public class CreateGameResultHandler(IMapper mapper, IGameResultRepository gameResultRepository) : IRequestHandler<CreateGameResultCommand, GameResultDto>
    {
        private readonly IGameResultRepository _gameResultRepository = gameResultRepository;
        private readonly IMapper _mapper = mapper;


        async Task<GameResultDto> IRequestHandler<CreateGameResultCommand, GameResultDto>.Handle(CreateGameResultCommand command, CancellationToken cancellationToken)
        {
            var navigationProperties = new List<string> { nameof(GameResult.PlayerChoice), nameof(GameResult.GamePlayer) };
            var gameResult = await _gameResultRepository.AddWithLoadingNavigationProperties(_mapper.Map<GameResult>(command.gameResultDto), navigationProperties);
            return _mapper.Map<GameResultDto>(gameResult);
        }
    }
}

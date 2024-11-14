using AutoMapper;
using MediatR;
using RockPaperScissorsLizardSpock.Application.Interfaces.Repositories;

namespace RockPaperScissorsLizardSpock.Application.UseCases.GameResults.Commands.UpdateGameResultCommand
{
    public class UpdateGameResultHandler(IMapper mapper, IGameResultRepository gameResultRepository) : IRequestHandler<UpdateGameResultCommand,bool>
    {
        private readonly IGameResultRepository _gameResultRepository = gameResultRepository;
        private readonly IMapper _mapper = mapper;

        async public Task<bool> Handle(UpdateGameResultCommand request, CancellationToken cancellationToken)
        {
            var gameResults = await _gameResultRepository.GetAsync(filter: x=> x.PlayerId == request.PlayerId);
            foreach (var gameResult in gameResults)
            {
                gameResult.IncludeInScore = request.IncludeInScore;
                await _gameResultRepository.Update(gameResult);
            }
            return true;
        }
    }
}

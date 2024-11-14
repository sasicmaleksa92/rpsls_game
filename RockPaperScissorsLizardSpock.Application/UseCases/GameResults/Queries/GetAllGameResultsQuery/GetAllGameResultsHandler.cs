using AutoMapper;
using MediatR;
using RockPaperScissorsLizardSpock.Application.Dtos;
using RockPaperScissorsLizardSpock.Application.Interfaces.Repositories;
using RockPaperScissorsLizardSpock.Domain.Entities;

namespace RockPaperScissorsLizardSpock.Application.UseCases.GameResults.Queries.GetAllGameResultsQuery
{
    public class GetAllGameResultsHandler(IGameResultRepository gameResultRepository, IMapper mapper) : IRequestHandler<GetAllGameResultsQuery, List<GameResultDto>>
    {
        private readonly IGameResultRepository _gameResultRepository = gameResultRepository;
        private readonly IMapper _mapper = mapper;


        public async Task<List<GameResultDto>> Handle(GetAllGameResultsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<GameResultDto>>(await _gameResultRepository
                .GetAsync(includeProperties: $"{nameof(GameResult.GamePlayer)},{nameof(GameResult.PlayerChoice)},{nameof(GameResult.ComputerChoice)}"));
        }
    };
}

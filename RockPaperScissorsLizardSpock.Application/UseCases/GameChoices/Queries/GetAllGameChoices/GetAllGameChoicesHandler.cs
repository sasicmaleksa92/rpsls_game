using AutoMapper;
using MediatR;
using RockPaperScissorsLizardSpock.Application.Dtos;
using RockPaperScissorsLizardSpock.Application.Interfaces.Repositories;

namespace RockPaperScissorsLizardSpock.Application.UseCases.GameChoices.Queries.GetAllGameChoices
{
    public class GetAllGameChoicesHandler(IGameChoiceRepository gameChoiceRepository, IMapper mapper) : IRequestHandler<GetAllGameChoicesQuery, List<GameChoiceDto>>
    {
        private readonly IGameChoiceRepository _gameChoiceRepository = gameChoiceRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<GameChoiceDto>> Handle(GetAllGameChoicesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<GameChoiceDto>>(await _gameChoiceRepository.GetAsync());
        }
    };
}

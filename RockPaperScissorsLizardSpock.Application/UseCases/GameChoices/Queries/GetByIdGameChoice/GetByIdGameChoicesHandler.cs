using AutoMapper;
using MediatR;
using RockPaperScissorsLizardSpock.Application.Dtos;
using RockPaperScissorsLizardSpock.Application.Interfaces.Repositories;

namespace RockPaperScissorsLizardSpock.Application.UseCases.GameChoices.Queries.GetByIdGameChoice
{
    public class GetByIdGameChoicesHandler(IGameChoiceRepository gameChoiceRepository, IMapper mapper) : IRequestHandler<GetByIdGameChoicesQuery, GameChoiceDto>
    {
        private readonly IGameChoiceRepository _gameChoiceRepository = gameChoiceRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<GameChoiceDto> Handle(GetByIdGameChoicesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<GameChoiceDto>(await _gameChoiceRepository.GetByIdAsync(request.Id));
        }
    };
}

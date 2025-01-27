using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Entities;

namespace NextGen_BM_BE_Application.UseCases.Requests.Create
{

    public sealed class CreateUserBuildingRequestUseCase(IRequestRepository _requestRepository)
    {
        private readonly IRequestRepository requestRepository = _requestRepository;
        public async Task Execute(UserBuildings userBuildings)
        {
            await requestRepository.CreateUserBuildingRequestAsync(userBuildings);
        }
    }
}
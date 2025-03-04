using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Requests.Get
{

    public sealed class GetRequestStatuesUseCase(IRequestRepository requestRepository)
    {
        private readonly IRequestRepository _requestRepository = requestRepository;
        public async Task<IList<Enums>> Execute()
        {
            return await _requestRepository.GetRequestStatusesAsync();
        }
    }
}
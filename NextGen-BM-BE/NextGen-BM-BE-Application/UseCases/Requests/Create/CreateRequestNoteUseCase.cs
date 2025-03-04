using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Requests.Create
{

    public sealed class CreateRequestNotesUseCase(IRequestRepository _requestRepository)
    {
        private readonly IRequestRepository requestRepository = _requestRepository;
        public async Task<RequestNotes> Execute(RequestNotes notes)
        {
            return await requestRepository.CreateRepairRequestNotesAsync(notes);
        }
    }
}
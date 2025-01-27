using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;
using NextGen_BM_BE_Domain.Entities;

namespace NextGen_BM_BE_Application.UseCases.Requests.Create
{

    public sealed class CreateRequestNotesUseCase(IRequestRepository _requestRepository)
    {
        private readonly IRequestRepository requestRepository = _requestRepository;
        public async Task Execute(RequestNotes notes)
        {
            await requestRepository.CreateRepairRequestNotesAsync(notes);
        }
    }
}
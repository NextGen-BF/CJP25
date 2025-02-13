using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Entities.RequestAggregate;

namespace NextGen_BM_BE_Application.UseCases.Requests.Update
{

    public sealed class UpdateRequestNoteUseCase(IRequestRepository _requestRepository)
    {
        private readonly IRequestRepository requestRepository = _requestRepository;
        public async Task Execute(RequestNotes requestNote)
        {
            await requestRepository.UpdateRequestNotesAsync(requestNote);
        }
    }
}
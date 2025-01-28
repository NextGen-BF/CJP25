using Ardalis.Specification;
namespace NextGen_BM_BE_Domain.Entities.RequestAggregate.Specifications{

    public class RequestNotesSpecification: Specification<RepairRequest>{

        public RequestNotesSpecification(int requestID)
        {
            Query.Where(request => request.RepairRequestId == requestID)
            .Include(request => request.Notes);
        }
    }
};
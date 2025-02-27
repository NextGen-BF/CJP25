using NextGen_BM_BE_Domain.Entities.RequestAggregate;

namespace NextGen_BM_BE_Domain.Entities
{

    public class RequestFiles
    {
        public int RequestFilesId { get; set; }
        public required string FilePath { get; set; }
        public required string RequestType { get; set; }
        public int RepairRequestId { get; set; }
        public int UserBuildingId { get; set; }
        public RepairRequest? RepairRequest { get; set; }
        public UserBuildings? UserBuilding { get; set; }
    }
}
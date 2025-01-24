namespace NextGen_BM_BE_Domain.Entities.RequestAggregate;

public class RepairRequest{
    public int RequestId { get; set; }
    public int UserId { get; set; }
    public string RequestDescription { get; set; }
    public int RequestStatus { get; set; }
    public DateOnly DateOpened { get; set; }
    public DateOnly DateSettled {get; set;}
    public ICollection<RequestNotes> notes {get; set;}
}

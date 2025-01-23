namespace NextGen_BM_BE_Domain.Entities.PropertyAggregate{
public class PropertyResidents{
    public int ResidentHistoryID { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int ResidentTypeID { get; set; }
    public int PropertyID { get; set; }
    public DateOnly EnterDate { get; set; }
    public DateOnly LeaveDate { get; set; }
}
};
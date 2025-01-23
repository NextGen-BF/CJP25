namespace NextGen_BM_BE_Domain.Entities{
public class PropertyResidents{
    public int ResidentHistoryID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ResidentTypeID { get; set; }
    public int PropertyID { get; set; }
    public DateOnly EnterDate { get; set; }
    public DateOnly LeaveDate { get; set; }
}
};
namespace NextGen_BM_BE_Domain;
public class UserBuildings{
    public int UserID { get; set; }
    public int BuildingID { get; set; }
    public bool Approved { get; set; }
    public int Role { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}
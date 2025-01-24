namespace NextGen_BM_BE_Domain.Entities.BuildingAggregate;
public class Building{
    public int BuildingID { get; set; }
    public int AddressID {get; set; }
    public string? Alias { get; set; }
    public int FloorNum { get; set; }
    public double TotalBuildingSize { get; set; }
    public DateOnly DateBuilt { get; set; }
    public int NumOfElevators { get; set; }
    public required Address BuildingAddress { get; set;}
    public List<BuildingExpense>? BuildingExpenses { get; set;}
}
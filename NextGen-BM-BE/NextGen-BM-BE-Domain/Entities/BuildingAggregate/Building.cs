namespace NextGen_BM_BE_Domain.Entities.BuildingAggregate;

public class Building
{
    public int BuildingId { get; set; }
    public int AddressId { get; set; }
    public string? Alias { get; set; }
    public int FloorNum { get; set; }
    public double TotalBuildingSize { get; set; }
    public DateOnly DateBuilt { get; set; }
    public int NumOfElevators { get; set; }
    public required Address BuildingAddress { get; set; }
    public ICollection<BuildingExpense>? BuildingExpenses { get; set; }
}

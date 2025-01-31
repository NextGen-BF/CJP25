namespace NextGen_BM_BE_Domain.ViewModels{

    public class BuildingViewModel{
        public int BuildingId { get; set; }
        public required AddressViewModel BuildingAddress { get; set; }
        public string? Alias { get; set; }
        public int FloorNum { get; set; }
        public double TotalBuildingSize { get; set; }
        public DateOnly DateBuilt { get; set; }
        public int NumOfElevators { get; set; }
        public List<BuildingExpenseViewModel>? BuildingExpenses { get; set; }
        public List<PropertyViewModel>? BuildingProperties { get; set; }
    }
}
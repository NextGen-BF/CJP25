namespace NextGen_BM_BE_Application.ViewModels{

    class BuildingViewModel{
        public int BuildingId { get; set; }
        public required AddressViewModel Address { get; set; }
        public string? Alias { get; set; }
        public int FloorNum { get; set; }
        public double TotalBuildingSize { get; set; }
        public DateOnly DateBuilt { get; set; }
        public int NumOfElevators { get; set; }
        public List<BuildingExpenseViewModel>? Expenses { get; set; }
        public List<PropertyViewModel>? BuildingProperties { get; set; }
    }
}
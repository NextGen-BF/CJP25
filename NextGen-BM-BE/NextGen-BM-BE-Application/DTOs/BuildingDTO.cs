namespace NextGen_BM_BE_Application.DTOs{

    class BuildingDTO{
        public int BuildingId { get; set; }
        public AddressDTO Address { get; set; }
        public string Alias { get; set; }
        public int FloorNum { get; set; }
        public double TotalBuildingSize { get; set; }
        public DateOnly DateBuilt { get; set; }
        public int NumOfElevators { get; set; }
        public List<BuildingExpenseDTO>? Expenses { get; set; }
        public List<PropertyDTO>? BuildingProperties { get; set; }
    }
}
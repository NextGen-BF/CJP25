namespace NextGen_BM_BE_Application.ViewModels{

    public class AddressViewModel{
        public required string StreetNumber { get; set; }
        public string? Entrance { get; set; }
        public required string District { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
    }
}
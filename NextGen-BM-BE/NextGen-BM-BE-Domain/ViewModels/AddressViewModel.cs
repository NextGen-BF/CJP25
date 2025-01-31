namespace NextGen_BM_BE_Domain.ViewModels{

    public class AddressViewModel{
        public int AddressId { get; set; }
        public required string StreetName { get; set; }
        public required string StreetNumber { get; set; }
        public string? Entrance { get; set; }
        public required string District { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
    }
}
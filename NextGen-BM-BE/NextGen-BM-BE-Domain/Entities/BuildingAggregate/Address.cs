namespace NextGen_BM_BE_Domain.Entities.BuildingAggregate;
public class Address{
    public int AddressId { get; set; }
    public int StreetNumber { get; set; }
    public string Entrance { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
}
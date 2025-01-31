namespace NextGen_BM_BE_Domain.Entities.BuildingAggregate;

public class Address
{
    public int AddressId { get; set; }
    public int StreetNumber { get; set; }
    public required string Entrance { get; set; }

    public required string StreetName { get; set; }
    public required string District { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public required string Country { get; set; }
    public DateOnly? DeletedDate { get; set; }
    public ICollection<Building>? Buildings { get; set; }
}

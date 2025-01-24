namespace NextGen_BM_BE_Domain.Entities.PropertyAggregate{
public class Property{
    public int PropertyId { get; set; }
    public int PropertyNumber { get; set; }
    public int BuildingId { get; set; }
    public double Size { get; set; }
    public int Floor { get; set; }
    public double SizeOfIdealParts { get; set; }
    public int PropertyTypeId { get; set; }
    public bool EntranceIsExternal { get; set; }
    public ICollection<PropertyExpense>? Expenses { get; set; }
    public ICollection<PropertyUsers>? Users { get; set; }
    public ICollection<PropertyPayments>? Payments { get; set; }
    public ICollection<PropertyResidents>? ResidentsHistory { get; set; }
}
};
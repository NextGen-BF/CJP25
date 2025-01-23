namespace NextGen_BM_BE_Domain.Entities.PropertyAggregate{
public class Property{
    public int PropertyID { get; set; }
    public int PropertyNumber { get; set; }
    public int BuildingID { get; set; }
    public double Size { get; set; }
    public int Floor { get; set; }
    public double SizeOfIdealParts { get; set; }
    public int PropertyTypeID { get; set; }
    public bool EntranceIsExternal { get; set; }
    public List<PropertyExpense>? Expenses { get; set; }
    public List<PropertyUsers>? Users { get; set; }
    public List<PropertyPayments>? Payments { get; set; }
    public List<PropertyResidents>? ResidentsHistory { get; set; }
}
};
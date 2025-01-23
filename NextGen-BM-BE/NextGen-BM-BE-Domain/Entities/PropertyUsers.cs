namespace NextGen_BM_BE_Domain.Entities{
public class PropertyUsers{
    public int PropertyUsersID { get; set; }
    public int PropertyID { get; set; }
    public int UserID { get; set; }
    public DateOnly EffectiveDate { get; set; }
    public DateOnly EndDate { get; set; }
    public double PercentOfApartmentOwned { get; set; }
}
};
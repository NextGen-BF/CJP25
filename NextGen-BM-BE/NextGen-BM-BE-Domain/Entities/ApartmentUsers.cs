namespace NextGen_BM_BE_Domain;

public class ApartmentUsers{
    public int ApartmentUsersID { get; set; }
    public int PropertyID { get; set; }
    public int UserID { get; set; }
    public DateOnly EffectiveDate { get; set; }
    public DateOnly EndDate { get; set; }
    public double PercentOfApartmentOwned { get; set; }
}
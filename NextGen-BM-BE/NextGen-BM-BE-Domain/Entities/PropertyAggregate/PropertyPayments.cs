namespace NextGen_BM_BE_Domain.Entities.PropertyAggregate{
public class PropertyPayments{
    public int PaymentID { get; set; }
    public int PropertyID { get; set; }
    public double AmountOwed { get; set; }
    public DateOnly DateOpened { get; set; }
    public DateOnly DueDate { get; set; }
    public int PropertyExpenseID { get; set; }
    public int StatusID { get; set; }
    public int PaymentParentID { get; set; }
    public int PaymentMethod { get; set; }
}
};
namespace NextGen_BM_BE_Domain;
// PaymentID int
// PropertyID int FK
// AmountOwed decimal
// DateOpened date
// DueDate date
// PropertyExpenseID FK int
// StatusID int FK
// PaymentParentID ? int
// PaymentMethod FK

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
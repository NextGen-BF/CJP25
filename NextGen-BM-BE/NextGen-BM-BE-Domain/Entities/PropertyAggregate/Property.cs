using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate.Specifications;

namespace NextGen_BM_BE_Domain.Entities.PropertyAggregate{
[Table("Property")]
public class Property{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PropertyId { get; set; }
    public int PropertyNumber { get; set; }
    public int BuildingId { get; set; }
    public decimal Size { get; set; }
    public int Floor { get; set; }
    public decimal SizeOfIdealParts { get; set; }
    public int PropertyTypeId { get; set; }
    public bool EntranceIsExternal { get; set; }
    public ICollection<PropertyExpense>? Expenses { get; set; }
    public ICollection<PropertyUsers>? Users { get; set; }
    public ICollection<PropertyPayments>? Payments { get; set; }
    public ICollection<PropertyResidents>? ResidentsHistory { get; set; }
}
};
namespace NextGen_BM_BE_Domain.Entities.PropertyAggregate
{
    public class PropertyUsers
    {
        public int PropertyUsersId { get; set; }
        public int PropertyId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateOnly EffectiveDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public decimal PercentOfApartmentOwned { get; set; }
        public DateOnly? DeletedDate { get; set; }
        public required User User { get; set; }
        public required Role Role { get; set; }
        public required Property Property { get; set; }
    }
};

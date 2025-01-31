using Ardalis.Specification;

namespace NextGen_BM_BE_Domain.Entities.PropertyAggregate.Specifications
{
    public class PropertySpecifications : Specification<Property>
    {
        public PropertySpecifications(int propertyID)
        {
            Query
                .Where(property => property.PropertyId == propertyID)
                .Include(property => property.Users)
                .Include(property => property.Expenses)
                .Include(property => property.Payments)
                .Include(property => property.ResidentsHistory);
        }
    }
};

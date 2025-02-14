using NextGen_BM_BE_Domain.Entities.PropertyAggregate;

namespace NextGen_BM_BE_Domain.Interfaces
{
    public interface IExpensesRepository
    {
        Task<PropertyExpense> GetPropertyExpenseByIdAsync(int propertyExpenseId);
        Task<List<PropertyPayments>> GetPropertyPaymentsByUserIdAsync(int userId);
        Task<List<PropertyPayments>> GetPropertyPaymentsByBuildingIdAsync(int buildingId);
        Task<List<PropertyPayments>> GetPropertyPaymentsByPropertyIdAsync(int propertyId);
        Task CreatePropertyExpenseAsync(PropertyExpense propertyExpense);
        Task CreatePropertyPaymentsForPropertiesAsync(List<int> propertyIds, int expenseId);
        Task UpdatePropertyExpenseAsync(PropertyExpense propertyExpense);
        Task DeletePropertyExpenseAsync(int propertyExpenseId);
    }
}

using NextGen_BM_BE_Domain.Entities.PropertyAggregate;

namespace NextGen_BM_BE_Domain.Interfaces
{
    public interface IExpensesRepository
    {
        Task<PropertyExpense> GetPropertyExpenseByIdAsync(int propertyExpenseId);
        Task<List<PropertyExpense>> GetPropertyExpensesByBuildingIdAsync(int buildingId);
        Task<List<PropertyPayments>> GetPropertyPaymentsByUserIdAsync(int userId, int? page, int? pageSize);
        Task<List<PropertyPayments>> GetPropertyPaymentsByBuildingIdAsync(int buildingId, int? page, int? pageSize);
        Task<List<PropertyPayments>> GetPropertyPaymentsByPropertyIdAsync(int propertyId, int? page, int? pageSize);
        Task CreatePropertyExpenseAsync(PropertyExpense propertyExpense);
        Task CreatePropertyPaymentsAsync(PropertyPayments propertyPayment);
        Task CreatePropertyPaymentsForPropertiesAsync(List<int> propertyIds, int expenseId);
        Task UpdatePropertyExpenseAsync(PropertyExpense propertyExpense);
        Task DeletePropertyExpenseAsync(int propertyExpenseId);
    }
}

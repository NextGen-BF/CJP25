using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;

namespace NextGen_BM_BE_Domain.Interfaces
{
    public interface IExpensesRepository
    {
        Task<PropertyExpense> GetPropertyExpenseByIdAsync(int propertyExpenseId);
        Task<List<PropertyPayments>> GetPropertyExpenseByUserIdAsync(int userId);
        Task<List<PropertyPayments>> GetPropertyExpenseByBuildingIdAsync(int buildingId);
        Task<List<PropertyPayments>> GetPropertyExpenseByPropertyIdAsync(int propertyId);
        Task CreatePropertyExpenseAsync(PropertyExpense propertyExpense);
        Task CreateExpenseForPropertiesAsync(List<int> propertyIds, int expenseId);
        Task UpdatePropertyExpenseAsync(PropertyExpense propertyExpense);
        Task DeletePropertyExpenseAsync(int propertyExpenseId);
    }
}

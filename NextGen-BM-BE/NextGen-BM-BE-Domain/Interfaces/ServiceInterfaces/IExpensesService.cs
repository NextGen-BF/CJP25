using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces
{
    public interface IExpensesService
    {
        Task<PropertyExpense> GetPropertyExpenseByIdAsync(int propertyExpenseId);
        Task<List<PropertyPaymentsViewModel>> GetPropertyPaymentsByUserIdAsync(int userId);
        Task<List<PropertyPaymentsViewModel>> GetPropertyPaymentsByBuildingIdAsync(int buildingId);
        Task<List<PropertyPaymentsViewModel>> GetPropertyPaymentsByPropertyIdAsync(int propertyId);
        Task CreatePropertyExpenseAsync(PropertyExpenseViewModel propertyExpense);
        Task CreateExpenseForPropertiesAsync(List<int> propertyIds, int expenseId);
        Task UpdatePropertyExpenseAsync(PropertyExpenseViewModel propertyExpense);
        Task DeletePropertyExpenseAsync(int propertyExpenseId);
    }
}

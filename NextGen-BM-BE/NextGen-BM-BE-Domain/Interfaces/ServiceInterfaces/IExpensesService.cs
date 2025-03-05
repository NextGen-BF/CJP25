using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces
{
    public interface IExpensesService
    {
        Task<PropertyExpense> GetPropertyExpenseByIdAsync(int propertyExpenseId);
        Task<List<PropertyPaymentsViewModel>> GetPropertyPaymentsByUserIdAsync(int userId, int? page, int? pageSize);
        Task<List<PropertyPaymentsViewModel>> GetPropertyPaymentsByBuildingIdAsync(int buildingId, int? page, int? pageSize);
        Task<List<PropertyExpenseViewModel>> GetPropertyExpensesByBuildingIdAsync(int buildingId, int? page, int? pageSize);
        Task<List<PropertyPaymentsViewModel>> GetPropertyPaymentsByPropertyIdAsync(int propertyId, int? page, int? pageSize);
        Task CreatePropertyExpenseAsync(PropertyExpenseViewModel propertyExpense);
        Task CreatePropertyPaymentsAsync(PropertyPaymentsViewModel propertyPayment);
        Task CreatePropertyPaymentsForPropertiesAsync(List<int> propertyIds, int expenseId);
        Task UpdatePropertyExpenseAsync(PropertyExpenseViewModel propertyExpense);
        Task DeletePropertyExpenseAsync(int propertyExpenseId);
    }
}

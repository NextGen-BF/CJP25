using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;

namespace NextGen_BM_BE_Domain.Interfaces{

    public interface IExpensesRepository    
    {
        Task<PropertyExpense> GetPropertyExpenseByIdAsync(int propertyExpenseId);
        Task<List<PropertyExpense>> GetPropertyExpenseByUserIdAsync(int userId);
        Task<List<PropertyExpense>> GetPropertyExpenseByBuildingIdAsync(int buildingId);        
        Task<List<PropertyExpense>> GetPropertyExpenseByPropertyIdAsync(int propertyId);
        Task CreatePropertyExpenseAsync(PropertyExpense propertyExpense);
        Task CreateExpenseForPropertiesAsync(List<int> propertyIds);
        Task UpdatePropertyExpenseAsync(PropertyExpense propertyExpense);
        Task DeletePropertyExpenseAsync(int propertyExpenseId);
    }
}
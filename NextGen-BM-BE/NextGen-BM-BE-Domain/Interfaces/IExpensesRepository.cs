using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;

namespace NextGen_BM_BE_Domain.Interfaces{

    public interface IExpensesRepository    
    {
        Task<PropertyExpense> GetPropertyExpenseByID(int propertyExpenseID);
        Task<List<PropertyExpense>> GetPropertyExpenseByUserID(int userID);
        Task<List<PropertyExpense>> GetPropertyExpenseByBuildingID(int buildingID);        
        Task<List<PropertyExpense>> GetPropertyExpenseByPropertyID(int propertyID);
        Task CreatePropertyExpense(PropertyExpense propertyExpense);
        Task CreateExpenseForProperties(List<int> propertyIDs);
        Task UpdatePropertyExpense(PropertyExpense propertyExpense);
        Task DeletePropertyExpense(int propertyExpenseID);
    }
}
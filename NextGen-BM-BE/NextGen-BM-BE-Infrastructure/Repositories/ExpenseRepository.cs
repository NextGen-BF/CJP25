using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;
namespace NextGen_BM_BE_Infrastructure.Repositories{
    public class ExpensesRepository : IExpensesRepository
    {
        public Task CreateExpenseForProperties(List<int> propertyIDs)
        {
            throw new NotImplementedException();
        }

        public Task CreatePropertyExpense(PropertyExpense propertyExpense)
        {
            throw new NotImplementedException();
        }

        public Task DeletePropertyExpense(int propertyExpenseID)
        {
            throw new NotImplementedException();
        }

        public Task<List<PropertyExpense>> GetPropertyExpenseByBuildingID(int buildingID)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyExpense> GetPropertyExpenseByID(int propertyExpenseID)
        {
            throw new NotImplementedException();
        }

        public Task<List<PropertyExpense>> GetPropertyExpenseByPropertyID(int propertyID)
        {
            throw new NotImplementedException();
        }

        public Task<List<PropertyExpense>> GetPropertyExpenseByUserID(int userID)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePropertyExpense(PropertyExpense propertyExpense)
        {
            throw new NotImplementedException();
        }
    }
}
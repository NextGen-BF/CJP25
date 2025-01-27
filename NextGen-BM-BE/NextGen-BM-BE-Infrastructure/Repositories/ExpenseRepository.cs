using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;
namespace NextGen_BM_BE_Infrastructure.Repositories{
    public class ExpensesRepository : IExpensesRepository
    {
        public async Task CreateExpenseForPropertiesAsync(List<int> propertyIds, int expenseId)
        {
            throw new NotImplementedException();
        }

        public async Task CreatePropertyExpenseAsync(PropertyExpense propertyExpense)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePropertyExpenseAsync(int propertyExpenseId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PropertyExpense>> GetPropertyExpenseByBuildingIdAsync(int buildingId)
        {
            throw new NotImplementedException();
        }

        public async Task<PropertyExpense> GetPropertyExpenseByIdAsync(int propertyExpenseId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PropertyExpense>> GetPropertyExpenseByPropertyIdAsync(int propertyId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PropertyExpense>> GetPropertyExpenseByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePropertyExpenseAsync(PropertyExpense propertyExpense)
        {
            throw new NotImplementedException();
        }
    }
}
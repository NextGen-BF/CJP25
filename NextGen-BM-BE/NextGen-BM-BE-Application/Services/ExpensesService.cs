using NextGen_BM_BE_Application.UseCases.Expenses.Create;
using NextGen_BM_BE_Application.UseCases.Expenses.Delete;
using NextGen_BM_BE_Application.UseCases.Expenses.Get;
using NextGen_BM_BE_Application.UseCases.Expenses.Update;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;

namespace NextGen_BM_BE_Application.Services
{
    public class ExpensesService : IExpensesService
    {
        public async Task<PropertyExpense> GetPropertyExpenseByIdAsync(int propertyExpenseId)
        {
            return await GetPropertyExpenseByIdUseCase.Execute(propertyExpenseId);
        }

        public async Task<List<PropertyExpense>> GetPropertyExpenseByUserIdAsync(int userId)
        {
            return await GetAllPropertyExpenseByUserIdUseCase.Execute(userId);
        }

        public async Task<List<PropertyExpense>> GetPropertyExpenseByBuildingIdAsync(int buildingId)
        {
            return await GetAllPropertyExpenseByBuildingIdUseCase.Execute(buildingId);
        }

        public async Task<List<PropertyExpense>> GetPropertyExpenseByPropertyIdAsync(int propertyId)
        {
            return await GetAllPropertyExpenseByPropertyIdUseCase.Execute(propertyId);
        }

        public async Task CreatePropertyExpenseAsync(PropertyExpense propertyExpense)
        {
            await CreateExpensesUseCase.Execute(propertyExpense);
        }

        public async Task CreateExpenseForPropertiesAsync(List<int> propertyIds, int expenseId)
        {
            await CreateExpenseForPropertiesUseCase.Execute(propertyIds, expenseId);
        }

        public async Task UpdatePropertyExpenseAsync(PropertyExpense propertyExpense)
        {
            await UpdateExpensesUseCase.Execute(propertyExpense);
        }

        public async Task DeletePropertyExpenseAsync(int propertyExpenseId)
        {
            await DeleteExpensesUseCase.Execute(propertyExpenseId);
        }
    }
}

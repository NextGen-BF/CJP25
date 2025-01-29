using NextGen_BM_BE_Application.UseCases.Expenses.Create;
using NextGen_BM_BE_Application.UseCases.Expenses.Delete;
using NextGen_BM_BE_Application.UseCases.Expenses.Get;
using NextGen_BM_BE_Application.UseCases.Expenses.Update;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;

namespace NextGen_BM_BE_Application.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly GetPropertyExpenseByIdUseCase _getPropertyExpenseByIdUseCase;
        private readonly GetAllPropertyExpenseByUserIdUseCase _getAllPropertyExpenseByUserIdUseCase;

        private readonly GetAllPropertyExpenseByBuildingIdUseCase _getAllPropertyExpenseByBuildingIdUseCase;

        private readonly GetAllPropertyExpenseByPropertyIdUseCase _getAllPropertyExpenseByPropertyIdUseCase;

        private readonly CreateExpensesUseCase _createExpensesUseCase;

        private readonly CreateExpenseForPropertiesUseCase _createExpenseForPropertiesUseCase;

        private readonly UpdateExpensesUseCase _updateExpensesUseCase;

        private readonly DeleteExpensesUseCase _deleteExpensesUseCase;

        public ExpensesService(
            GetPropertyExpenseByIdUseCase getPropertyExpenseByIdUseCase,
            GetAllPropertyExpenseByUserIdUseCase getAllPropertyExpenseByUserIdUseCase,
            GetAllPropertyExpenseByBuildingIdUseCase getAllPropertyExpenseByBuildingIdUseCase,
            GetAllPropertyExpenseByPropertyIdUseCase getAllPropertyExpenseByPropertyIdUseCase,
            CreateExpensesUseCase createExpensesUseCase,
            CreateExpenseForPropertiesUseCase createExpenseForPropertiesUseCase,
            UpdateExpensesUseCase updateExpensesUseCase,
            DeleteExpensesUseCase deleteExpensesUseCase
        )
        {
            _getPropertyExpenseByIdUseCase = getPropertyExpenseByIdUseCase;
            _getAllPropertyExpenseByUserIdUseCase = getAllPropertyExpenseByUserIdUseCase;
            _getAllPropertyExpenseByBuildingIdUseCase = getAllPropertyExpenseByBuildingIdUseCase;
            _getAllPropertyExpenseByPropertyIdUseCase = getAllPropertyExpenseByPropertyIdUseCase;
            _createExpensesUseCase = createExpensesUseCase;
            _createExpenseForPropertiesUseCase = createExpenseForPropertiesUseCase;
            _updateExpensesUseCase = updateExpensesUseCase;
            _deleteExpensesUseCase = deleteExpensesUseCase;
        }

        public async Task<PropertyExpense> GetPropertyExpenseByIdAsync(int propertyExpenseId)
        {
            return await _getPropertyExpenseByIdUseCase.Execute(propertyExpenseId);
        }

        public async Task<List<PropertyExpense>> GetPropertyExpenseByUserIdAsync(int userId)
        {
            return (List<PropertyExpense>)
                await _getAllPropertyExpenseByUserIdUseCase.Execute(userId);
        }

        public async Task<List<PropertyExpense>> GetPropertyExpenseByBuildingIdAsync(int buildingId)
        {
            return (List<PropertyExpense>)
                await _getAllPropertyExpenseByBuildingIdUseCase.Execute(buildingId);
        }

        public async Task<List<PropertyExpense>> GetPropertyExpenseByPropertyIdAsync(int propertyId)
        {
            return (List<PropertyExpense>)
                await _getAllPropertyExpenseByPropertyIdUseCase.Execute(propertyId);
        }

        public async Task CreatePropertyExpenseAsync(PropertyExpense propertyExpense)
        {
            await _createExpensesUseCase.Execute(propertyExpense);
        }

        public async Task CreateExpenseForPropertiesAsync(List<int> propertyIds, int expenseId)
        {
            await _createExpenseForPropertiesUseCase.Execute(propertyIds, expenseId);
        }

        public async Task UpdatePropertyExpenseAsync(PropertyExpense propertyExpense)
        {
            await _updateExpensesUseCase.Execute(propertyExpense);
        }

        public async Task DeletePropertyExpenseAsync(int propertyExpenseId)
        {
            await _deleteExpensesUseCase.Execute(propertyExpenseId);
        }
    }
}

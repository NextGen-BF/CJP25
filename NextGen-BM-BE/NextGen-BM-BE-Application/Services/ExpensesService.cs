using AutoMapper;
using NextGen_BM_BE_Application.UseCases.Expenses.Create;
using NextGen_BM_BE_Application.UseCases.Expenses.Delete;
using NextGen_BM_BE_Application.UseCases.Expenses.Get;
using NextGen_BM_BE_Application.UseCases.Expenses.Update;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_Application.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly GetPropertyExpenseByIdUseCase _getPropertyExpenseByIdUseCase;
        private readonly GetAllPropertyPaymentsByUserIdUseCase _getAllPropertyPaymentsByUserIdUseCase;

        private readonly GetAllPropertyPaymentsByBuildingIdUseCase _getAllPropertyPaymentsByBuildingIdUseCase;

        private readonly GetAllPropertyPaymentsByPropertyIdUseCase _getAllPropertyPaymentsByPropertyIdUseCase;

        private readonly CreateExpensesUseCase _createExpensesUseCase;

        private readonly CreateExpenseForPropertiesUseCase _createExpenseForPropertiesUseCase;

        private readonly UpdateExpensesUseCase _updateExpensesUseCase;

        private readonly DeleteExpensesUseCase _deleteExpensesUseCase;
        private readonly IMapper _mapper;

        public ExpensesService(
            GetPropertyExpenseByIdUseCase getPropertyExpenseByIdUseCase,
            GetAllPropertyPaymentsByUserIdUseCase getAllPropertyPaymentsByUserIdUseCase,
            GetAllPropertyPaymentsByBuildingIdUseCase getAllPropertyPaymentsByBuildingIdUseCase,
            GetAllPropertyPaymentsByPropertyIdUseCase getAllPropertyPaymentsByPropertyIdUseCase,
            CreateExpensesUseCase createExpensesUseCase,
            CreateExpenseForPropertiesUseCase createExpenseForPropertiesUseCase,
            UpdateExpensesUseCase updateExpensesUseCase,
            DeleteExpensesUseCase deleteExpensesUseCase,
            IMapper mapper
        )
        {
            _getPropertyExpenseByIdUseCase = getPropertyExpenseByIdUseCase;
            _getAllPropertyPaymentsByUserIdUseCase = getAllPropertyPaymentsByUserIdUseCase;
            _getAllPropertyPaymentsByBuildingIdUseCase = getAllPropertyPaymentsByBuildingIdUseCase;
            _getAllPropertyPaymentsByPropertyIdUseCase = getAllPropertyPaymentsByPropertyIdUseCase;
            _createExpensesUseCase = createExpensesUseCase;
            _createExpenseForPropertiesUseCase = createExpenseForPropertiesUseCase;
            _updateExpensesUseCase = updateExpensesUseCase;
            _deleteExpensesUseCase = deleteExpensesUseCase;
            _mapper = mapper;
        }

        public async Task<PropertyExpense> GetPropertyExpenseByIdAsync(int propertyExpenseId)
        {
            return await _getPropertyExpenseByIdUseCase.Execute(propertyExpenseId);
        }

        public async Task<List<PropertyPayments>> GetPropertyPaymentsByUserIdAsync(int userId)
        {
            return (List<PropertyPayments>)
                await _getAllPropertyPaymentsByUserIdUseCase.Execute(userId);
        }

        public async Task<List<PropertyPayments>> GetPropertyPaymentsByBuildingIdAsync(
            int buildingId
        )
        {
            return (List<PropertyPayments>)
                await _getAllPropertyPaymentsByBuildingIdUseCase.Execute(buildingId);
        }

        public async Task<List<PropertyPayments>> GetPropertyPaymentsByPropertyIdAsync(
            int propertyId
        )
        {
            return (List<PropertyPayments>)
                await _getAllPropertyPaymentsByPropertyIdUseCase.Execute(propertyId);
        }

        public async Task CreatePropertyExpenseAsync(PropertyExpenseViewModel propertyExpenseDto)
        {
            var expense = _mapper.Map<PropertyExpense>(propertyExpenseDto);
            await _createExpensesUseCase.Execute(expense);
        }

        public async Task CreateExpenseForPropertiesAsync(List<int> propertyIds, int expenseId)
        {
            await _createExpenseForPropertiesUseCase.Execute(propertyIds, expenseId);
        }

        public async Task UpdatePropertyExpenseAsync(PropertyExpenseViewModel propertyExpenseDto)
        {
            var expense = _mapper.Map<PropertyExpense>(propertyExpenseDto);
            await _updateExpensesUseCase.Execute(expense);
        }

        public async Task DeletePropertyExpenseAsync(int propertyExpenseId)
        {
            await _deleteExpensesUseCase.Execute(propertyExpenseId);
        }
    }
}

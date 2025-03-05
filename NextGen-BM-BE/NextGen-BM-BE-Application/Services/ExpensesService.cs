using AutoMapper;
using Microsoft.VisualBasic;
using NextGen_BM_BE_Application.UseCases.Expenses.Create;
using NextGen_BM_BE_Application.UseCases.Expenses.Delete;
using NextGen_BM_BE_Application.UseCases.Expenses.Get;
using NextGen_BM_BE_Application.UseCases.Expenses.Update;
using NextGen_BM_BE_Domain.DataStructures;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_Application.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly GetPropertyExpenseByIdUseCase _getPropertyExpenseByIdUseCase;

        private readonly GetPropertyExpensesByBuildingIdUseCase _getPropertyExpensesByBuildingIdUseCase;
        private readonly GetAllPropertyPaymentsByUserIdUseCase _getAllPropertyPaymentsByUserIdUseCase;

        private readonly GetAllPropertyPaymentsByBuildingIdUseCase _getAllPropertyPaymentsByBuildingIdUseCase;

        private readonly GetAllPropertyPaymentsByPropertyIdUseCase _getAllPropertyPaymentsByPropertyIdUseCase;

        private readonly CreateExpensesUseCase _createExpensesUseCase;

        private readonly CreatePropertyPaymentsUseCase _createPropertyPaymentsUseCase;

        private readonly CreatePropertyPaymentsForPropertiesUseCase _createPropertyPaymentsForPropertiesUseCase;

        private readonly UpdateExpensesUseCase _updateExpensesUseCase;

        private readonly DeleteExpensesUseCase _deleteExpensesUseCase;
        private readonly IMapper _mapper;
        private readonly IPaginationService _paginationService;

        public ExpensesService(
            GetPropertyExpenseByIdUseCase getPropertyExpenseByIdUseCase,
            GetPropertyExpensesByBuildingIdUseCase getPropertyExpensesByBuildingIdUseCase,
            GetAllPropertyPaymentsByUserIdUseCase getAllPropertyPaymentsByUserIdUseCase,
            GetAllPropertyPaymentsByBuildingIdUseCase getAllPropertyPaymentsByBuildingIdUseCase,
            GetAllPropertyPaymentsByPropertyIdUseCase getAllPropertyPaymentsByPropertyIdUseCase,
            CreateExpensesUseCase createExpensesUseCase,
            CreatePropertyPaymentsUseCase createPropertyPaymentsUseCase,
            CreatePropertyPaymentsForPropertiesUseCase createPropertyPaymentsForPropertiesUseCase,
            UpdateExpensesUseCase updateExpensesUseCase,
            DeleteExpensesUseCase deleteExpensesUseCase,
            IMapper mapper,
            IPaginationService paginationService
        )
        {
            _getPropertyExpenseByIdUseCase = getPropertyExpenseByIdUseCase;
            _getPropertyExpensesByBuildingIdUseCase = getPropertyExpensesByBuildingIdUseCase;
            _getAllPropertyPaymentsByUserIdUseCase = getAllPropertyPaymentsByUserIdUseCase;
            _getAllPropertyPaymentsByBuildingIdUseCase = getAllPropertyPaymentsByBuildingIdUseCase;
            _getAllPropertyPaymentsByPropertyIdUseCase = getAllPropertyPaymentsByPropertyIdUseCase;
            _createExpensesUseCase = createExpensesUseCase;
            _createPropertyPaymentsUseCase = createPropertyPaymentsUseCase;
            _createPropertyPaymentsForPropertiesUseCase =
                createPropertyPaymentsForPropertiesUseCase;
            _updateExpensesUseCase = updateExpensesUseCase;
            _deleteExpensesUseCase = deleteExpensesUseCase;
            _mapper = mapper;
            _paginationService = paginationService;
        }

        public async Task<PropertyExpense> GetPropertyExpenseByIdAsync(int propertyExpenseId)
        {
            return await _getPropertyExpenseByIdUseCase.Execute(propertyExpenseId);
        }

        public async Task<List<PropertyExpenseViewModel>> GetPropertyExpensesByBuildingIdAsync(
            int buildingId, int? page, int? pageSize
        )
        {
            var propertyExpensesByBuildingId =
                await _getPropertyExpensesByBuildingIdUseCase.Execute(buildingId, page, pageSize);
            List<PropertyExpenseViewModel> propertyExpensesList = new();

            if (page!=null&&pageSize!=null)
                return _paginationService.MapPagedResult<PropertyExpenseViewModel, PropertyExpense>((PagedList<PropertyExpense>)propertyExpensesByBuildingId);

            foreach (var propertyExpense in propertyExpensesByBuildingId)
            {
                propertyExpensesList.Add(_mapper.Map<PropertyExpenseViewModel>(propertyExpense));
            }
            return propertyExpensesList;
        }

        public async Task<List<PropertyPaymentsViewModel>> GetPropertyPaymentsByUserIdAsync(
            int userId, int? page, int? pageSize
        )
        {
            var propertyPaymentsByUserId = await _getAllPropertyPaymentsByUserIdUseCase.Execute(
                userId, page, pageSize
            );
            
            if (page!=null&&pageSize!=null)
                return _paginationService.MapPagedResult<PropertyPaymentsViewModel, PropertyPayments>((PagedList<PropertyPayments>)propertyPaymentsByUserId);
            
            List<PropertyPaymentsViewModel> propertyPaymentsList = new();

            foreach (var propertyPayment in propertyPaymentsByUserId)
            {
                propertyPaymentsList.Add(_mapper.Map<PropertyPaymentsViewModel>(propertyPayment));
            }
            return propertyPaymentsList;
        }

        public async Task<List<PropertyPaymentsViewModel>> GetPropertyPaymentsByBuildingIdAsync(
            int buildingId, int? page, int? pageSize
        )
        {
            var propertyPaymentsByBuildingId =
                await _getAllPropertyPaymentsByBuildingIdUseCase.Execute(buildingId, page, pageSize);

            if (page!=null&&pageSize!=null)
                return _paginationService.MapPagedResult<PropertyPaymentsViewModel, PropertyPayments>((PagedList<PropertyPayments>)propertyPaymentsByBuildingId);

            List<PropertyPaymentsViewModel> propertyPaymentsList = new();

            foreach (var propertyPayment in propertyPaymentsByBuildingId)
            {
                propertyPaymentsList.Add(_mapper.Map<PropertyPaymentsViewModel>(propertyPayment));
            }
            return propertyPaymentsList;
        }

        public async Task<List<PropertyPaymentsViewModel>> GetPropertyPaymentsByPropertyIdAsync(
            int propertyId, int? page, int? pageSize
        )
        {
            var propertyPaymentsByPropertyId =
                await _getAllPropertyPaymentsByPropertyIdUseCase.Execute(propertyId, page, pageSize);

            List<PropertyPaymentsViewModel> propertyPaymentsList = new();

            if (page!=null&&pageSize!=null)
                return _paginationService.MapPagedResult<PropertyPaymentsViewModel, PropertyPayments>((PagedList<PropertyPayments>)propertyPaymentsByPropertyId);

            foreach (var propertyPayment in propertyPaymentsByPropertyId)
            {
                propertyPaymentsList.Add(_mapper.Map<PropertyPaymentsViewModel>(propertyPayment));
            }
            return propertyPaymentsList;
        }

        public async Task CreatePropertyExpenseAsync(PropertyExpenseViewModel propertyExpenseDto)
        {
            var expense = _mapper.Map<PropertyExpense>(propertyExpenseDto);
            await _createExpensesUseCase.Execute(expense);
        }

        public async Task CreatePropertyPaymentsAsync(PropertyPaymentsViewModel propertyPaymentDto)
        {
            var payment = _mapper.Map<PropertyPayments>(propertyPaymentDto);
            await _createPropertyPaymentsUseCase.Execute(payment);
        }

        public async Task CreatePropertyPaymentsForPropertiesAsync(
            List<int> propertyIds,
            int expenseId
        )
        {
            await _createPropertyPaymentsForPropertiesUseCase.Execute(propertyIds, expenseId);
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

using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;

namespace NextGen_BM_BE_Application.UseCases.Expenses.Create
{

public sealed class CreateExpensesUseCase(IExpensesRepository _ExpensesRepository)
    {
    private readonly IExpensesRepository expensesRepository = _ExpensesRepository;

        public async Task Execute(PropertyExpense Expenses){
        await expensesRepository.CreatePropertyExpenseAsync(Expenses);
    }
}
}
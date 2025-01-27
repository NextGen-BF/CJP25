using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;

namespace NextGen_BM_BE_Application.UseCases.Expenses.Delete
{

    public sealed class DeleteExpensesUseCase(IExpensesRepository _ExpensesRepository)
    {
        private readonly IExpensesRepository expensesRepository = _ExpensesRepository;

        public async Task Execute(int expenseId)
        {
            await expensesRepository.DeletePropertyExpenseAsync(expenseId);
        }
    }
}
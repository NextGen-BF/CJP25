using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Expenses.Create
{
    public sealed class CreatePropertyPaymentsUseCase(IExpensesRepository _ExpensesRepository)
    {
        private readonly IExpensesRepository expensesRepository = _ExpensesRepository;

        public async Task Execute(PropertyPayments payment)
        {
            await expensesRepository.CreatePropertyPaymentsAsync(payment);
        }
    }
}
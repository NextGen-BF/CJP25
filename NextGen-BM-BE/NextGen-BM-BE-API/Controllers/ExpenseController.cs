using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_API.Controllers
{
    /// <summary>
    /// Controller for handling all API calls regarding expenses
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpensesService _expensesService;

        public ExpenseController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

        [HttpGet]
        [Route("{expenseId}")]
        public async Task<IActionResult> GetExpenseById(int expenseId)
        {
            var expense = await _expensesService.GetPropertyExpenseByIdAsync(expenseId);
            return Ok(expense);
        }

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetPropertyPaymentsByUserId(int userId)
        {
            var propertyPaymentsByUserId = await _expensesService.GetPropertyPaymentsByUserIdAsync(
                userId
            );
            return Ok(propertyPaymentsByUserId);
        }

        [HttpGet]
        [Route("property/{propertyId}")]
        public async Task<IActionResult> GetPropertyPaymentsByPropertyId(int propertyId)
        {
            var propertyPaymentsByPropertyId =
                await _expensesService.GetPropertyPaymentsByPropertyIdAsync(propertyId);
            return Ok(propertyPaymentsByPropertyId);
        }

        [HttpGet]
        [Route("building/{buildingId}")]
        [Authorize(Policy = "Super For Building")]
        public async Task<IActionResult> GetPropertyPaymentsByBuildingId(int buildingId)
        {
            var propertyPaymentsByBuildingId =
                await _expensesService.GetPropertyPaymentsByBuildingIdAsync(buildingId);
            return Ok(propertyPaymentsByBuildingId);
        }

        [HttpPost]
        [Route("new")]
        [Authorize(Policy = "Super For Building")]
        public async Task<IActionResult> CreateExpense(PropertyExpenseViewModel propertyExpense)
        {
            await _expensesService.CreatePropertyExpenseAsync(propertyExpense);
            return Ok();
        }

        [HttpPost]
        [Route("create/property")]
        public async Task<IActionResult> CreatePropertyPaymentsForProperties(
            List<int> propertyIds,
            int expenseId
        )
        {
            await _expensesService.CreatePropertyPaymentsForPropertiesAsync(propertyIds, expenseId);
            return Ok(); // not sure what to return here
        }

        [HttpPut]
        [Route("update")]
        [Authorize(Policy = "Super For Building")]
        public async Task<IActionResult> UpdateExpense(PropertyExpenseViewModel propertyExpense)
        {
            await _expensesService.UpdatePropertyExpenseAsync(propertyExpense);
            return Ok(propertyExpense);
        }

        [HttpDelete]
        [Route("delete/{expenseId}")]
        [Authorize(Policy = "Super For Building")]
        public async Task<IActionResult> DeleteExpense(int expenseId)
        {
            await _expensesService.DeletePropertyExpenseAsync(expenseId);
            return Ok();
        }
    }
};

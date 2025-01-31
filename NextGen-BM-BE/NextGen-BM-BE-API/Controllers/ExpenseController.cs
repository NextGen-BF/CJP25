using Microsoft.AspNetCore.Mvc;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;

namespace NextGen_BM_BE_API.Controllers
{
    /// <summary>
    /// Controller for handling all API calls regarding expenses
    /// </summary>
    [ApiController]
    [Route("[controller]")]
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
        public async Task<IActionResult> GetExpenseByUserId(int userId)
        {
            var expensesByUserId = await _expensesService.GetPropertyExpenseByUserIdAsync(userId);
            return Ok(expensesByUserId);
        }

        [HttpGet]
        [Route("property/{propertyId}")]
        public async Task<IActionResult> GetExpenseByPropertyId(int propertyId)
        {
            var expensesByPropertyId = await _expensesService.GetPropertyExpenseByPropertyIdAsync(
                propertyId
            );
            return Ok(expensesByPropertyId);
        }

        [HttpGet]
        [Route("building/{buildingId}")]
        public async Task<IActionResult> GetExpenseByBuildingId(int buildingId)
        {
            var expensesByBuildingId = await _expensesService.GetPropertyExpenseByBuildingIdAsync(
                buildingId
            );
            return Ok(expensesByBuildingId);
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateExpense(PropertyExpense propertyExpense)
        {
            await _expensesService.CreatePropertyExpenseAsync(propertyExpense);
            return CreatedAtAction(
                nameof(GetExpenseById),
                new { id = propertyExpense.PropertyExpenseId },
                propertyExpense
            );
        }

        [HttpPost]
        [Route("create/property")]
        public async Task<IActionResult> CreateExpenseForProperties(
            List<int> propertyIds,
            int expenseId
        )
        {
            await _expensesService.CreateExpenseForPropertiesAsync(propertyIds, expenseId);
            return Ok(); // not sure what to return here
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateExpense(PropertyExpense propertyExpense)
        {
            await _expensesService.UpdatePropertyExpenseAsync(propertyExpense);
            return Ok(propertyExpense);
        }

        [HttpDelete]
        [Route("delete/{expenseId}")]
        public async Task<IActionResult> DeleteExpense(int expenseId)
        {
            await _expensesService.DeletePropertyExpenseAsync(expenseId);
            return Ok();
        }
    }
};

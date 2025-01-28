using Microsoft.AspNetCore.Mvc;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;

namespace NextGen_BM_BE_API.Controllers{

/// <summary>
/// Controller for handling all API calls regarding expenses
/// </summary>
[ApiController]
[Route("[controller]")]
public class ExpenseController: ControllerBase {

    public ExpenseController()
    {
        
    }

    [HttpGet]
    [Route("user/{userId}")]
    public async Task<IActionResult> GetExpenseByUserId(int userId){
        return null;
    }

    [HttpGet]
    [Route("property/{propertyId}")]
    public async Task<IActionResult> GetExpenseByPropertyId(int propertyId){
        return null;
    }

    [HttpGet]
    [Route("building/{buildingId}")]
    public async Task<IActionResult> GetExpenseByBuildingId(int buildingId){
        return null;
    }

    [HttpPost]
    [Route("new")]
    public async Task<IActionResult> CreateExpense(PropertyExpense propertyExpense ){
        return null;
    }

    [HttpPost]
    [Route("link/property/{expenseId}")]
    public async Task<IActionResult> LinkExpenseToProperties(List<int> propertyIds, int expenseId){
        return null;
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> UpdateExpense(PropertyExpense propertyExpense){
        return null;
    }
    [HttpPost]
    [Route("delete/{expenseId}")]
    public async Task<IActionResult> DeleteExpense(int expenseId){
        return null;
    }
}
};
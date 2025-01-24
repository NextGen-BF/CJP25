using Microsoft.AspNetCore.Mvc;

namespace NextGen_BM_BE_API.Controllers{

/// <summary>
/// Controller for handling all API calls regarding expenses
/// </summary>
[ApiController]
[Route("[Controller]")]
public class ExpenseController: ControllerBase {

    public ExpenseController()
    {
        
    }
    [HttpGet]
    [Route("/all")]
    public async Task<IActionResult> GetAllExpenses(){
        return null;
    }

    [HttpGet]
    [Route("/{expenseID}")]
    public async Task<IActionResult> GetExpenseByID(int expenseID){
        return null;
    }

    [HttpGet]
    [Route("/user/{userID}")]
    public async Task<IActionResult> GetExpenseByUserID(int userID){
        return null;
    }

    [HttpGet]
    [Route("/property/{propertyID}")]
    public async Task<IActionResult> GetExpenseByPropertyID(int propertyID){
        return null;
    }

    [HttpGet]
    [Route("/building/{buildingID}")]
    public async Task<IActionResult> GetExpenseByBuildingID(int buildingID){
        return null;
    }

    [HttpPost]
    [Route("/new")]
    public async Task<IActionResult> CreateExpense(/*Expense Expense*/ ){
        return null;
    }

    [HttpPost]
    [Route("/create/property")]
    public async Task<IActionResult> CreateExpenseForProperties(int[] propertyIDs){
        return null;
    }

    [HttpPost]
    [Route("/update")]
    public async Task<IActionResult> UpdateExpense(/*Expense expense*/){
        return null;
    }
    [HttpPost]
    [Route("/delete/{expenseID}")]
    public async Task<IActionResult> DeleteExpense(int expenseID){
        return null;
    }
}
};
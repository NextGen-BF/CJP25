using Microsoft.AspNetCore.Mvc;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using NextGen_BM_BE_Domain.ViewModels;
using NextGen_BM_BE_Infrastructure;

namespace NextGen_BM_BE_API.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase{

        private readonly DataContext _dbContext;
        public HealthController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("check")]
        public async Task<IActionResult> HealthCheck()
        {
            if (_dbContext.Database.CanConnect())
                return Ok("Connection Succesful");
            return BadRequest();
        }
    }   
}
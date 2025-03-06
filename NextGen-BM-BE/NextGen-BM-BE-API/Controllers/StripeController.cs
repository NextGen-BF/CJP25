using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using Stripe;

namespace NextGen_BM_BE_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class StripeController : ControllerBase
    {
        private readonly IStripeService _stripe;

        public StripeController(IStripeService stripeService)
        {
            _stripe = stripeService;
        }

        [HttpPost]
        [Route("payment/pay")]
        public async Task<IActionResult> MakePayment()
        {
            return Ok();
        }

        [HttpPost]
        [Route("payment/new")]
        public async Task<IActionResult> CreateNewPayment()
        {
            return Ok();
        }

        [HttpPost]
        [Route("payment/status")]
        public async Task<IActionResult> ChangePaymentStatus()
        {
            return Ok();
        }

        [HttpPost]
        [Route("payment/update")]
        public async Task<IActionResult> UpdatePayment()
        {
            return Ok();
        }
    }

}
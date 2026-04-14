using LP.Api.Customer.Onboarding.Contracts.Signup;
using Microsoft.AspNetCore.Mvc;

namespace LP.Api.Customer.Onboarding.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OnboardingController : ControllerBase
    {
        [HttpPost("signup")]
        public IActionResult Signup([FromBody] SignupRequest request)
        {
            return Ok();
        }
    }
}

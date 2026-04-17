using LP.Api.Customer.Onboarding.Contracts.Signup;
using Microsoft.AspNetCore.Mvc;
using LP.Api.Customer.Onboarding.Services;

namespace LP.Api.Customer.Onboarding.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OnboardingController : ControllerBase
    {
        private readonly IOnboardingService _onboardingService;

        public OnboardingController(IOnboardingService onboardingService)
        {
            _onboardingService = onboardingService;
        }

        [HttpPost("signup")]
        public IActionResult Signup([FromBody] SignupRequest request)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var onboarding = _onboardingService.GetByLeadId(id);
            if (onboarding == null)
            {
                return NotFound();
            }
            return Ok(onboarding);
        }
    }
}

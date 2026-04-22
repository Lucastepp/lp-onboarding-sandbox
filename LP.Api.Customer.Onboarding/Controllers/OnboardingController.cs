using LP.Api.Customer.Onboarding.Contracts.Signup;
using Microsoft.AspNetCore.Mvc;
using LP.Api.Customer.Onboarding.Services;
using LP.Api.Customer.Onboarding.Contracts.CompanyDetails;
using LP.Api.Customer.Onboarding.Contracts.PersonalDetails;
using LP.Api.Customer.Onboarding.Contracts.FinancialDetails;

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
            var response = _onboardingService.Signup(request);

            return Ok(response);
        }

        [HttpGet("{leadId:guid}")]
        public IActionResult GetByLeadId(Guid leadId)
        {
            var onboarding = _onboardingService.GetByLeadId(leadId);

            if (onboarding is null)
            {
                return NotFound();
            }

            return Ok(onboarding);
        }

        [HttpGet("{leadId:guid}/progress")]
        public IActionResult GetProgress(Guid leadId)
        {
            var response = _onboardingService.GetProgress(leadId);

            if (response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPut("{leadId:guid}/company-details")]
        public IActionResult UpdateCompanyDetails(Guid leadId, [FromBody] CompanyDetailsRequest request)
        {
            var response = _onboardingService.UpdateCompanyDetails(leadId, request);

            if (response is null) 
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPut("{leadId:guid}/personal-details")]
        public IActionResult UpdatePersonalDetails(Guid leadId, [FromBody] PersonalDetailsRequest request)
        {
            var response = _onboardingService.UpdatePersonalDetails(leadId, request);

            if (response is null) 
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPut("{leadId:guid}/financial-details")]
        public IActionResult UpdateFinancialDetails(Guid leadId, [FromBody] FinancialDetailsRequest request)
        {
            var response = _onboardingService.UpdateFinancialDetails(leadId, request);

            if (response is null) 
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}

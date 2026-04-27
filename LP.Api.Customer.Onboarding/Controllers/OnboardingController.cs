using LP.Api.Customer.Onboarding.Contracts.CompanyDetails;
using LP.Api.Customer.Onboarding.Contracts.FinancialDetails;
using LP.Api.Customer.Onboarding.Contracts.PersonalDetails;
using LP.Api.Customer.Onboarding.Contracts.Signup;
using LP.Api.Customer.Onboarding.Exceptions;
using LP.Api.Customer.Onboarding.Services;
using Microsoft.AspNetCore.Mvc;

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
            try
            {
                var response = _onboardingService.Signup(request);

                return Ok(response);
            }
            catch (DuplicateEmailException ex)
            {
                return BadRequest(new
                {
                    error = "duplicate_email",
                    message = ex.Message
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    error = "internal_error",
                    message = "Unexpected error"
                });
            }
        }

        [HttpGet("{leadId:guid}")]
        public IActionResult GetByLeadId(Guid leadId)
        {
            try
            {
                var onboarding = _onboardingService.GetByLeadId(leadId);

                return Ok(onboarding);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new
                {
                    error = "not_found",
                    message = ex.Message
                });
            }
        }

        [HttpGet("{leadId:guid}/progress")]
        public IActionResult GetProgress(Guid leadId)
        {
            try
            {
                var response = _onboardingService.GetProgress(leadId);

                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new
                {
                    error = "not_found",
                    message = ex.Message
                });
            }
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

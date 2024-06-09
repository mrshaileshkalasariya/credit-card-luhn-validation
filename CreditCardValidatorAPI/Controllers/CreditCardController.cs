using Microsoft.AspNetCore.Mvc;  // Import the necessary namespace for MVC
using CreditCardValidatorAPI.Services;
using CreditCardValidatorAPI.Models;

// Define the namespace for the controller
namespace CreditCardValidatorAPI.Controllers
{
    [Route("api/[controller]")]  // Define the route for the controller
    [ApiController]  // Mark the class as an API controller
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardValidator _creditCardValidator;  // Declare a readonly field for the credit card validator service

        // Constructor to inject the credit card validator service
        public CreditCardController(ICreditCardValidator creditCardValidator)
        {
            _creditCardValidator = creditCardValidator;
        }

        // Define the POST endpoint for validating credit card number
        [HttpPost("validate_cc_number")]
        public ActionResult<bool> validate_cc_number([FromBody] CreditCardRequest request)
        {
            // Check if the request is null or the credit card number is empty
            if (request == null || string.IsNullOrWhiteSpace(request.CreditCardNumber))
            {
                return BadRequest("Credit card number is required.");  // Return bad request response
            }

            // Call the validation method and store the result
            var isValid = _creditCardValidator.validate_cc_number(request.CreditCardNumber);
            return Ok(isValid);  // Return the result as OK response
        }
    }
}

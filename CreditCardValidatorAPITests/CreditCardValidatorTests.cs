using Xunit;  // Import the xUnit namespace
using CreditCardValidatorAPI.Services;  // Import the service namespace

namespace CreditCardValidatorAPITests
{
    public class CreditCardValidatorTests
    {
        private readonly ICreditCardValidator _creditCardValidator;  // Declare a field for the credit card validator service

        // Constructor to initialize the credit card validator service
        public CreditCardValidatorTests()
        {
            _creditCardValidator = new CreditCardValidator();
        }

        // Define a theory to test multiple cases
        [Theory]
        [InlineData("49927398716", true)]  // Valid luhn credit card number
        [InlineData("451234567890123", true)]  // Valid luhn credit card number
        [InlineData("49927398717", false)]  // Invalid luhn card number
        [InlineData("", false)]  // Empty string
        [InlineData(null, false)]  // Null value
        public void Validate_ShouldReturnExpectedResult(string creditCardNumber, bool expected)
        {
            // Call the validate method and store the result
            var result = _creditCardValidator.validate_cc_number(creditCardNumber);
            // Assert that the result matches the expected value
            Assert.Equal(expected, result);
        }
    }
}

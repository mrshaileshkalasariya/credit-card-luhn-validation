// Define the namespace for the services
namespace CreditCardValidatorAPI.Services
{
    // Define the interface for credit card validation service
    public interface ICreditCardValidator
    {
        // Method to validate the credit card number
        bool validate_cc_number(string creditCardNumber);
    }
}
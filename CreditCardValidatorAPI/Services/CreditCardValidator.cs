// Define the namespace for the services
namespace CreditCardValidatorAPI.Services
{
    // Implement the credit card validator interface
    public class CreditCardValidator : ICreditCardValidator
    {
        // Method to validate the credit card number using Luhn algorithm
        public bool validate_cc_number(string creditCardNumber)
        {
            // Check if the credit card number is null or empty
            if (string.IsNullOrWhiteSpace(creditCardNumber)) return false;

            int sum = 0;  // Initialize sum of digits
            bool alternate = false;  // Flag to alternate the digits for doubling

            // Loop through the credit card number from the end
            for (int i = creditCardNumber.Length - 1; i >= 0; i--)
            {
                // Check if the current character is not a digit
                if (!char.IsDigit(creditCardNumber[i]))
                {
                    return false;  // Return false if non-digit character is found
                }

                int creditCardNumberDigit = int.Parse(creditCardNumber[i].ToString());  // Convert the character to a digit

                if (alternate)  // If the digit is to be doubled
                {
                    creditCardNumberDigit *= 2;  // Double the digit
                    if (creditCardNumberDigit > 9)  // If the doubled digit is greater than 9, subtract 9
                    {
                        creditCardNumberDigit -= 9;
                    }
                }

                sum += creditCardNumberDigit;  // Add the digit to the sum
                alternate = !alternate;  // Toggle the alternate flag
            }

            // Return true if the sum is divisible by 10, otherwise false
            return (sum % 10 == 0);
        }
    }
}
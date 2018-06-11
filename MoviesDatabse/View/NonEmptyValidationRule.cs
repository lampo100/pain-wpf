using System.Globalization;
using System.Windows.Controls;

namespace MoviesDatabase.View
{
    public class NonEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult(false, "Cannot leave empty.");
            else
                return ValidationResult.ValidResult;
        }
    }
}

using System.Globalization;
using System.Windows.Controls;

namespace RxTracking.Views.Validators
{
    public class EmptyTextValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null) return new ValidationResult(true, string.Empty);
            var ok = value.Equals(string.Empty);
            return ok ? new ValidationResult(false,"Required Field") : new ValidationResult(true, string.Empty);
        }
    }
}
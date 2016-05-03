using System.Globalization;
using System.Windows.Controls;

namespace RxTracking.Views.Validators
{
    public class EmptyTextValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null) return new ValidationResult(true, "");
            var ok = value.Equals("");
            return ok ? new ValidationResult(false,"Required Field") : new ValidationResult(true, "");
        }
    }
}
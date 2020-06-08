using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Windows.Controls;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace BaseProject.Helpers
{

    public sealed class PasswordLength : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContex)
        {
            if (value == null)
                return new ValidationResult("The Password is required");
            if (value.ToString().Length > 5 || value.ToString().Length < 3)
                return new ValidationResult("The Password doesn't match the required length");
            return null;
        }
    }

    public class PasswordLengthUi : ValidationRule
    {
        public override System.Windows.Controls.ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new System.Windows.Controls.ValidationResult(false, "The Password is required");
            if (value.ToString().Length > 5 || value.ToString().Length < 3)
                return new System.Windows.Controls.ValidationResult(false, "The Password doesn't match the required length");
            return null;
        }
    }
}

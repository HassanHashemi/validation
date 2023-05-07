using System;
using System.ComponentModel.DataAnnotations;

namespace Validation.Annotations
{
    public class ValidPositiveAttribute : ValidationAttribute
    {
        public bool AllowDefaultValue { get; set; }

        public override bool IsValid(object value)
        {
            if (AllowDefaultValue && value == default)
                return true;

            try
            {
                Guard.Positive(Convert.ToDecimal(value), "Positive");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
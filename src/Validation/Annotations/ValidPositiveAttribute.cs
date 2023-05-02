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
            
            if (!(value is double s))
            {
                return false;
            }

            try
            {
                Guard.Positive(s, "Positive");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
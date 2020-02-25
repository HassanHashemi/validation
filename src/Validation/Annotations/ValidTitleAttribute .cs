using System;
using System.ComponentModel.DataAnnotations;

namespace Validation.Annotations
{
    public class ValidTitleAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (!(value is string s))
            {
                return false;
            }

            try
            {
                Guard.OnlyAlphaNumeric(s, "value");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

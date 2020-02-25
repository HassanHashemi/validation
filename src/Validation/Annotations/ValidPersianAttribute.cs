using System;
using System.ComponentModel.DataAnnotations;

namespace Validation.Annotations
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class ValidPersianAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(!(value is string s))
            {
                return false;
            }

            try
            {
                Guard.ValidPersian(s, "Persian");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

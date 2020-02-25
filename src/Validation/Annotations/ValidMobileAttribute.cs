using System;
using System.ComponentModel.DataAnnotations;

namespace Validation.Annotations
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class ValidMobileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(!(value is string s))
            {
                return false;
            }

            try
            {
                Guard.ValidMobile(s, "mobile");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

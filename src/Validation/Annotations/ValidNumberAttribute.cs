using System;
using System.ComponentModel.DataAnnotations;

namespace Validation.Annotations
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class ValidNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(!(value is string s))
            {
                return false;
            }

            try
            {
                Guard.ValidNumber(s, "number");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

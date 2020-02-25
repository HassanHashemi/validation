using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Validation.Annotations
{
    public class ValidGuidAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (!(value is Guid s))
            {
                return false;
            }

            try
            {
                Guard.NotEmpty(s, "guid");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

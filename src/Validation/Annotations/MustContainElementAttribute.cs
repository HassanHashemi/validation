using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Validation.Annotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MustContainElementAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var propertyType = value.GetType();

            // not a collection, just accept it!
            if (propertyType.GetInterface(nameof(IEnumerable)) == null)
            {
                return true;
            }

            try
            {
                var enumerable = (IEnumerable)value;
                enumerable.Cast<object>().ContainsElement(nameof(value));

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

using System;

namespace Validation.Annotations
{
    public class RequiredNoneDefault : ValidDateAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            if (value.Equals(Activator.CreateInstance(value.GetType())))
            {
                return false;
            }

            return true;
        }
    }
}

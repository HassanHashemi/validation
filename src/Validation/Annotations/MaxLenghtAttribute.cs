using System;
using System.Collections.Generic;
using System.Text;

namespace Validation.Annotations
{
    public class MaxLenghtAttribute : ValidDateAttribute
    {
        public MaxLenghtAttribute(int maxLenght)
        {
            this.Maxlenght = maxLenght;
        }

        public int Maxlenght{ get; set; }

        public override bool IsValid(object value)
        {
            if(!(value is string s))
            {
                return false;
            }

            try
            {
                Guard.MaxLength(s, this.Maxlenght, "MaxLenght");
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}

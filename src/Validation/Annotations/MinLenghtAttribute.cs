using System;
using System.Collections.Generic;
using System.Text;

namespace Validation.Annotations
{
    public class MinLenghtAttribute : ValidDateAttribute
    {
        public MinLenghtAttribute(int minLenght)
        {
            this.Minlenght = minLenght;
        }

        public int Minlenght{ get; set; }

        public override bool IsValid(object value)
        {
            if(!(value is string s))
            {
                return false;
            }

            try
            {
                Guard.MinLength(s, this.Minlenght, "MaxLenght");
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}

﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Validation.Annotations
{
    public class ValidPositiveAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
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

using System;
using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Attributes
{
    public class NotZeroOrNullValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || Convert.ToInt32(value) == 0)
                return false;

            return true;
        }
    }
}

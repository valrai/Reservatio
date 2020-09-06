using System;
using System.ComponentModel.DataAnnotations;
using Reservatio.Models.Extensions;

namespace Reservatio.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CpfValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cpf = Convert.ToString(value);

            if (string.IsNullOrEmpty(cpf))
                return new ValidationResult(ErrorMessage);
            var cpfIsValid = CpfValidation.IsValid(cpf);

            if (cpfIsValid)
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }

    internal class CpfValidation
    {
        public static bool IsValid(string value)
        {
            value = value.RemoveAllSpecialCharacters();

            if (value.Length != 11)
                return false;

            bool isEqual = true;
            for (int i = 1; i < 11 && isEqual; i++)
                if (value[i] != value[0])
                    isEqual = false;

            if (isEqual || value == "12345678909")
                return false;

            int[] numbers = new int[11];
            for (int i = 0; i < 11; i++)
                numbers[i] = int.Parse(
                value[i].ToString());

            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (10 - i) * numbers[i];

            int result = sum % 11;
            if (result == 1 || result == 0)
            {
                if (numbers[9] != 0)
                    return false;
            }
            else if (numbers[9] != 11 - result)
                return false;

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += (11 - i) * numbers[i];

            result = sum % 11;

            if (result == 1 || result == 0)
            {
                if (numbers[10] != 0)
                    return false;

            }
            else
                if (numbers[10] != 11 - result)
                return false;

            return true;
        }
    }
}

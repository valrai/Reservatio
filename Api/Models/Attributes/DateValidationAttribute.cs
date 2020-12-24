using Reservatio.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Reservatio.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DateValidationAttribute: ValidationAttribute
    {
            public DateTime MaxDate { get; set; } = DateTime.Today.AddYears(1);
            public DateTime MinDate { get; set; } = DateTime.Today;

            private string GetInvalidBirthdateErrorMessage() => ValidationMessagesResource_ptBR.The_informed_date_is_invalid;
            private string GetBirthdateOutOfRangeErrorMessage() =>
                string.Format(ValidationMessagesResource_ptBR
                        .Is_necessary_inform_a_date_between__0__and__1_,
                    MinDate.ToShortDateString(),
                    MaxDate.ToShortDateString());

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (DateTime.TryParse(value.ToString(), out DateTime result))
                {
                    if (result > MaxDate)
                        return new ValidationResult(GetBirthdateOutOfRangeErrorMessage());
                    if (result < MinDate)
                        return new ValidationResult(GetBirthdateOutOfRangeErrorMessage());
                    return ValidationResult.Success;
                }

                return new ValidationResult(GetInvalidBirthdateErrorMessage());
            }
        }
    }

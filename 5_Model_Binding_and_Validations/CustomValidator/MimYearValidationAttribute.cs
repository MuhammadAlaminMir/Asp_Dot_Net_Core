using System.ComponentModel.DataAnnotations;

namespace _5_Model_Binding_and_Validations.CustomValidator
{
    public class MinYearValidationAttribute : ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000;

        public string DefaultErrorMassage = $"Minimum Year should be {0}";
        public MinYearValidationAttribute()
        {

        }

        public MinYearValidationAttribute(int minimumYear)
        {
            MinimumYear = minimumYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           if(value != null)
            {
                DateTime date = (DateTime)value;
                if(date.Year >= MinimumYear)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMassage, MinimumYear));
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}

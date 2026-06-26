using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace _5_Model_Binding_and_Validations.CustomValidator
{
    public class CheckRelationshipStatus : ValidationAttribute
    {
        public string GirlFriendName { get; set; } = "";
        public string DefaultErrorMassage = "You haven't keep you Promise ";

        public CheckRelationshipStatus()
        {

        }
        public CheckRelationshipStatus (string girlFriendName)
        {
            GirlFriendName = girlFriendName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           if(value != null)
            {
                string WifeName = (string)value;
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(GirlFriendName);

                if (otherProperty != null)
                {
                    string? gfname = Convert.ToString(otherProperty.GetValue(validationContext.ObjectInstance));

                    Console.WriteLine("Wife Name : " + WifeName);
                    Console.WriteLine("Girl Friend Name : " + gfname);

                    if (!WifeName.Equals(gfname))
                    {
                        return new ValidationResult(ErrorMessage ?? DefaultErrorMassage);
                    }
                    else return ValidationResult.Success;
                }
                else return null;
            }
            return null;
        }
    }
}

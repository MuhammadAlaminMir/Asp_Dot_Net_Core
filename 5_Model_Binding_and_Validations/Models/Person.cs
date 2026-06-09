using _5_Model_Binding_and_Validations.CustomValidator;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace _5_Model_Binding_and_Validations.Models
{
    public class Person : IValidatableObject
    {
        [Required(ErrorMessage = "{0} can't be empty or null ")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        [RegularExpression(@"^[a-zA-Z\s .]+$", ErrorMessage = "{0} should only contain letters and spaces")]
        public string? PersonName { get ; set; }

        [Required(ErrorMessage = "{0} can't be empty or null ")]
        [EmailAddress(ErrorMessage = "{0} should be a valid email address")]
        public string? Email { get; set; }

        // Phone number should be exactly 11 digits long and should only contain numbers
        [RegularExpression(@"^\d{11}$", ErrorMessage = "{0} should be a valid phone number")]
        [Phone(ErrorMessage = "{0} should be a valid phone number")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "{0} can't be empty or null ")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} can't be empty or null ")]
        [Compare("Password", ErrorMessage = "{0} should match with {1}")]
        [Display(Name = "Re-Entered Password")]
        public string? ConfirmPassword { get; set; }

        [Range(14, 99, ErrorMessage = "{0} should be between {1} and {2}")]

        [ValidateNever] // This will prevent the validation of this property, even if it has validation attributes. It will be useful when we want to skip the validation of a property in some cases.
        public int? Age { get; set; }

        //[MinYearValidationAttribute(2005, ErrorMessage ="Date of Birth should not be newer then jan 01, {0}")]
        [MinYearValidationAttribute(2005)]
        public DateTime? DateOfBirth { get; set; }


        [Url(ErrorMessage = "{0} should be a valid URL")]
        public string? GithubLink { get; set; }

        //Bind Never Attribute make sure, even if the controller got the input, it don't bind that input with this model property
        [BindNever]
        public string GirlFriend { get; set; }

        [CheckRelationshipStatus("GirlFriend", ErrorMessage = "You haven't fulfilled your Promise")]
        public string Wife { get; set; }

        public override string ToString()
        {
            return $"Name: {PersonName}, Email: {Email}, Phone: {Phone}, Password: {Password}, ConfirmPassword: {ConfirmPassword},  Age: {Age}, GithubLink: {GithubLink}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (!GithubLink.Contains("github"))
            {
                yield return new ValidationResult("github link must contain github in it");
            }
        }
    }
}

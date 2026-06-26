namespace Razor_Views.Models
{
    public class Person
    {

        public string Name { get; set; }

        public DateTime? dateOfBirth { get; set; }

        public double? Age { get; set; }

        public Gender PersonGender { get; set; }
        public enum Gender
        {
            Male,
            Female,
            Other
        }
}
}

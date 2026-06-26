namespace _5_Model_Binding_and_Validations.Models
{
    public class Book
    {
        //[FromQuery]
        public int bookId { get; set; }     
        public string author { get; set; }

        public override string ToString()
        {
            return $"The bookId is - {bookId} and the author is {author}";
        }
    }
}

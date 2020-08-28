namespace BookManage.Models
{
    public class AddRequest
    {
        public string ISBN;

        public string name;

        public decimal price;

        public string date;

        public Author[] authors;
    }
    public class Author
    {
        public string name;

        public string sex;

        public string birthday;

    }

    public class AddResponse
    {

        public string result;

        public string message;

        public string ISBN;
    }
}
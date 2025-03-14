namespace LDRestaurant.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException() : base("Something went wrong!")
        {
        }

        public BaseException(string? message) : base(message)
        {
        }

        public BaseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}

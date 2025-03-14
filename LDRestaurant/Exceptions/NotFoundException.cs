namespace LDRestaurant.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string? message) : base($"Sorry, {message} was not found!")
        {
        }
    }
}

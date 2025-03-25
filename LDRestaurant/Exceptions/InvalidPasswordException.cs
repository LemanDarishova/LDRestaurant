namespace LDRestaurant.Exceptions
{
    public class InvalidPasswordException : BaseException
    {
        public InvalidPasswordException():base("Password and confirm password don't match!")
        {
        }
    }
}

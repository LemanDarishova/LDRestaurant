using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LDRestaurant.DTOs.Customer
{
    public class CustomerRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}

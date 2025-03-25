using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LDRestaurant.DTOs.Customer
{
    public record ChangePasswordDto
    {
        public string Email { get; set; }
        [PasswordPropertyText]
        public string CurrentPassword { get; set; }
        [PasswordPropertyText]
        public string NewPassword { get; set; }
        [Compare(nameof(NewPassword))]
        public string NewConfrimPassword { get; set; }
    }
}

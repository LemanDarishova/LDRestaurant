using LDRestaurant.DTOs.Customer;
using LDRestaurant.Models;

namespace LDRestaurant.Services.Interfaces
{
    public interface ICustomerService:IGenericService<CustomerRegisterDto, CustomerUpdateDto, CustomerGetAllDto, CustomerGetSingleDto>
    {
        Task<Customer> LoginAsync(CustomerLoginDto dto);
        Task ChangePasswordAsync(ChangePasswordDto dto);
    }
}

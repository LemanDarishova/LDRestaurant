using LDRestaurant.DTOs.Customer;
using LDRestaurant.Exceptions;
using LDRestaurant.Models;
using LDRestaurant.Repositories.Implements.Customers;
using LDRestaurant.Repositories.Interfaces.Customers;
using LDRestaurant.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LDRestaurant.Services.Implements
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerReadRepository _readRepository;
        private readonly ICustomerWriteRepository _writeRepository;

        public CustomerService()
        {
            _readRepository = new CustomerReadRepository();
            _writeRepository = new CustomerWriteRepository();
        }
        public async Task AddAsync(CustomerRegisterDto addDto)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = addDto.FirstName,
                LastName = addDto.LastName,
                PhoneNumber = addDto.PhoneNumber,
                Email = addDto.Email,
                Address = addDto.Address,
                CreatedAt = DateTime.UtcNow.AddHours(4)
            };

            if (addDto.Password != addDto.ConfirmPassword) throw new InvalidPasswordException();
            customer.Password = addDto.Password;
            await _writeRepository.AddAsync(customer);
            await _writeRepository.SaveAsync();
        }

        public async Task ChangePasswordAsync(ChangePasswordDto dto)
        {
            var loginDto = new CustomerLoginDto
            {
                Email = dto.Email,
                Password = dto.CurrentPassword
            };
            var customer = await LoginAsync(loginDto); //daxil olmayibsa
            if (dto.NewPassword != dto.NewConfrimPassword) throw new InvalidPasswordException();
            customer.Password = dto.NewPassword;
        }

        public async Task DeleteAsync(Guid id)
        {
            var customer = await _readRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
            if (customer == null) throw new NotFoundException("Customer");
            _writeRepository.Delete(customer);
            await _writeRepository.SaveAsync();
        }

        public async Task<List<CustomerGetAllDto>> GetAllAsync()
        {
            var customers = _readRepository.GetAllWhere(m => !m.isDeleted, false);
            var dtos = new List<CustomerGetAllDto>();
            dtos = await customers.Select(customer => new CustomerGetAllDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email
            }).ToListAsync();

            return dtos;
        }

        public async Task<CustomerGetSingleDto> GetSingleAsync(Guid id)
        {
            var customer = await _readRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, false);
            if (customer == null) throw new NotFoundException("Customer");
            var dto = new CustomerGetSingleDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                Address = customer.Address
            };
            return dto;
        }

        public async Task<Customer> LoginAsync(CustomerLoginDto dto)
        {
            var customer = await _readRepository.GetSingleAsync(c => c.Email == dto.Email && c.Password == dto.Password, false);
            if (customer != null) throw new NotFoundException("customer");
            return customer;
        }

        public async Task RecoverAsync(Guid id)
        {
            var customer = await _readRepository.GetSingleAsync(m => m.Id == id && m.isDeleted, true);

            if (customer == null) throw new NotFoundException("Customer");
            _writeRepository.Recover(customer);
            await _writeRepository.SaveAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var customer = await _readRepository.GetSingleAsync(m => m.Id == id, true);
            if (customer == null) throw new NotFoundException("Customer");
            _writeRepository.Remove(customer);
            await _writeRepository.SaveAsync();
        }

        public async Task UpdateAsync(Guid id, CustomerUpdateDto dto)
        {
            var customer = await _readRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
            if (customer == null) throw new NotFoundException("Category");

            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.PhoneNumber = dto.PhoneNumber;
            customer.Address = dto.Address;


            _writeRepository.Update(customer);
            await _writeRepository.SaveAsync();
        }
    }
}

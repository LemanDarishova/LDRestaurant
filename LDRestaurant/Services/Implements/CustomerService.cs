using LDRestaurant.DTOs.Category;
using LDRestaurant.DTOs.Customer;
using LDRestaurant.Exceptions;
using LDRestaurant.Migrations;
using LDRestaurant.Models;
using LDRestaurant.Repositories.Implements.Customers;
using LDRestaurant.Repositories.Interfaces.Customers;
using LDRestaurant.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
               FirstName = addDto.FirstName,
               LastName = addDto.LastName,
               PhoneNumber = addDto.PhoneNumber,
               Password = addDto.Password,
               Email = addDto.Email,
               Address = addDto.Address
            };
            await _writeRepository.AddAsync(customer);
            await _writeRepository.SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var customer = await _readRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
            if (customer == null) throw new NotFoundException("Customer");
            _writeRepository.Delete(customer);
            await _writeRepository.SaveAsync();
        }

        public async Task<List<CustomerListDto>> GetAllAsync()
        {
            var customers = _readRepository.GetAllWhere(m => !m.isDeleted, false);
            var dtos = new List<CustomerListDto>();
            dtos =customers.Select(customers => new CustomerListDto   
            {
               Id = customers.Id.ToString(),
               FirstName = customers.FirstName,
               LastName = customers.LastName,
               Email = customers.Email
            }).ToList();

            return dtos;
        }

        public async Task<CustomerDetailDto> GetSingleAsync(Guid id)
        {
            var customer = await _readRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, false);
            if (customer== null) throw new NotFoundException("Customer");
            var dto = new CustomerDetailDto
            {
                Id=customer.Id.ToString(),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                Address = customer.Address
            };
            return dto;
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
            var customer = await _readRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
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
            customer.Email = dto.Email;


            _writeRepository.Update(customer);
            await _writeRepository.SaveAsync();
        }
    }
}

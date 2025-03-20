using LDRestaurant.DTOs.Category;
using LDRestaurant.Exceptions;
using LDRestaurant.Migrations;
using LDRestaurant.Models;
using LDRestaurant.Repositories.Implements.RestaurantCategories;
using LDRestaurant.Repositories.Interfaces.RestaurantCategories;
using LDRestaurant.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDRestaurant.Services.Implements
{
    public class RestaurantCategoryService : ICategoryService
    {
        private readonly IRestaurantCategoryReadRepository _readRepository;
        private readonly IRestaurantCategoryWriteRepository _writeRepository;

        public RestaurantCategoryService()
        {
            _readRepository = new RestaurantCategoryReadRepository();
            _writeRepository = new RestaurantCategoryWriteRepository();
        }


        public async Task AddAsync(CategoryCommandDto addDto)
        {
            var restaurantCategory = new RestaurantCategory
            {
                Name = addDto.Name,
                CreatedAt = DateTime.UtcNow.AddHours(4)
            };
            await _writeRepository.AddAsync(restaurantCategory);
            await _writeRepository.SaveAsync();
        }



        public async Task DeleteAsync(Guid id)
        {
            var restaurantCategory = await _readRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
            if (restaurantCategory == null) throw new NotFoundException("Category");
            _writeRepository.Delete(restaurantCategory);
            await _writeRepository.SaveAsync();

        }

        public async Task<List<CategoryGetDto>> GetAllAsync()
        {
            var restaurantCategory = _readRepository.GetAllWhere(m => !m.isDeleted, false);
            var dtos = new List<CategoryGetDto>();
            dtos = restaurantCategory.Select(restaurantCategory => new CategoryGetDto   
            {
                Id = restaurantCategory.Id.ToString(),
                Name = restaurantCategory.Name
            }).ToList();

            return dtos;

        }


        public async Task<CategoryGetDto> GetSingleAsync(Guid id)
        {
            var restaurantCategory = await _readRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, false);
            if (restaurantCategory == null) throw new NotFoundException("Category");
            var dto = new CategoryGetDto
            {
                Id = restaurantCategory.Id.ToString(),
                Name = restaurantCategory.Name
            };
            return dto;

        }

        public async Task RecoverAsync(Guid id)
        {
            var restaurantCategory = await _readRepository.GetSingleAsync(m => m.Id == id && m.isDeleted, true);

            if (restaurantCategory == null) throw new NotFoundException("Category");
            _writeRepository.Recover(restaurantCategory);
            await _writeRepository.SaveAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var restaurantCategory = await _readRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
            if (restaurantCategory == null) throw new NotFoundException("Category");
            _writeRepository.Remove(restaurantCategory);
            await _writeRepository.SaveAsync();
        }

        public async Task UpdateAsync(Guid id, CategoryCommandDto dto)
        {
            var restaurantCategory = await _readRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
            if (restaurantCategory == null) throw new NotFoundException("Category");

            restaurantCategory.Name = dto.Name;
            restaurantCategory.UpdatedAt = DateTime.UtcNow.AddHours(4);

            _writeRepository.Update(restaurantCategory);
            await _writeRepository.SaveAsync();

        }
    }

}

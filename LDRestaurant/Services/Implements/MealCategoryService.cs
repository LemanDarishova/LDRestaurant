using LDRestaurant.DTOs.Category;
using LDRestaurant.DTOs.Meal;
using LDRestaurant.Exceptions;
using LDRestaurant.Models;
using LDRestaurant.Repositories.Implements;
using LDRestaurant.Repositories.Implements.MealCategories;
using LDRestaurant.Repositories.Interfaces;
using LDRestaurant.Repositories.Interfaces.MealCategories;
using LDRestaurant.Services.Interfaces;

namespace LDRestaurant.Services.Implements;

public class MealCategoryService : ICategoryService
{
    private readonly  IMealCategoryReadRepository _readRepository;
    private readonly IMealCategoryWriteRepository _writeRepository;

    public MealCategoryService()
    {
        _readRepository = new MealCategoryReadRepository();
        _writeRepository = new MealCategoryWriteRepository();
    }

    public async Task AddAsync(CategoryCommandDto addDto)
    {
        var mealCategory = new MealCategory
        {
            Name = addDto.Name,
            CreatedAt = DateTime.UtcNow.AddHours(4)
        };
        await _writeRepository.AddAsync(mealCategory);
        await _writeRepository.SaveAsync();
    }



    public async Task DeleteAsync(Guid id)
    {
        var mealCategory = await _readRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
        if (mealCategory == null) throw new NotFoundException("Category");
        _writeRepository.Delete(mealCategory);
        await _writeRepository.SaveAsync();

    }

    public async Task<List<CategoryGetDto>> GetAllAsync()
    {
        var mealCategories = _readRepository.GetAllWhere(m => !m.isDeleted, false);
        var dtos = new List<CategoryGetDto>();
        dtos = mealCategories.Select(mealCategories => new CategoryGetDto    //bir daha nezerden kecir
        {
            Id = mealCategories.Id.ToString(),
            Name = mealCategories.Name
        }).ToList();

        return dtos;

    }


    public async Task<CategoryGetDto> GetSingleAsync(Guid id)
    {
        var mealCategory = await _readRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, false);
        if (mealCategory == null) throw new NotFoundException("Category");
        var dto = new CategoryGetDto
        {
            Id = mealCategory.Id.ToString(),
            Name = mealCategory.Name
        };
        return dto;

    }

    public async Task RecoverAsync(Guid id)
    {
        var mealCategory = await _readRepository.GetSingleAsync(m => m.Id == id && m.isDeleted, true);

        if (mealCategory == null) throw new NotFoundException("Category");
        _writeRepository.Recover(mealCategory);
        await _writeRepository.SaveAsync();
    }

    public async Task RemoveAsync(Guid id)
    {
        var mealCategory = await _readRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
        if (mealCategory == null) throw new NotFoundException("Category");
        _writeRepository.Remove(mealCategory);
        await _writeRepository.SaveAsync();
    }

    public async Task UpdateAsync(Guid id, CategoryCommandDto dto)
    {
        var mealCategory = await _readRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
        if (mealCategory == null) throw new NotFoundException("Category");

        mealCategory.Name = dto.Name;
        mealCategory.UpdatedAt = DateTime.UtcNow.AddHours(4);

        _writeRepository.Update(mealCategory);
        await _writeRepository.SaveAsync();

    }

    
}

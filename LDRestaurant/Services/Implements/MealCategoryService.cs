using LDRestaurant.DTOs.MealCategory;
using LDRestaurant.Exceptions;
using LDRestaurant.Models;
using LDRestaurant.Repositories.Implements;
using LDRestaurant.Services.Interfaces;

namespace LDRestaurant.Services.Implements;

public class MealCategoryService : IMealCategoryService
{
    private readonly MealCategoryRepository _mealCategoryRepository;

    public MealCategoryService()
    {
        _mealCategoryRepository = new MealCategoryRepository();
    }

    public async Task AddAsync(MealCategoryCommandDto addDto)
    {
        var mealCategory = new MealCategory
        {
            Name = addDto.Name,
            CreatedAt = DateTime.UtcNow.AddHours(4)
        };
        await _mealCategoryRepository.AddAsync(mealCategory);
        await _mealCategoryRepository.SaveAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var mealCategory = await _mealCategoryRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
        if (mealCategory == null) throw new NotFoundException("Category");
        _mealCategoryRepository.Delete(mealCategory);
        await _mealCategoryRepository.SaveAsync();

    }

    public async Task<List<MealCategoryGetDto>> GetAllAsync()
    {
        var mealCategories = _mealCategoryRepository.GetAllWhere(m => !m.isDeleted, false);
        var dtos = new List<MealCategoryGetDto>();
        dtos = mealCategories.Select(mealCategories => new MealCategoryGetDto    //bir daha nezerden kecir
        {
            Id = mealCategories.Id.ToString(),
            Name = mealCategories.Name
        }).ToList();

        return dtos;

    }


    public async Task<MealCategoryGetDto> GetSingleAsync(Guid id)
    {
        var mealCategory = await _mealCategoryRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, false);
        if (mealCategory == null) throw new NotFoundException("Category");
        var dto = new MealCategoryGetDto
        {
            Id = mealCategory.Id.ToString(),
            Name = mealCategory.Name
        };
        return dto;

    }

    public async Task RecoverAsync(Guid id)
    {
        var mealCategory = _mealCategoryRepository.GetSingleAsync(m => m.Id == id && m.isDeleted, true)/await;
        if (mealCategory == null) throw new NotFoundException("Category");
        _mealCategoryRepository.Recover(mealCategory);
        await _mealCategoryRepository.SaveAsync();
    }

    public async Task RemoveAsync(Guid id)
    {
        var mealCategory = await _mealCategoryRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
        if (mealCategory == null) throw new NotFoundException("Category");
        _mealCategoryRepository.Remove(mealCategory);
        await _mealCategoryRepository.SaveAsync();
    }

    public async Task UpdateAsync(Guid id, MealCategoryCommandDto dto)
    {
        var mealCategory = await _mealCategoryRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
        if (mealCategory == null) throw new NotFoundException("Category");

        mealCategory.Name = dto.Name;
        mealCategory.UpdatedAt = DateTime.UtcNow.AddHours(4);

        _mealCategoryRepository.Update(mealCategory);
        await _mealCategoryRepository.SaveAsync();



    }
}

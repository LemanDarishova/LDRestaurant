using LDRestaurant.DTOs.Meal;
using LDRestaurant.Exceptions;
using LDRestaurant.Models;
using LDRestaurant.Repositories.Implements;
using LDRestaurant.Repositories.Interfaces;
using LDRestaurant.Services.Interfaces;

namespace LDRestaurant.Services.Implements;

public class MealService : IMealService
{
    private readonly IMealRepository _mealRepository;
    private readonly IReastaurantRepository _restaurantRepository;
    private readonly IMealCategoryRepository _categoryRepository;

    public MealService()
    {
        _mealRepository = new MealRepository();
        _restaurantRepository = new RestaurantRepository();
        _categoryRepository = new MealCategoryRepository();
    }

    private async Task<MealCategory> GetCategoryAsync(Guid categoryId)
    {
        var category = await _categoryRepository.GetSingleAsync(c => c.Id == categoryId && !c.isDeleted, false);
        if (category == null) throw new NotFoundException("category");
        return category;
    }

    private async Task<Restaurant> GetRestaurantAsync(Guid restaurantId)
    {
        var restaurant = await _restaurantRepository.GetSingleAsync(r => r.Id == restaurantId && !r.isDeleted, false);
        if (restaurant == null) throw new NotFoundException("restaurant");
        return restaurant;
    }

    public async Task AddAsync(MealCommandDto addDto)
    {
        var category = await GetCategoryAsync(addDto.CategoryID);
        var restaurant = await GetRestaurantAsync(addDto.RestaurantID);
        var meal = new Meal
        {
            Id = Guid.NewGuid(),
            Name = addDto.Name,
            Description = addDto.Description,
            Price = addDto.Price,
            RestaurantID = restaurant.Id,
            CategoryID = category.Id,
            CreatedAt = DateTime.UtcNow.AddHours(4),
            ImageName = addDto.ImageName,
            ImgUrl = addDto.ImageUrl,
            isDeleted = false
        };

        await _mealRepository.AddAsync(meal);
        await _mealRepository.SaveAsync();
    }

    public async Task RemoveAsync(Guid id)
    {
        var meal = await _mealRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
        if (meal == null) throw new NotFoundException("meal");
        _mealRepository.Remove(meal);
        await _mealRepository.SaveAsync();
    }

    public async Task UpdateAsync(Guid id, MealCommandDto updateDto)
    {
        var meal = await _mealRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
        if (meal == null) throw new NotFoundException("meal");

        meal.Name = updateDto.Name;
        meal.Description = updateDto.Description;
        meal.Price = updateDto.Price;
        meal.RestaurantID = updateDto.RestaurantID;
        meal.CategoryID = updateDto.CategoryID;
        meal.UpdatedAt = DateTime.UtcNow.AddHours(4);

        _mealRepository.Update(meal);
        await _mealRepository.SaveAsync();


    }

    public async Task DeleteAsync(Guid id)
    {
        var meal = await _mealRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
        if (meal == null) throw new NotFoundException("meal");
        _mealRepository.Delete(meal);
        await _mealRepository.SaveAsync();
    }

    public async Task RecoverAsync(Guid id)
    {
        var meal = await _mealRepository.GetSingleAsync(m => m.Id == id && m.isDeleted, true);
        if (meal == null) throw new NotFoundException("meal");
        _mealRepository.Recover(meal);
        await _mealRepository.SaveAsync();
    }

    public async Task<MealGetSingleDto> GetSingleAsync(Guid id)
    {
        var meal = await _mealRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, false, "Restaurant", "MealCategory");
        if (meal == null) throw new NotFoundException("meal");
        var dto = new MealGetSingleDto
        {
            Id = meal.Id.ToString(),
            Name = meal.Name,
            Description = meal.Description,
            Price = meal.Price,
            ImageName = meal.ImageName,
            ImgUrl = meal.ImgUrl,
            Category = meal.MealCategory.Name,
            Restaurant = meal.Restaurant.Name //include
        };

        return dto;

    }

    public async Task<List<MealGetAllDto>> GetAllAsync()
    {
        var meals = _mealRepository.GetAllWhere(m => !m.isDeleted, false);
        var dtos = meals.Select(meals => new MealGetAllDto
        {
            Id = meals.Id.ToString(),
            Name = meals.Name,
            Description = meals.Description,
            Price = meals.Price
        }).ToList();

        return dtos;
    }
}

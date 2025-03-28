﻿using LDRestaurant.DTOs.Meal;
using LDRestaurant.Exceptions;
using LDRestaurant.Models;
using LDRestaurant.Repositories.Implements;
using LDRestaurant.Repositories.Implements.Meals;
using LDRestaurant.Repositories.Interfaces;
using LDRestaurant.Repositories.Interfaces.Meals;
using LDRestaurant.Services.Implements.Helper;
using LDRestaurant.Services.Interfaces;
using LDRestaurant.Services.Interfaces.Helper;

namespace LDRestaurant.Services.Implements;

public class MealService : IMealService
{
    private readonly IMealReadRepository _readRepository;
    private readonly IMealWriteRepository _writeRepository;
    private readonly IGetModelService _getEntity;

    public MealService()
    {
        _writeRepository = new MealWriteRepository();
        _readRepository = new MealReadRepository();
        _getEntity = new GetModelService();
    }

    public async Task AddAsync(MealCommandDto addDto)
    {
        var category = await _getEntity.GetMealCategoryAsyn(addDto.CategoryID);
        var restaurant = await _getEntity.GetRestaurantAsync(addDto.RestaurantID);
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

        await _writeRepository.AddAsync(meal);
        await _writeRepository.SaveAsync();
    }

    public async Task RemoveAsync(Guid id)
    {
        var meal = await _readRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
        if (meal == null) throw new NotFoundException("meal");
        _writeRepository.Remove(meal);
        await _writeRepository.SaveAsync();
    }

    public async Task UpdateAsync(Guid id, MealCommandDto updateDto)
    {
        var meal = await _readRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
        if (meal == null) throw new NotFoundException("meal");

        meal.Name = updateDto.Name;
        meal.Description = updateDto.Description;
        meal.Price = updateDto.Price;
        meal.RestaurantID = updateDto.RestaurantID;
        meal.CategoryID = updateDto.CategoryID;
        meal.UpdatedAt = DateTime.UtcNow.AddHours(4);

        _writeRepository.Update(meal);
        await _writeRepository.SaveAsync();


    }

    public async Task DeleteAsync(Guid id)
    {
        var meal = await _readRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, true);
        if (meal == null) throw new NotFoundException("meal");
        _writeRepository.Delete(meal);
        await _writeRepository.SaveAsync();
    }

    public async Task RecoverAsync(Guid id)
    {
        var meal = await _readRepository.GetSingleAsync(m => m.Id == id && m.isDeleted, true);
        if (meal == null) throw new NotFoundException("meal");
        _writeRepository.Recover(meal);
        await _writeRepository.SaveAsync();
    }

    public async Task<MealGetSingleDto> GetSingleAsync(Guid id)
    {
        var meal = await _readRepository.GetSingleAsync(m => m.Id == id && !m.isDeleted, false, "Restaurant", "MealCategory");
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
        var meals = _readRepository.GetAllWhere(m => !m.isDeleted, false);
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

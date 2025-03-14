using LDRestaurant.DTOs.Restaurant;
using LDRestaurant.Exceptions;
using LDRestaurant.Models;
using LDRestaurant.Repositories.Implements.Restaurants;
using LDRestaurant.Repositories.Interfaces.Restaurants;
using LDRestaurant.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LDRestaurant.Services.Implements;

public class RestaurantService : IRestaurantService
{
    private readonly IRestaurantReadRepository _readRepository; //readonly vs constant
    private readonly IRestaurantWriteRepository _writeRepository;
    public RestaurantService()
    {
        _readRepository = new RestaurantReadRespoitory(); //polymorphism
        _writeRepository = new RestaurantWriteRepository();
    }
    public async Task AddAsync(RestaurantCommandDto dto)
    {

        //var sentence = true, sentence = 5 //compile goturur, tip deyismir.
        //object sentence = (bool)sentence - casting - unboxing 
        //dynamic sentence = true, sentence = 5, sentence = "yasil" //runtime, sonuncu deyeri goturur

        var restaurant = new Restaurant
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Location = dto.Location,
            Description = dto.Description,
            Phone = dto.Phone,
            CreatedAt = DateTime.UtcNow.AddHours(4),
            CategoryID = dto.CategoryId,
        };
        await _writeRepository.AddAsync(restaurant);
        await _writeRepository.SaveAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var restaurant = await _readRepository.GetSingleAsync(r => r.Id == id && !r.isDeleted, true);
        if (restaurant == null) throw new NotFoundException("restaurant");
        _writeRepository.Delete(restaurant);
        await _writeRepository.SaveAsync();
    }


    public async Task<List<RestaurantGetAllDto>> GetAllAsync()
    {
        var restaurants = _readRepository.GetAllWhere(r => !r.isDeleted, false);
        var dtos = new List<RestaurantGetAllDto>();
        dtos = await restaurants.Select(restaurant => new RestaurantGetAllDto
        {
            Id = restaurant.Id.ToString(),
            Name = restaurant.Name,
            Description = restaurant.Description
        }).ToListAsync();
        return dtos;
    }

    public async Task<RestaurantGetSingleDto> GetSingleAsync(Guid id)
    {
        var restaurant = await _readRepository.GetSingleAsync(r => r.Id == id && !r.isDeleted, false);
        if (restaurant == null) throw new NotFoundException("restaurant");
        var dto = new RestaurantGetSingleDto
        {
            Id = restaurant.Id.ToString(),
            Name = restaurant.Name,
            Description = restaurant.Description,
            Phone = restaurant.Phone,
            Location = restaurant.Location
        };
        return dto;
    }

    public async Task RecoverAsync(Guid id)
    {
        var restaurant = await _readRepository.GetSingleAsync(r => r.Id == id && r.isDeleted, true);
        if (restaurant == null) throw new NotFoundException("restaurant");
        _writeRepository.Recover(restaurant);
        await _writeRepository.SaveAsync();
    }

    public async Task RemoveAsync(Guid id)
    {
        var restaurant = await _readRepository.GetSingleAsync(r => r.Id == id && !r.isDeleted, true);
        if (restaurant == null) throw new NotFoundException("restaurant");
        _writeRepository.Remove(restaurant);
        await _writeRepository.SaveAsync();
    }

    public async Task UpdateAsync(Guid id, RestaurantCommandDto dto)
    {
        var restaurant = await _readRepository.GetSingleAsync(r => r.Id == id && !r.isDeleted, true);
        if (restaurant == null) throw new NotFoundException("restaurant");

        restaurant.Name = dto.Name;
        restaurant.Description = dto.Description;
        restaurant.Location = dto.Description;
        restaurant.Phone = dto.Phone;
        restaurant.UpdatedAt = DateTime.UtcNow.AddHours(4);

        _writeRepository.Update(restaurant);
        await _writeRepository.SaveAsync();
    }
}

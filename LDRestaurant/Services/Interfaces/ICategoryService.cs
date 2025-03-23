using LDRestaurant.DTOs.Category;

namespace LDRestaurant.Services.Interfaces;

public interface ICategoryService : IGenericService<CategoryCommandDto, CategoryCommandDto, CategoryGetDto, CategoryGetDto>
{
}

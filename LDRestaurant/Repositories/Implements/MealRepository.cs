using LDRestaurant.Contexts;
using LDRestaurant.Models;
using LDRestaurant.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LDRestaurant.Repositories.Implements;

public class MealRepository :GenericRepository<Meal>, IMealRepository
{
}

// See https://aka.ms/new-console-template for more information
using LDRestaurant.Contexts;

Console.WriteLine("Hello, World!");

//Restaurant restaruant = new Restaurant(); //nonstatic - instance yaratmaq vacibdir.
//restaruant.Description = "Desc1";

//ServiceRegistration.Description = "Desc2"; //static - instance yaratmadan el catandir
////nonstatic class icinde sttaic member yaratmaq olur.
////static icinde nonstatic olmur
LDRestaurantDbContext context = new LDRestaurantDbContext();

#region Restaurant
//var dto = new RestaurantCommandDto()
//{
//    Name = "BurgerLand",
//    Description = "Best burgers",
//    Location = "Baki, Sabunchu, U.Hadjibeyov 100",
//    Phone = "0505555354"
//};

//IRestaurantService restaurant = new RestaurantService();
//restaurant.Add(dto);
//Console.WriteLine("Restaurant was added successfully!");

//string id = "D9BA21FF-DB0C-4D02-9770-4CF7C7399AEC"; //birbasa guid deyer vermek olmur, ona gore string verib guide cevirirem.
//restaurant.Remove(Guid.Parse(id));
//Console.WriteLine("Restaurant was removed successfully!");

//restaurant.Delete(Guid.Parse(id));
//Console.WriteLine("Restaurant was removed successfully!");

//restaurant.Recover(Guid.Parse(id));
//Console.WriteLine("Restaurant was recovered successfully!");

//var getSingleDto = restaurant.GetSingle(Guid.Parse(id));
//Console.WriteLine($"ID: {getSingleDto.Id}\nName:{getSingleDto.Name}\nDescription:{getSingleDto.Description}\nPhone:{getSingleDto.Phone}\nLocation:{getSingleDto.Location}");

//var dtos = restaurant.GetAllRestaurants();
//foreach (var getAllDto in dtos)
//{
//    Console.WriteLine($"ID: {getAllDto.Id}\nName: {getAllDto.Name}\nDescription: {getAllDto.Description}\n");
//}
#endregion

#region MealCategory
//var categoryDto = new MealCategoryCommandDto
//{
//    Name = "Fastfood"
//};

//IMealCategoryService _categoryService = new MealCategoryService();
//_categoryService.Add(categoryDto);
//Console.WriteLine("Category was added successfully!");
#endregion

#region Meal
//var categoryId = "0F663F77-A2D1-4E5F-E291-08DD56715C44";
//var restaurantId = "D9BA21FF-DB0C-4D02-9770-4CF7C7399AEC";
//var mealDto = new MealCommandDto
//{
//    Name = "Pizza",
//    Description = "Kolbasali pizza",
//    Price = 18,
//    RestaurantID = Guid.Parse(restaurantId),
//    CategoryID = Guid.Parse(categoryId),
//    ImageUrl = "https://www.simplyrecipes.com/thmb/KE6iMblr3R2Db6oE8HdyVsFSj2A=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2019__09__easy-pepperoni-pizza-lead-3-1024x682-583b275444104ef189d693a64df625da.jpg",
//    ImageName = "filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2019__09__easy-pepperoni-pizza-lead-3-1024x682-583b275444104ef189d693a64df625da.jpg"
//};


//IMealService _mealService = new MealService();
//_mealService.Add(mealDto);
//Console.WriteLine("Meal was added successfully!");
#endregion
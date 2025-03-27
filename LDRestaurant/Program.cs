// See https://aka.ms/new-console-template for more information
using LDRestaurant.Contexts;
using LDRestaurant.Services.Implements;
using LDRestaurant.Services.Interfaces;

Console.WriteLine("Hello, World!");

//Restaurant restaruant = new Restaurant(); //nonstatic - instance yaratmaq vacibdir.
//restaruant.Description = "Desc1";

//ServiceRegistration.Description = "Desc2"; //static - instance yaratmadan el catandir
////nonstatic class icinde sttaic member yaratmaq olur.
////static icinde nonstatic olmur
LDRestaurantDbContext context = new LDRestaurantDbContext();

#region RestaurantCategory
//var categoryDto = new CategoryCommandDto
//{
//    Name = "Ailevi"
//};

//var _categoryService = new RestaurantCategoryService();
//await _categoryService.AddAsync(categoryDto);
//Console.WriteLine("Category was added successfully!");
#endregion

#region Restaurant
//var categoryId = "EF3B2C71-B8D8-4909-79A4-08DD6B8D57B7";
//var dto = new RestaurantCommandDto()
//{
//    Name = "BurgerLand",
//    Description = "Best burgers",
//    Location = "Baki, Sabunchu, U.Hadjibeyov 100",
//    Phone = "0505555354",
//    CategoryId = Guid.Parse(categoryId)
//};

//IRestaurantService restaurant = new RestaurantService();
//await restaurant.AddAsync(dto);
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
//var categoryDto = new CategoryCommandDto
//{
//    Name = "Fastfood"
//};

//var _categoryService = new MealCategoryService();
//await _categoryService.AddAsync(categoryDto);
//Console.WriteLine("Category was added successfully!");
#endregion

#region Meal
//var categoryId = "6D190A16-A014-4BF0-0A9B-08DD6B8D16EB";
//var restaurantId = "74791008-AEA2-4CB0-A837-95CB7CED3B36";
//var mealDto = new MealCommandDto
//{
//    Name = "Burger",
//    Description = "Etli burger",
//    Price = 18,
//    RestaurantID = Guid.Parse(restaurantId),
//    CategoryID = Guid.Parse(categoryId),
//    ImageUrl = "https://www.simplyrecipes.com/thmb/KE6iMblr3R2Db6oE8HdyVsFSj2A=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2019__09__easy-pepperoni-pizza-lead-3-1024x682-583b275444104ef189d693a64df625da.jpg",
//    ImageName = "filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2019__09__easy-pepperoni-pizza-lead-3-1024x682-583b275444104ef189d693a64df625da.jpg"
//};


//IMealService _mealService = new MealService();
//await _mealService.AddAsync(mealDto);
//Console.WriteLine("Meal was added successfully!");
#endregion

#region Customer 

//var registerDto = new CustomerRegisterDto
//{
//    FirstName = "Leyla",
//    LastName = "Heydarova",
//    Address = "Baku, Sabunchu",
//    Email = "lbadalzade@gmail.com",
//    PhoneNumber = "+994 55 555 55 55",
//    Password = "Leyla123@",
//    ConfirmPassword = "Leyla123@"
//};

//ICustomerService _customerService = new CustomerService();
//await _customerService.AddAsync(registerDto);
//var id = "186A1098-34B4-42D2-91C2-FAEBE2375D38";
////await _customerService.RemoveAsync(Guid.Parse(id));
//Console.WriteLine("Customer was creted!");
#endregion

#region Order
//var mealId1 = "B7168A1A-D875-4F8A-8676-C246E0BBF90A";
//var detailDto1 = new OrderDetailCreateDto
//{
//    MealID = Guid.Parse(mealId1),
//    Unit = 2
//};
//var mealId2 = "E34FC407-0FC2-4946-9A7D-E80442CA2ABB";
//var detailDto2 = new OrderDetailCreateDto
//{
//    MealID = Guid.Parse(mealId2),
//    Unit = 3
//};
//var details = new List<OrderDetailCreateDto>()
//{
//    detailDto1,
//    detailDto2
//};
//var customerId = "7D1584C4-22D9-4F97-ACB0-842D326CF191";
//var orderDto = new OrderCreateDto
//{
//    CustomerID = Guid.Parse(customerId),
//    DetailsDtos = details
//};
IOrderService _orderService = new OrderService();
//await _orderService.AddAsync(orderDto);
var orderId = "D070C62D-0BC4-41A7-8174-50A187B582C1";
//await _orderService.RemoveAsync(Guid.Parse(orderId));
//Console.WriteLine("Order was created");
//var customerID = "7D1584C4-22D9-4F97-ACB0-842D326CF191";
var dto = await _orderService.GetSingleAsync(Guid.Parse(orderId));
//foreach (var dto in dtos)
//{
//    Console.WriteLine($"ID:{dto.Id}\nOrderTrackingNumber:{dto.OrderTrackingNumber}\nCustomer:{dto.CustomerName}\nTotal: {dto.TotalPrice} AZN\n{dto.TotalCounts} pors\n");
//}
Console.WriteLine($"\nRestaurant:{dto.RestaurantName}\nID:{dto.Id}\nOrderTrackingNumber:{dto.OrderTrackingNumber}\nCustomer:{dto.CustomerName}\nTotal: {dto.TotalPrice} AZN\n{dto.TotalCounts} pors\n");
foreach (var detail in dto.DetailGetDtos)
{
    Console.WriteLine($"[ID: {detail.Id}\nMeal: {detail.MealName}  {detail.Unit}  {detail.Price} AZN]\n");
}
#endregion
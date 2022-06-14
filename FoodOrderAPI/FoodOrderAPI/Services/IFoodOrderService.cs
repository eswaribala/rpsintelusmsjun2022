using FoodOrderAPI.Models;

namespace FoodOrderAPI.Services
{
    public interface IFoodOrderService
    {

        Task<string> PublishOrder(Food food);
    }
}

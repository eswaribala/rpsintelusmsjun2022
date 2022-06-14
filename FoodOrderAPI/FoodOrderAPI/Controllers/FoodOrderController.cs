using FoodOrderAPI.Models;
using FoodOrderAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodOrderController : ControllerBase
    {
       
        private IFoodOrderService _foodOrderService;

        public FoodOrderController(IFoodOrderService foodOrderService)
        {
            _foodOrderService = foodOrderService;
            

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Food food)
        {
                      
            return Ok(await _foodOrderService.PublishOrder(food));

        }




    }
}

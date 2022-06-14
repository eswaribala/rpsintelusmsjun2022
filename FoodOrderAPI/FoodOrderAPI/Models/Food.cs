namespace FoodOrderAPI.Models
{
    public class Food
    {

        public string? Code { get; set; }
        public string? Name { get; set; }
        public int Qty { get; set; }

        public DateTime OrderDate { get; set; } 

    }
}

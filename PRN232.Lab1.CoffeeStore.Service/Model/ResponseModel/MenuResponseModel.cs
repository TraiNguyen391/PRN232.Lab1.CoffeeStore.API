
namespace PRN232.Lab1.CoffeeStore.Service.Model.ResponseModel
{
    public class MenuResponseModel
    {
        public int MenuId { get; set; }

        public string Name { get; set; }

        public DateOnly FromDate { get; set; }

        public DateOnly? ToDate { get; set; }

        public List<MenuProductResponseModel> Products { get; set; } = new();
    }

    public class MenuProductResponseModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

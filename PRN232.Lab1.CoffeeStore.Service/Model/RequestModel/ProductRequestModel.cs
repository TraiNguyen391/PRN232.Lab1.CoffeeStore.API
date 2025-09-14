using System.ComponentModel.DataAnnotations;

namespace PRN232.Lab1.CoffeeStore.Service.Model.RequestModel
{
    public class ProductRequestModel
    {
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(100, ErrorMessage = "Tên sản phẩm tối đa 100 ký tự")]
        public string Name { get; set; } = null!;

        [StringLength(500, ErrorMessage = "Mô tả tối đa 500 ký tự")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "CategoryId bắt buộc")]
        public int CategoryId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PRN232.Lab1.CoffeeStore.Service.Model.RequestModel
{
    public class MenuRequestModel : IValidatableObject
    {
        [Required(ErrorMessage = "Tên menu không được để trống")]
        [StringLength(100, ErrorMessage = "Tên menu tối đa 100 ký tự")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Ngày bắt đầu không được để trống")]
        public DateOnly FromDate { get; set; }

        [Required(ErrorMessage = "Ngày kết thúc không được để trống")]
        public DateOnly ToDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);

            if (FromDate < today)
            {
                yield return new ValidationResult(
                    "Ngày bắt đầu không được ở quá khứ",
                    new[] { nameof(FromDate) }
                );
            }

            if (ToDate < FromDate)
            {
                yield return new ValidationResult(
                    "Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu",
                    new[] { nameof(ToDate) }
                );
            }

            if (ToDate < today)
            {
                yield return new ValidationResult(
                    "Ngày kết thúc không được ở quá khứ",
                    new[] { nameof(ToDate) }
                );
            }
        }
    }
}

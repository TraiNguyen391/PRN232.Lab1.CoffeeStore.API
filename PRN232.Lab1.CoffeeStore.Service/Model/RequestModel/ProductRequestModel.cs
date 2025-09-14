using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Service.Model.RequestModel
{
    public class ProductRequestModel
    {
        public string? Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public decimal? Price { get; set; }
        public int CategoryId { get; set; }
    }
}

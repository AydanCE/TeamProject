using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class ProductDetailDto : IDto
    {
        public string SubcategoryName { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int StockCount { get; set; }
        public int ProductId { get; set; }
        public int SubcategoryId { get; set; }
    }
}

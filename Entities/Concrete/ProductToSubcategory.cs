using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProductToSubCategory : BaseEntity
    {
        public int ProductId { get; set; }
        public int SubCategoryId { get; set; }
    }
}

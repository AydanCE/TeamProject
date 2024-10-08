﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProductDetail : BaseEntity
    {
        public int ProductId { get; set; }
        public int SubcategoryId { get; set; }
        public string SubcategoryName {  get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
    }
}

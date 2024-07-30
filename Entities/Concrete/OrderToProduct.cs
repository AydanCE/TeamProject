﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OrderToProduct : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}

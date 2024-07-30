using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order : BaseEntity
    {
        public string OrderCode { get; set; }
        public double TotalPrice { get; set; }
        public int UserId { get; set; }
        public int RegionId { get; set; }
    }
}

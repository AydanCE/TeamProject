using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class RegionDto : IDto
    {
        public int RegionId { get; set; }
        public int RegionName { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderStatus { get; set; }
    }
}

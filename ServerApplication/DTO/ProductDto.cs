using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApplication.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public double? Amount { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public int IdCategory { get; set; }
    }
}

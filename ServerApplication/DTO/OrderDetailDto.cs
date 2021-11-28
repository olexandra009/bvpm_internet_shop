using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApplication.DTO
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public double Amount { get; set; }
        public int IdOrder { get; set; }
    }
}

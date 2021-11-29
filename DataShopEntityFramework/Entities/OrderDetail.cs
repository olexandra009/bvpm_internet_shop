using System;
using System.Collections.Generic;

#nullable disable

namespace DataShopEntityFramework.Entities
{
    public class OrderDetail
    {
        public int IdProduct { get; set; }
        public double Amount { get; set; }
        public int IdOrder { get; set; }
        public int Id { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}

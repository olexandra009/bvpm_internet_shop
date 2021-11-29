using System;
using System.Collections.Generic;

#nullable disable

namespace DataShopEntityFramework.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public double? Amount { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public int IdCategory { get; set; }

        public List<Review> Reviews { get; set; }
        public List<OrderDetail> Orders { get; set; }
        public Category Category { get; set; }

    }
}

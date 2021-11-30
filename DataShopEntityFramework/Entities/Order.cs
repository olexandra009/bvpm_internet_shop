using System;
using System.Collections.Generic;

#nullable disable

namespace DataShopEntityFramework.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhoneNum { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public List<OrderDetail> Details { get; set; }
    }
}

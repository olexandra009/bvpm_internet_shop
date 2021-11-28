using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApplication.Models
{
    public class OrderModel : IModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhoneNum { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public List<OrderDetailsModel> Details { get; set; }

    }
}

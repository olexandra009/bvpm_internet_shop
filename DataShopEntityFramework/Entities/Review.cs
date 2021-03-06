using System;
using System.Collections.Generic;

#nullable disable

namespace DataShopEntityFramework.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int? Stars { get; set; }
        public int IdProduct { get; set; }

        public Product Product { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApplication.Models
{
    public class ReviewModel:IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int? Stars { get; set; }
        public int IdProduct { get; set; }
    }
}

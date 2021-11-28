namespace ServerApplication.Models
{
    public class ProductModel : IModel
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

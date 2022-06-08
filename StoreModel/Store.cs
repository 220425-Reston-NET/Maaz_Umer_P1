using System.ComponentModel.DataAnnotations;

namespace StoreModel
{
    
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public Store()
        {
            Id = 0;
            Name = "Luka";
            Products = new List<Product>();
        }
    }
}
using System.Text.Json;
using StoreModel;

namespace AppDL
{
    public class AddressRepository : IRepository<Product>
    {
        private string _filepath = "../AppDL/Data/Items.json";
        public void Add(Product c_resources)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            string jsonString = File.ReadAllText(_filepath);
            List<Product> listofItems = JsonSerializer.Deserialize<List<Product>>(jsonString);

            return listofItems;
        }

        public Task<List<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Product p_resources)
        {
            throw new NotImplementedException();
        }

        public void Update(Inventory joinTable)
        {
            throw new NotImplementedException();
        }

        // public void Update(Inventory joinTable)
        // {
        //     throw new NotImplementedException();
        // }

        public void update(Product p_resources)
        {
            throw new NotImplementedException();
        }
    }
}
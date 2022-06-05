using System.Text.Json;
using StoreModel;

namespace AppDL
{
    public class ItemRespository : IRepository<Customer>
    {
        private string _filepath = "../AppDL/Data/Items.json";
        public void Add(Customer c_resources)
        {
            throw new NotImplementedException();
        }


        public List<Customer> GetAll()
        {
            string jsonString = File.ReadAllText(_filepath);
            List<Customer> listofItems = JsonSerializer.Deserialize<List<Customer>>(jsonString);

            return listofItems;
        }

        public Task<List<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void update(Customer p_resources)
        {
            throw new NotImplementedException();
        }
    }
}
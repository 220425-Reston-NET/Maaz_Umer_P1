using System.Text.Json;
using StoreModel;

namespace AppDL
{
    //This class is responsible for storing and reading our data
    public class CustomerRepository : IRepository<Customer>
    {
        private string _filepath = "../AppDL/Data/App.json";

        //Purpose of this method is to add customer information to our data
        public void Add (Customer c_app)
        {
            List<Customer> listofCustomer = GetAll(); //
            listofCustomer.Add(c_app);

            string jsonString = JsonSerializer.Serialize(listofCustomer, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(_filepath, jsonString);   

            //return c_app;
        }

        public List<Customer> GetAll()
        {
            string jsonString = File.ReadAllText(_filepath);
            List<Customer> listOfInformation = JsonSerializer.Deserialize<List<Customer>>(jsonString);

            return listOfInformation;
        }

        public Task<List<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void update(Customer p_resources)
        {
            throw new NotImplementedException();
        }

        public void Update(Inventory joinTable)
        {
            throw new NotImplementedException();
        }
    }

}

using AppDL;
using StoreModel;

namespace AppBL
{
    public class CustomerBL : IAppBL //
    {
        //================================= Dependency Injection ========================== 
        private IRepository<Customer> _custRepo;
        public CustomerBL(IRepository<Customer> c_custRepo)
        {
            _custRepo = c_custRepo;
        }

        //==================================================================================

        public void AddCustomer(Customer c_app)
        {
                _custRepo.Add(c_app);

        }

        public void AddListToCustomer(Customer a_CustomerName)
        {
            throw new NotImplementedException();
        }

        public Customer SearchCustomerByName(string c_appName)
        {
            List<Customer> currentListofCustomer = _custRepo.GetAll();

            foreach (Customer appObj in currentListofCustomer)
            {
                //condition to check that the name is similar
                if (appObj.Name == c_appName)
                {
                    return appObj;
                }
            }
            //There is no return
            throw new NotImplementedException("No customer was found!");
        }

        public List<Customer> SearchCustomerByNumber(int c_appNumber)
        {
            throw new NotImplementedException("No customer was found!");
        }

        public List<Customer> GetAllCustomer()
        {
            return _custRepo.GetAll();
        }
                public async Task<List<Customer>> GetAllCustomerAsync()
        {
            return await _custRepo.GetAllAsync();
        }
    }
}
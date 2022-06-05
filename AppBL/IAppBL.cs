using StoreModel;

namespace AppBL
{
    /// <summary>
    /// Business layer is responsible for further validation or process of data obtained from the database or the user 
    /// What kind of process? Thats all depends on the type of functionality will be doing
    /// </summary>
    public interface IAppBL
    {

        /// <summary>
        /// Add Customer to the database
        /// Randomize the Price property of the Customer
        /// </summary>
        /// <param name="c_app">This is the customer object that will be added to the DB</param>
        /// <returns></returns>
        void AddCustomer(Customer c_app);

        /// <summary>
        /// This will Search for a customer in DB using their name
        /// </summary>
        /// <param name="a_CustomerName">Name of the customer used to search</param>
        /// <returns>Mulitipe customers if they have matching name</returns>
        Customer SearchCustomerByName(string a_CustomerName);

        /// <summary>
        /// This will Search for a customer in DB using their phone number
        /// </summary>
        /// <param name="a_CustomerNumb">Phone number of the customer used to search</param>
        /// <returns></returns>
        List<Customer> SearchCustomerByNumber(int a_CustomerNumb);

        /// <summary>
        /// Will give the current customer in the DB async
        /// </summary>
        /// <returns>A task of list object</returns>
        Task<List<Customer>> GetAllCustomerAsync();

        void AddListToCustomer(Customer a_CustomerName);
        /// <summary>
        /// will give current customer in the DB
        /// </summary>
        /// <returns>List objects that holds customer</returns>
        List<Customer> GetAllCustomer();
    }

} 

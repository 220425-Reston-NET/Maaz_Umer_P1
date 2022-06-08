using Microsoft.Data.SqlClient;
using StoreModel;

namespace AppDL
{
    public class SQLCustomerRepository : IRepository<Customer>
    {
        //=================== Dependency Injection ==========================
        private string _connectionString;

        public SQLCustomerRepository(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }

        //=====================Dependency Injection ========================
        public void Add(Customer c_resources)
        {
            string SQLQuery = "insert into Customer1 values (@customerName,@CustomerA,@CustomerN)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);
                command.Parameters.AddWithValue("@customerName", c_resources.Name);
                command.Parameters.AddWithValue("@CustomerA", c_resources.Address);
                command.Parameters.AddWithValue("@CustomerN", c_resources.PhoneNumber);

                //Execute sql statement that is nonquery meaning it will not give any information back (unlike a select statement)
                command.ExecuteNonQuery();
            }
        }
        //-----------------------------Without Async-----------------------------------
        public List<Customer> GetAll()
        {
            string SQLQuery = @"select * from Customer1";
            List<Customer> listOfCustomer = new List<Customer>();

            //SqlConnection object is responsible for establishing a connection to your database
            //Hence why we pass out connectionString information when we construct that object
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                //This opens the connection to the database
                con.Open();

                //SqlCommand object is responsible for executing sql statements to a database
                //It needs a string that is a sql statement
                //It needs a Sqlconnection obj that has a connection to a database
                SqlCommand command = new SqlCommand(SQLQuery, con);

                //SqlDataReader object is responsible for reading information from a SQL Server database (Since it gives tables and tables doesn't exist in C# only objects/classes)
                SqlDataReader reader = command.ExecuteReader();

                //Mapping the table format that SQL understands to a List collection that C# understands
                //While loop because we don't know how many rows there will be in this table
                //reader.Read() method goes from row to row
                while (reader.Read())
                {
                    //We are adding a new Pokemon object to our list collection
                    listOfCustomer.Add(new Customer()
                    {

                        //The new pokemon will hold the properties obtained from a single row in SQL
                        //It is Zero-based index meaning the first column would be a 0

                        CustomerID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2),
                        PhoneNumber = reader.GetInt32(3)
                        //Addresses = GiveProductToCustomer(reader.GetInt32(0)) // might be the issue 
                    });
                }

                return listOfCustomer;
            }
        }
        //--------------------------------------With Async--------------------------------------
        public async Task<List<Customer>> GetAllAsync()
        {
            string SQLQuery = @"select * from Customer1";
            List<Customer> listOfCustomer = new List<Customer>();

            //SqlConnection object is responsible for establishing a connection to your database
            //Hence why we pass out connectionString information when we construct that object
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                //This opens the connection to the database
                await con.OpenAsync();

                //SqlCommand object is responsible for executing sql statements to a database
                //It needs a string that is a sql statement
                //It needs a Sqlconnection obj that has a connection to a database
                SqlCommand command = new SqlCommand(SQLQuery, con);

                //SqlDataReader object is responsible for reading information from a SQL Server database (Since it gives tables and tables doesn't exist in C# only objects/classes)
                SqlDataReader reader = await command.ExecuteReaderAsync();

                //Mapping the table format that SQL understands to a List collection that C# understands
                //While loop because we don't know how many rows there will be in this table
                //reader.Read() method goes from row to row
                while (await reader.ReadAsync())
                {
                    //We are adding a new Pokemon object to our list collection
                    listOfCustomer.Add(new Customer()
                    {

                        //The new pokemon will hold the properties obtained from a single row in SQL
                        //It is Zero-based index meaning the first column would be a 0

                        CustomerID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2),
                        PhoneNumber = reader.GetInt32(3)

                        // Addresses = GiveProductToCustomer(reader.GetInt32(0)) // might be the issue 
                    });
                }

                return listOfCustomer;

            }
        }
            private List<Product> GiveProductToCustomer(int v) ///need to implement 
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
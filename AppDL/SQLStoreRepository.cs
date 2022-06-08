using Microsoft.Data.SqlClient;
using StoreModel;

namespace AppDL
{

    public class SQLStoreRepository : IRepository<Store>
    {
                //=================== Dependency Injection ==========================
        private string _connectionString;

        public SQLStoreRepository(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }

        //=====================Dependency Injection ========================
        public void Add(Store c_resources)
        {
            throw new NotImplementedException();
        }

        public List<Store> GetAll()
        {
            string SqlQuery = @"select * from Store1";
            List<Store> listofCurrentStore = new List<Store>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listofCurrentStore.Add(new Store(){
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Products = GetProductsFromAstore(reader.GetInt32(0))
                    });
                }
            }
            
            return listofCurrentStore;
        }

        private List<Product> GetProductsFromAstore(int p_sId)
        {
            string SqlQuery = @"select s.sName, p.pName, i.quantity, p.pId from Store1 s
                                inner join Inventory i on s.sID = i.sID
                                inner join Product1 p on p.pId = i.pId
                                 where s.sID = @storeId";
            List<Product> listOfCurrentProduct = new List<Product>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SqlQuery, con);

                command.Parameters.AddWithValue("@storeId", p_sId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfCurrentProduct.Add(new Product(){
                        Id = reader.GetInt32(3), 
                        Name = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    });
                }
            }

            return listOfCurrentProduct;
        }
        public Task<List<Store>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Inventory joinTable)
        {
            throw new NotImplementedException();
        }

        public void update(Store p_resources)
        {
            throw new NotImplementedException();
        }
    }
}
using StoreModel;

namespace AppDL
{
    /// <summary>
    /// Generic repository that will accommodate for all models in future or existing models
    /// </summary>
    /// <typeparam name="T">The T is the placeholder in where you will put the model in </typeparam>
    public interface IRepository<T>
    {
        //CRUD operation
        //create, read, update, and delete 

        /// <summary>
        /// This will create a resource to the database 
        /// </summary>
        /// <param name="c_resources">This is the resource being saved to the database</param>
        void Add(T c_resources);

        // void AddAsyn(T c_resources);

        /// <summary>
        /// This will get all the specific resources from the database
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();
        void Update(Inventory joinTable);

        /// <summary>
        /// This gives all the resources asynchronous
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// This will update an existing resources
        /// </summary>
        /// <param name="p_resources">This is the updating resource</param>
        void update(T p_resources);
    }
}
using StoreModel;

namespace AppBL
{
    public interface IStoreBL
    {
        /// <summary>
        /// Will display the lists of products from a store
        /// </summary>
        /// <param name="p_sId">This is a store it will select</param>
        /// <returns></returns>
        public List<Product> ViewStoreInventory(int p_sId);
    }
}
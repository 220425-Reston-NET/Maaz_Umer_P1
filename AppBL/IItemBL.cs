using StoreModel;

namespace AppBL
{
    public interface IItemBL
    {
        /// <summary>
        /// Will give you all the items from the DB
        /// </summary>
        /// <returns>Returns a list of item objects</returns>
        List<Product> GetAllItem();

        /// <summary>
        /// will find the item in the DB
        /// </summary>
        /// <param name="p_itemName"></param>
        /// <returns></returns>
        Product SearchItemByName(string p_itemName);
    }
}
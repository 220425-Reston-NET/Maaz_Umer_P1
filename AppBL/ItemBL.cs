using AppDL;
using StoreModel;

namespace AppBL
{
    public class ItemBL : IItemBL
    {
        //============Dependency Injection======================= 
        private IRepository<Product> _itemRepo;
        // private IRepository<App> p1_itemRepo;
        public ItemBL(IRepository<Product> p_itemRepo)
        {
            _itemRepo = p_itemRepo;
            // p1_itemRepo = p2_itemRepo;
        }
        //======================================================
        public List<Product> GetAllItem()
        {
            return _itemRepo.GetAll();
        }

        public Product SearchItemByName(string p_itemName)
        {
            List<Product> currentListofItem = _itemRepo.GetAll();

            foreach (var itemObj in currentListofItem)
            {
                if (itemObj.Name == p_itemName)
                {
                    return itemObj;
                }
            }
            //Will return null if no item was found
            return null;
        }
    }
}
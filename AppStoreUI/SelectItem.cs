using AppBL;
using StoreModel;

namespace AppStoreUI
{
    public class SelectItem : IMenu
    {
        //===============Dependency Injection================
        private IItemBL _itemBL;
        private IAppBL _appBL;
        private ItemBL itemBL;

        public SelectItem(ItemBL itemBL)
        {
            this.itemBL = itemBL;
        }

        public SelectItem(IItemBL p_itemBL, IAppBL p_appBL)
        {
            _itemBL = p_itemBL;
        }
        //===================================================
        public void Display()
        {
            //This will display all items in the database
            List<Product> listofItem = _itemBL.GetAllItem();
            foreach (Product itemObj in listofItem)
            {
                Console.WriteLine(itemObj.Name);
            }
        }

        public string YourChoice()
        {

            Console.WriteLine("Choose the Item from name listed above");
            string userInput = Console.ReadLine();

            //Logic to select 
            Product foundedItem = _itemBL.SearchItemByName(userInput);

            if (foundedItem != null)
            {
               // SearchApp.foundedCustomer.Addresses.Add(foundedItem);
                _appBL.AddListToCustomer(SearchApp.foundedCustomer); 
                Console.WriteLine("Successfully added Item!");
            }
            else
            {
                Console.WriteLine("Item was unable to found!");
                Console.ReadLine();
                return "SelectItem";
            }

            Console.ReadLine();
            return "MainMenu";

        }
    }
}
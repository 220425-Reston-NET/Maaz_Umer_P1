namespace StoreModel
{
    public class Inventory
    {
        public int storeID { get; set; }
        public int pId { get; set; }
        public int quantity { get; set; }
        public int InventoryID { get; set; }

        public override string ToString()
        {
            return $"=======\nID: {storeID}\nID: {pId}\nQuantity: {quantity}\nID: {InventoryID}\n=======";
        }

        //Stephen.pagdilao@revature.com
    }
}
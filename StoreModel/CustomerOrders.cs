namespace StoreModel
{
    public class CustomerOrders
    {
        public int orderID { get; set; }
        public string? pId { get; set; }
        public int quantity { get; set; }

        public override string ToString()
        {
            return $"=======\nID: {orderID}\nID: {pId}\nquantity: {quantity}\n=======";
        }
    }
}
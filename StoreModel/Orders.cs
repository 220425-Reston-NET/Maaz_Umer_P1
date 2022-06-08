using System.ComponentModel.DataAnnotations;

namespace StoreModel
{
    public class Orders
    {

        public int _oId;
        public int orderID
        {
            get { return _oId; }
            set
            {
                if (value > 0)
                {
                    _oId = value;
                }
                else
                {
                    throw new ValidationException("orderID cannot be negative");
                }
            }
        }
        public string? storeLocations { get; set; }


        public int cTotal { get; set; }

        public int customerID { get; set; }

        public override string ToString()
        {
            return $"=======\nID: {orderID}\nstoreLocations: {storeLocations}\ntotalPrice: {cTotal}\ncustomerID: {customerID}=======";
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace StoreModel
{
    public class Customer
    {
        //This is a field
        private int _customerId;

        //This is a property
        //I want Store Id to hold positive numbers
        public int CustomerID
        {
            get { return _customerId; }
            set 
            {
                if (value > 0)
                {
                 _customerId = value; 
                }
                else 
                {
                    //We will replace this line later on once we learn exception
                    throw new ValidationException("CustomerNum needs to be above 0.");
                }
            }
        }
        
        public string Name { get; set; }
       // public string Item { get; set; }   
        //public int Price { get; set; }
        //public List<Product> Addresses { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

        //Everytime you make a new model, make sure you create a constructor 
        //This constructor will be responsible to instantiating other objects as well as setting default values for other properties 
        // public Customer()
        //  {
        //      CustomerNumber = 1;
        //      Name = "David";
        //      Item = "iPhone";
        //      Address = "31 Blvd street";
        //      Addresses = new List<Product>();
        //  }

         public override string ToString()
        {
            return $"===Customer Info===\nName: {Name}\nAddress: {Address}\nPhoneNumber: {PhoneNumber}\n========================";
        }
    }

}

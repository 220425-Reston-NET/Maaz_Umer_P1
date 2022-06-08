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
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

         public override string ToString()
        {
            return $"===Customer Info===\nName: {Name}\nAddress: {Address}\nPhoneNumber: {PhoneNumber}\n========================";
        }
    }

}

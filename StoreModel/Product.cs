namespace StoreModel
{
    public class Product 
    {
        public string Name { get; set; } 
        private int _price; //can only use certain amount of time & can not be negative 
        public int Price
        
        {
            get { return _price; }
            set 
            {
                if (value > 0)
                {
                    _price = value; 
                }
                else
                {
                    Console.WriteLine("Price can not be in negative! (value > 0)");
                }
                
            }
        }
    }
}
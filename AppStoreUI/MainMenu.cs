using StoreModel;

namespace AppStoreUI
{
    /// <summary>
    /// Display MainMenu in Application
    /// </summary>
    public class MainMenu : IMenu
    {

        //This method will display things in your terminal that will show what users can do

        public void Display()
        {
            Console.WriteLine("========Welcome to Online Shopping========");
            Console.WriteLine("========What can I do for you========");
            Console.WriteLine("[2] - Add a new Customer");
            Console.WriteLine("[1] - Search Customer");
            Console.WriteLine("[0] - Exit");
        }

        public string YourChoice()
        {
            {
                string userInput = Console.ReadLine();

                if (userInput == "2")
                {
                    return "AddCustomer";
                }
                else if (userInput == "1")
                {
                    return "SearchCustomer";
                }
                else if (userInput == "0")
                {
                    return "Exit";
                }
                else
                {
                    Console.WriteLine("Please put a valid response");
                    return "MainMenu";
                }

            }
        }
    }
}
        //This method will ask user what to do

//         public string YourChoice()
//         {
//             {
//                 string c_Input = Console.ReadLine();

//                 if (c_Input == "1")
//                 {
//                     //Logic to add customer
//                     Console.Clear();
//                     App appobj = new App();
//                     Console.WriteLine("What is the name of the customer?");
//                     appobj.Name = Console.ReadLine();
//                     Console.WriteLine("What is the customer address?");
//                     appobj.Address = Console.ReadLine();
//                     Console.WriteLine("What is the Customer Phone Number?");
//                     appobj.CustomerNumber = Convert.ToInt32(Console.ReadLine());
//                     Repository.AddAppInformation(appobj);
//                     return "AddCustomer";
//                 }
//                 else if (c_Input == "0")
//                 {
//                     //Logic to exit
//                     return "Checkout";
//                 }
//                 else
//                 {
//                     Console.WriteLine("Please put a valid response");
//                     return "MainMenu";
//                 }
//             }
//         }
//     }
// }

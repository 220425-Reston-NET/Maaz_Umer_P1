using AppBL;
using StoreModel;
using System.Text.Json;

public class SearchApp : IMenu
{
    public static Customer foundedCustomer; 
    //Dependancy Injection for Business Layer class
    private IAppBL _appBL;

    // public SearchApp()
    // {
    // }

    public SearchApp(IAppBL a_appBL)
    {
        _appBL = a_appBL;
    }
    //======================================
    public void Display()
    {
        Console.WriteLine("How would you like to search your customer?");
        Console.WriteLine("[3] - Search by Customer phone number");
        Console.WriteLine("[2] - Search by Name");
        Console.WriteLine("[1] - search by Address");
        Console.WriteLine("[0] - Exit");
    }

    public string YourChoice()
    {
                string userInput = Console.ReadLine();

                if (userInput == "3")
                {
                    //Search Logic by customer number
                    return "Mainmenu";
                }
                    else if (userInput == "2")
                {
                    //Search logic by name
                    Console.WriteLine("Enter a customer name: ");
                    string CustomerName = Console.ReadLine();

                    foundedCustomer = _appBL.SearchCustomerByName(CustomerName); 

                    //Condition that it should only display the customer info if it found a customer
                    if (foundedCustomer == null)
                    {
                        Console.WriteLine("Customer was not found");
                    }
                    else
                {
                    // Console.WriteLine("=======Customer info=======");
                    // Console.WriteLine("Name: " + foundedCustomer.Name);
                    // Console.WriteLine("Address: " + foundedCustomer.Address);
                    // Console.WriteLine("Customer ID: " + foundedCustomer.CustomerID);
                    // Console.WriteLine("===============");   
                    Console.WriteLine(foundedCustomer);                          
                    //Ask user if they want to add an address to this customer
                    Console.WriteLine("Do you want to add an Item? (Y - Yes, N - No  )");
                    string addCustomerChoice = Console.ReadLine(); 
                    if (addCustomerChoice == "Y");
                    // {
                    //     Address product = new Address();
                    //     Console.WriteLine("What is the product name?");
                    //     product.Name = Console.ReadLine();
                    //     Console.WriteLine("What is the product price?");
                    //     product.Price = Convert.ToInt32(Console.ReadLine());

                    //      string path = "\\Users\\alium\\Documents\\Revature\\App\\AppDL\\Data";
                    //     string json = File.ReadAllText(path + "\\App.json");
                    //      // string myJson = JsonSerializer.Deserialize(json);
                    //      if(null != json) {
                    //     List<App> myJson = JsonSerializer.Deserialize<List<App>>(json);
                    //     // myJson.Add(appObj);
                    //     App result = myJson.Find(x => x.Name == foundedCustomer.Name);
                    //     result.Item = product.Name; 
                    //     result.Price = product.Price;
                    //     myJson[myJson.FindIndex(x => x.Name == foundedCustomer.Name)] = result;
                    //     string newJson =  JsonSerializer.Serialize(myJson);
                    //     File.WriteAllText(path + "\\App.json", newJson);
                    //     }               
                    // }
                    else
                    {
                        return "SearchCustomer";
                    }             

                }
                Console.ReadLine();
                return "SearchCustomer";


                }
                else if (userInput == "1")
                {
                    return "Mainmenu";
                }
                else if (userInput == "0")
                {
                    //Exit
                    return "Mainmenu";
                }
                else 
                {
                    Console.WriteLine("Please enter a valid response");
                    return "SearchCustomer";
                }
    }
}
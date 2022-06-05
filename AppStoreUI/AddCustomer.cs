using AppBL;
using StoreModel;
using System.Text.Json;


public class AddCustomer1 : IMenu
{
    private Customer appObj = new Customer();

    //========= Dependency injection Pattern =========
    private IAppBL _appBL;
    public AddCustomer1(IAppBL a_appBL)
    {
        _appBL = a_appBL;
    }
    //================================================

    public void Display()
    {
        // Customer appObj = new Customer();
        Console.WriteLine("Please enter the Customer details by following the questions.");
        Console.WriteLine("What is the customer name?");
        appObj.Name = Console.ReadLine();
        Console.WriteLine("What is the customer address?");
        appObj.Address = Console.ReadLine();
        Console.WriteLine("What is the customer phone number?");
        try
        {
            appObj.PhoneNumber = Convert.ToInt32(Console.ReadLine());
        }
        catch (System.Exception)
        {
            Console.WriteLine("Customer number cannot be negative!");
            appObj.PhoneNumber = 1;
        }

        // string path = "\\Users\\alium\\Documents\\Revature\\App\\AppDL\\Data";
        // string json = File.ReadAllText(path + "\\App.json");
        // // string myJson = JsonSerializer.Deserialize(json);
        // if(null != json) {
        //     List<Customer> myJson = JsonSerializer.Deserialize<List<Customer>>(json);
        //     myJson.Add(appObj);
        //     string newJson =  JsonSerializer.Serialize(myJson);
        //     File.WriteAllText(path + "\\App.json", newJson);
        // }
        Console.WriteLine("[1] - Add a Customer");
        Console.WriteLine("[0] - Exit");
    }

    public string YourChoice()
    {
        String userInput = Console.ReadLine();

        if (userInput == "1")
        {
            //Repository.AddCustomer(appObj);
            try
            {
                _appBL.AddCustomer(appObj);
                Console.WriteLine("Customer successfully added!");
                Console.ReadLine();
            }
            catch (System.AccessViolationException)
            {
                Console.WriteLine("Customer name is already exist");
                Console.ReadLine();
            }
            return "Mainmenu";
        }
        else if (userInput == "0")
        {
            return "Exit";
        }
        else
        {
            Console.WriteLine("Please enter a correct response");
            Console.ReadLine();
            return "AddCustomer";
        }

    }
}
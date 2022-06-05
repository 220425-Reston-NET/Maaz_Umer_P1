using AppBL;
using AppDL;
using AppStoreUI;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder() //Builder class used to create my configuration object
        .SetBasePath(Directory.GetCurrentDirectory()) //Sets the base path to the current directory
        .AddJsonFile("appsettings.json") //Grabs the specific json file on where the information is from
        .Build(); //Creates the object

// Console.WriteLine("Hello, World!");

// //Create an object
// App storeObj = new App();
// storeObj.StoreID = 100;
// Console.WriteLine(storeObj.StoreID);
// storeObj.StoreID = 0;
// Console.WriteLine(storeObj.StoreID);

// //Adding description to obj
// Description des1 = new Description();
// des1.Name = "Dairy";
// Description des2 = new Description();
// des2.Name = "Fruites";

// storeObj.Descriptions = new List<Description>();

// storeObj.Descriptions.Add(des1);
// storeObj.Descriptions.Add(des2);

// //Display everything that description 

// foreach (Description item in storeObj.Descriptions)
// {
//     Console.WriteLine(item.Name);
// }

Console.Clear();

//Creating MainMenu obj 
IMenu menu = new MainMenu();
bool repeat = true;

while (repeat)
{
    Console.Clear();
    menu.Display();
    string ans = menu.YourChoice();

    if (ans == "MainMenu")
    {
        menu = new MainMenu();
    }
    else if (ans == "AddCustomer")
    {
        // Need to add Customer BL objects inside of the parameter
        menu = new AddCustomer1(new CustomerBL(new SQLCustomerRepository(configuration.GetConnectionString("Maaz Umer Store"))));
    }
    else if (ans == "SearchCustomer")
    {
        menu = new SearchApp(new CustomerBL(new SQLCustomerRepository(configuration.GetConnectionString("Maaz Umer Store"))));
    }
    else if (ans == "SelectItem")
    {
        menu = new SelectItem(new ItemBL(new AddressRepository()));
    }
    else if (ans == "Exit")
    {
        repeat = false;
    }
}

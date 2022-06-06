global using Serilog;
using AppBL;
using AppDL;
using AppStoreUI;
using Microsoft.Extensions.Configuration;


//Initializing my logger
Log.Logger = new LoggerConfiguration() //LoggerConfiguration used to configure your logger and create it
    .WriteTo.File("./logs/user.txt") //Configuring the logger to save information to a file called user.txt inside of logs folder
    .CreateLogger(); //A method to create the logger

//Initializing my configuration object
var configuration = new ConfigurationBuilder() //Builder class used to create my configuration object
        .SetBasePath(Directory.GetCurrentDirectory()) //Sets the base path to the current directory
        .AddJsonFile("appsettings.json") //Grabs the specific json file on where the information is from
        .Build(); //Creates the object

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
        Log.Information("User going to Main Menu");
        menu = new MainMenu();
    }
    else if (ans == "AddCustomer")
    {
        // Need to add Customer BL objects inside of the parameter
        Log.Information("User going to AddCustomer Menu");
        menu = new AddCustomer1(new CustomerBL(new SQLCustomerRepository(configuration.GetConnectionString("Maaz Umer Store"))));
    }
    else if (ans == "SearchCustomer")
    {   
        Log.Information("User going to Search Menu");
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

using AppBL;
using AppDL;
using Serilog;
using StoreModel;

var builder = WebApplication.CreateBuilder(args);

//Initializing my logger
    Log.Logger = new LoggerConfiguration() //LoggerConfiguration used to configure your logger and create it
    .WriteTo.File("./logs/user.txt") //Configuring the logger to save information to a file called user.txt inside of logs folder
    .CreateLogger(); //A method to create the logger

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Configuration.GetConnectionString("Maaz Umer Store") >> for swagger
//Environment.GetEnvironmentVariable("Connection_String") >> for aws 

builder.Services.AddScoped<IRepository<Customer>, SQLCustomerRepository>(repo => new SQLCustomerRepository(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<IAppBL, CustomerBL>();
builder.Services.AddScoped<IRepository<Store>, SQLStoreRepository>(repo => new SQLStoreRepository(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<IStoreBL, StoreBL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//Added comment
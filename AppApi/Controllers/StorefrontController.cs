using AppBL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Serilog;
using StoreModel;


namespace StoreModel.Controllers;

[ApiController]
[Route("api/[controller]")] //added api
public class StorefrontController : ControllerBase
{
    private IStoreBL _storeBL;
    public StorefrontController(IStoreBL p_storeBL)
    {
        _storeBL = p_storeBL;
    }
    
    [HttpGet("ViewStoreInventory")]
    public IActionResult ViewStoreInventory([FromQuery] int p_sId)
    {
        Log.Information("User going to ViewStoreInventory");
        return Ok(_storeBL.ViewStoreInventory(p_sId));
    }
}
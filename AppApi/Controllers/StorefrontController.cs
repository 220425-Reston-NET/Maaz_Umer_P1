using AppBL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Serilog;
using StoreModel;


namespace StoreModel.Controllers;

[ApiController]
[Route("[controller]")]
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
        return Ok(_storeBL.ViewStoreInventory(p_sId));
    }
}
//     // =============Dependency injection==========
//     private IStorefrontBL _storefrontBL;
//     private IinventoryBL _inventoryJoin;
//     private OrderslistBL _orderlist;
//     public StorefrontController(IStorefrontBL storefrontBL, IinventoryBL inventoryJoin, OrderslistBL orderlist)
//     {
//         _storefrontBL = storefrontBL;
//         _inventoryJoin = inventoryJoin;
//          _orderlist = orderlist;
//     }
//     // ===========================================

//     [HttpGet("GetAllStores")]
//     public async Task<IActionResult> GetAllStores()
//     {
//         try
//         {
//             Log.Warning("Getting all stores!");
//             List<Storefront> listofCurrentStore = await _storefrontBL.GetAllStoreAsync();
//             return Ok(listofCurrentStore);
//         }
//         catch (SqlException)
//         {
//             Log.Warning("Stores not found!");
//             return NotFound("No Store was found or exists.");
//         }
//     }
//     [HttpGet("SearchStoreByName")]
//     public IActionResult SearchStoreByName([FromQuery] string StoreName)
//     {
//         try
//         {
//             Log.Warning("searching for store by name");
//             return Ok(_storefrontBL.SearchStoreByName(StoreName));
//         }
//         catch (SqlException)
//         {
//             Log.Warning("An error response was returned");
//             return Conflict();
//         }

//     }

//     [HttpGet("SearchStoreByID")]
//     public IActionResult SearchStoreByID([FromQuery] int storeID)
//     {
//         try
//         {
//             Log.Warning("Searching for store by id!");
//             return Ok(_storefrontBL.SearchStoreById(storeID));
//         }
//         catch (SqlException)
//         {
//             Log.Warning("Sql exception returened");
//             return Conflict();
//         }

//     }
    
//     [HttpPut("ReplenishQuantity")]
//     public IActionResult ReplenishQuantity([FromBody]Inventory p_inventory )
//     {
//         Storefront found = _storefrontBL.SearchStoreById(p_inventory.storeID);

//         if (found == null)
//         {
//             Log.Warning("store not found!");
//             return NotFound("Store was not found!");
//         }
        
//         else
//         {
//             try
//             {
//                 Log.Warning("Replenishing Inventory quantiy!");
//                 _inventoryJoin.ReplenishInventoryQuantity(p_inventory.pId, p_inventory.storeID, p_inventory.quantity, p_inventory.InventoryID);

//                 return Ok();
//             }
//             catch (SqlException)
//             {
//                 Log.Warning("SQL exception returned");
//                 return Conflict();
//             }
//         }
//     }

//     [HttpGet("GetAllInventory")]
//     public IActionResult GetAllInventory()
//     {
//         try
//         {
//             Log.Warning("Getting all inventory");
//             List<Inventory> listofCurrentInventory = _inventoryJoin.GetAllInventory();
//             return Ok(listofCurrentInventory);
//         }
//         catch (SqlException)
//         {
//             Log.Warning("no inventory found");
//             return NotFound("No inventory found.");
//         }
//     }
//     [HttpGet("GetAllOrders")]
//     public IActionResult GetAllOrders()
//     {
//         try
//         {
//             Log.Warning("Getting all orders");
//             List<CustomerOrders> listofCurrentOrders = _orderlist.GetAllCustomerOrders();
//             return Ok(listofCurrentOrders);
//         }
//         catch (SqlException)
//         {
//             Log.Warning("no orders to return!");
//             return NotFound("No customer orders were found.");
//         }
//     }
//     [HttpPost("AddProductsToOrders")]
//     public IActionResult AddProductsToOrders([FromBody] Orders o_orders)
//     {
//         try
//         {
//              Log.Warning("Adding product to orders");
//             _orderlist.AddProductsToOrders(o_orders);
//             return Created("Producted was added!", o_orders);
//         }
//         catch (SqlException)
//         {
//             Log.Warning("SQL exception returned");
//             return Conflict();
//         }

//     }
   
// }
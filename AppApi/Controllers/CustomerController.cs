using Microsoft.AspNetCore.Mvc;
using AppBL;
using StoreModel;
using Microsoft.Data.SqlClient;
using Serilog;

namespace AppApi.Controllers
{
    [Route("api/Controller")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        //==================Dependency Injection====================
        private IAppBL _custBL;
        public CustomerController(IAppBL p_custBL)
        {
            _custBL = p_custBL;
        }
        //==========================================================

        //Data annotation to indicate what type of HTTP verb it is 
        //This is an action of a controller
        //It needs what HTTP verb it is associated with 
        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            try
            {
                Log.Information("User going to GetAllCustomer");
                List<Customer> listOfCurrentCustomer = await _custBL.GetAllCustomerAsync();
                return Ok(listOfCurrentCustomer);
            }
            catch (SqlException)
            {
                Log.Information("No customer Exsit");
                return NotFound("No Customer Exist");
            }
        }

        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer([FromBody] Customer p_cust)
        {
            try
            {
                Log.Information("User going to Added Customer");
                _custBL.AddCustomer(p_cust);

                return Created("Customer was created", p_cust);
            }
            catch (SqlException)
            {
                Log.Information("Customer was not added");
                return Conflict();
            }
        }

        [HttpGet("SearchCustomerByName")]
        public IActionResult SearchCustomer([FromQuery] string custName)
        {
            try
            {
                Log.Information("User going to SearchCustomer");
                return Ok(_custBL.SearchCustomerByName(custName));
            }
            catch (SqlException)
            {
                Log.Information("No customer was found!");
                return Conflict();
            }
        }
    }
}
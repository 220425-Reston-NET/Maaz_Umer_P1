using Microsoft.AspNetCore.Mvc;
using AppBL;
using StoreModel;
using Microsoft.Data.SqlClient;

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
            List<Customer> listOfCurrentCustomer = await _custBL.GetAllCustomerAsync();
            return Ok(listOfCurrentCustomer); 
            }
            catch (SqlException)
            {
                return NotFound("No Customer Exist");
            }
        }

        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer([FromQuery] Customer p_cust)
        {
            try
            {
                _custBL.AddCustomer(p_cust);

                return Created("Customer was created" ,p_cust);
            }
            catch (SqlException)
            {
                return Conflict();   
            }
        }

        [HttpGet("SearchCustomerByName")]
        public IActionResult SearchCustomer([FromQuery] string custName)
        {
            try
            {
                return Ok(_custBL.SearchCustomerByName(custName));
            }
            catch (SqlException)
            {
                return Conflict();
            }
        }
    }
}
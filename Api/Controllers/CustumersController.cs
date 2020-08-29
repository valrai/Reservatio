using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservatio.Data.Dto;
using Reservatio.Services.Business.Customer;

namespace Reservatio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// List all registered customers.
        /// </summary>
        /// <returns>Customers list</returns>
        /// <response code="200">Customers found successfully</response>
        /// <response code="204">No customers were found.</response>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<NaturalPersonDto>>> GetCustomers()
        {
            return Ok(await _customerService.Find());
        }

        /// <summary>
        /// Get the costumer by the given identifier.
        /// </summary>
        /// <param name="id">Unique costumer identifier.</param   >
        /// <returns>Customer</returns>
        /// <response code="200">Customer founded.</response>
        /// <response code="204">No customers were found.</response>
        /// <response code="400">Invalid identifier</response>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<NaturalPersonDto>> GetCustomer([FromRoute] long id)
        {
            return Ok(await _customerService.Find(c => c.Id == id));
        }

        /// <summary>
        /// Edit the data of a Customer. 
        /// </summary>
        /// <param name="customer">Customer data to be updated</param>
        /// <returns>Customer</returns>
        /// <response code="200">Data updated successfully.</response>
        /// <response code="400">The informed customer was not found.</response>
        /// <response code="409">The customer informed violate some restriction.</response>

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PutCustomer([FromBody] NaturalPersonDto customer)
        {
            return Ok(await _customerService.Edit(customer));
        }

        /// <summary>
        /// Add a new customer.
        /// </summary>
        /// <param name="customer">Customer to be added.</param>
        /// <returns>The new customer added.</returns>
        /// <response code="201">Customer successfully registered.</response>
        /// <response code="409">The customer informed violate some restriction.</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<NaturalPersonDto>> PostCustomer([FromBody] NaturalPersonDto customer)
        {
            customer.Id = await _customerService.Register(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        /// <summary>
        /// Remove a customer. 
        /// </summary>
        /// <param name="id">Unique costumer identifier.</param   >
        /// <response code="400">The customer to be removed was not found.</response>
        /// <response code="204">Customer successfully removed.</response>

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteCustomer([FromRoute] long id)
        {
            await _customerService.Delete(id);
            return NoContent();
        }
    }
}

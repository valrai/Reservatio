using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservatio.Data.Dto;
using Reservatio.Models;
using Reservatio.Models.Attributes;
using Reservatio.Services.Business.Customer;
using Reservatio.Services.User;

namespace Reservatio.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;

        public CustomersController(ICustomerService customerService, IUserService userService)
        {
            _customerService = customerService;
            _userService = userService;
        }

        /// <summary>
        /// List all registered customers.
        /// </summary>
        /// <returns>Customers list</returns>
        /// <response code="200">Customers found successfully</response>
        /// <response code="204">No customers were found.</response>
        /// <response code="401">User not Authenticated.</response>
        /// <response code="403">User not Authorized.</response>

        [HttpGet]
        [RolesRequirement(RoleType.Administrator)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<NaturalPersonDto>>> GetCustomers()
        {
            return Ok(await _customerService.List());
        }

        /// <summary>
        /// Get the costumer by the given identifier.
        /// </summary>
        /// <param name="id">Unique costumer identifier.</param   >
        /// <returns>Customer</returns>
        /// <response code="200">Customer founded.</response>
        /// <response code="204">No customers were found.</response>
        /// <response code="400">Invalid identifier</response>
        /// <response code="401">User not Authenticated.</response>
        /// <response code="403">User not Authorized.</response>
        
        [HttpGet("{id}")]
        [RolesRequirement(RoleType.Administrator, RoleType.ServiceProvider)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        /// <response code="401">User not Authenticated.</response>
        /// <response code="403">User not Authorized.</response>
        
        [HttpPut]
        [RolesRequirement(RoleType.Administrator, RoleType.ServiceProvider)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutCustomer([FromBody] AddOrupdateNaturalPersonDto customer)
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
        /// <response code="403">User not Authorized.</response>
        
        [HttpPost]
        [RolesRequirement(RoleType.Administrator, RoleType.ServiceProvider)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<NaturalPersonDto>> PostCustomer([FromBody] AddOrupdateNaturalPersonDto customer)
        {
            if (string.IsNullOrEmpty(customer.UserId))
                customer.UserId = await _userService.RegisterUserAsync(customer, RoleType.Customer);

            try
            {
                var customerId = await _customerService.Register(customer);
                return CreatedAtAction(nameof(GetCustomer), new { id = customerId }, customer);
            }
            catch
            {
                await _userService.DeleteUserAsync(customer.UserId);
                throw;
            }
        }

        /// <summary>
        /// Remove a customer. 
        /// </summary>
        /// <param name="id">Unique costumer identifier.</param   >
        /// <response code="400">The customer to be removed was not found.</response>
        /// <response code="204">Customer successfully removed.</response>
        /// <response code="401">User not Authenticated.</response>
        /// <response code="403">User not Authorized.</response>
        
        [HttpDelete("{id}")]
        [RolesRequirement(RoleType.Administrator)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteCustomer([FromRoute] long id)
        {
            await _customerService.Delete(id);
            return NoContent();
        }

        /// <summary>
        /// Cancel a customer. 
        /// </summary>
        /// <param name="id">Unique costumer identifier.</param   >
        /// <response code="400">The customer to be canceled was not found.</response>
        /// <response code="204">Customer successfully canceled.</response>
        /// <response code="401">User not Authenticated.</response>
        /// <response code="403">User not Authorized.</response>
        
        [HttpPut("{id}/Cancellation")]
        [RolesRequirement(RoleType.Administrator, RoleType.ServiceProvider)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> CancelCustomer([FromRoute] long id)
        {
            await _customerService.CancelCustomer(id);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using beeTechSolutions_API_.Data;
using beeTechSolutions_API_.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace beeTechSolutions_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DBContext context;

        public CustomersController(DBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = context.Customers.ToList();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = context.Customers.SingleOrDefault(p => p.customer_id == id);

            if (customer == null) 
            { 
                return NotFound("Customer Not found");
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customers>> CreateCustomer(Customers customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();

            customer = new Customers();

            return CreatedAtAction(nameof(GetCustomer), new {id = customer.customer_id}, customer);
        }

        [HttpPut("{id}")]
        public IActionResult updateCustomer(int id)
        {
            var customer = context.Customers.FirstOrDefault(p => p.customer_id==id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.firstName = customer.firstName;
            customer.lastName = customer.lastName;
            customer.email = customer.email;
            customer.phoneNumber = customer.phoneNumber;
            customer.passcode = customer.passcode;

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteCustomer(int id)
        {
            var customer = await context.Customers.FindAsync(id);

            if(customer == null)
            {
                return NotFound();
            }

            context.Customers.Remove(customer);

            await context.SaveChangesAsync();   

            return NoContent();
        }
    }
}

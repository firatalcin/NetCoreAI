using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAI.Project01_ApiDemo.Context;
using NetCoreAI.Project01_ApiDemo.Entities;

namespace NetCoreAI.Project01_ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomersController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult CustomerList()
        {
            var value = _applicationDbContext.Customers.ToList();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            _applicationDbContext.Customers.Add(customer);
            _applicationDbContext.SaveChanges();
            return Ok("Müşteri Eklenmiştir.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var value = _applicationDbContext.Customers.Find(id);
            _applicationDbContext.Customers.Remove(value);
            _applicationDbContext.SaveChanges();
            return Ok("Müşteri silinmiştir.");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _applicationDbContext.Customers.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var value = _applicationDbContext.Customers.Find(customer.Id);
            value.Name = customer.Name;
            value.Surname = customer.Surname;
            value.Balance = customer.Balance;
            _applicationDbContext.SaveChanges();
            return Ok("Müşteri Güncellenmiştir.");
        }
    }
}

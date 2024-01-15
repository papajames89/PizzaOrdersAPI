using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using PizzaOrdersAPI.Interfaces;
using PizzaOrdersAPI.Models;

namespace PizzaOrdersAPI.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion(1.0)]
    public class PizzaOrdersController : ControllerBase
    {
        private readonly IPizzaOrderService _pizzaOrderService;
        
        public PizzaOrdersController(IPizzaOrderService pizzaOrderService)
        {
            _pizzaOrderService = pizzaOrderService;
        }

        //GET api/v{apiVersion}/pizzaorders/
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pizzaOrderService.Get());
        }

        //GET api/v{apiVersion}/pizzaorders/{id}
        [HttpGet("{id}")]
        public ActionResult<PizzaOrder> Get(string id)
        {
            return Ok(_pizzaOrderService.Get(id));
        }

        //POST api/v{apiVersion}/pizzaorders/
        [HttpPost]
        public ActionResult Post([FromBody] PizzaOrder pizzaOrder)
        {
            if (_pizzaOrderService.Get(pizzaOrder.Id) != null)
            {
                return Conflict($"Pizza order with id: '{pizzaOrder.Id}' already exists.");
            }
            
            _pizzaOrderService.Create(pizzaOrder);
            return Ok(CreatedAtAction(nameof(Get), new { id = pizzaOrder.Id }, pizzaOrder));
        }
        
        //PUT api/v{apiVersion}/pizzaorders/{id}
        [HttpPut]
        public ActionResult Put(string id, [FromBody] PizzaOrder pizzaOrder)
        {
            var existingPizzaOrder = _pizzaOrderService.Get(id);
            if (existingPizzaOrder == null)
            {
                return NotFound($"Pizza order with Id = '{id}' not found");
            }

            if (id != pizzaOrder.Id)
            {
                return Conflict($"New pizza order id = '{pizzaOrder.Id}' doesn't match existing pizza order.");
            }

            return Ok(_pizzaOrderService.Update(id, pizzaOrder));
        }
        
        //DELETE api/v{apiVersion}/pizzaorders/{id}
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var existingPizzaOrder = _pizzaOrderService.Get(id);
            if (existingPizzaOrder == null)
            {
                return NotFound($"Pizza order with Id = '{id}' not found.");
            }
            
            _pizzaOrderService.Remove(existingPizzaOrder.Id);

            return Ok($"Pizza order with Id = '{id}' deleted.");
        }
    }
}
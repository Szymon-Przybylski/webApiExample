using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;

namespace WebApplication1.Controllers
{
    
    [ApiController]
    [Route("api")]
    public class OrderListController : ControllerBase
    {

        private List<string> _newOrders;

        public OrderListController()
        {
            _newOrders = new List<string>();
        }

        [HttpGet("/orderList/GetOrders")]
        [ProducesResponseType(typeof(OrderList), 200)]

        public OkObjectResult GetOrders()
        {
            
            OrderList orderList = new OrderList
            {
                Orders = _newOrders,
            };

            return Ok(orderList);
        }

        [HttpPost("/orderList/AddOrder/{item}")]
        [ProducesResponseType(typeof(string), 201)]
        public CreatedResult AddOrder(string item)
        {
            
            _newOrders.Add(item);
            
            return Created("uri", item);
        }
    }
}
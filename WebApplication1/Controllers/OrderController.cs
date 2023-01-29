using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {

        private readonly IorderRepository orderRepository;
       private readonly IMapper mapper;
        public OrderController(IorderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrderAsync()
        {
            var order = await orderRepository.GetAllOrderAsync();




             var orderDTO = mapper.Map<List<Models.DTO.Order>>(order);

         //   var itemDTO = mapper.Map<List<Models.DTO.item>>(items);

            return Ok(orderDTO);
        }


        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetOrderAsync")]
        public async Task<IActionResult> GetOrderAsync(Guid id)
        {
            {
                var order = await orderRepository.GetOrdeAsync(id);
                if (order == null)
                {
                    return NotFound();
                }
                var orderDTO = mapper.Map<Models.DTO.item>(order);
                return Ok(orderDTO);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync(Models.DTO.AddOrderRequest addOrderRequest)
        {
            //request to domain model
            var order = new Models.Domain.order()
            {
                userId = addOrderRequest.userId,
                statusId = addOrderRequest.statusId,
                tablenumber = addOrderRequest.tablenumber

            };

            //pass details to repository

            order = await orderRepository.AddAsync(order);
            //Convert back to DTO

            var OrderDTO = new Models.DTO.Order
            {
                orderId=order.orderId,
                userId = order.userId,
                statusId = order.statusId,
                tablenumber = order.tablenumber


            };
            return Ok(OrderDTO);

            //return CreatedAtAction(nameof(GetItemAsync), new { itemId = itemDTO.itemId }, itemDTO);
        }

    }
}

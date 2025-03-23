using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using API.Models.Order;
using API.Models.OrderItem;
using Services.Intefraces;
using Services.Models.Order;
using Services.Models.OrderItem;
using Shared;

namespace OpenSpace.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        private readonly IOrderItemService _orderItemService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public OrderController(IOrderServices orderServices, IOrderItemService orderItemService, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _orderServices = orderServices;
            _orderItemService = orderItemService;
            _userManager = userManager;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateOrders(Guid id, [FromBody] CreateOrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = _mapper.Map<OrderDto>(dto);
            order.CustomerId = id;
            var result = await _orderServices.CreateAsync(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = result.Id }, result);
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> GetAllOrders(Guid? customerId, OrderStatus? status)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            bool isManager = await _userManager.IsInRoleAsync(user, "Manager");

            var orders = await _orderServices.GetAllOrdersAsync(
           isManager ? (Guid?)null : user.CustomerId, status);
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var customer = await _orderServices.GetOrderByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] UpdateOrderDto order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }
            await _orderServices.UpdateOrderAsync(id, _mapper.Map<UpdateOrder>(order));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await _orderServices.DeleteOrderAsync(id);
            return NoContent();
        }

        [HttpPost("{orderId}/confirm")]
        public async Task<IActionResult> ConfirmOrder(Guid orderId, [FromBody] UpdateOrder dto)
        {
            if (orderId != dto.Id)
                return BadRequest("Order ID mismatch.");

            if (dto.Status != Shared.OrderStatus.InProgress && dto.Status != Shared.OrderStatus.Completed)
            {
                return BadRequest("Недопустимый статус");
            }

            await _orderServices.UpdateOrderAsync(orderId, dto);

            return Ok(dto);
        }

        [HttpPost("{orderId}/items")]
        public async Task<IActionResult> AddOrderItem(Guid orderId, [FromBody] CreateOrderItemDto dto)
        {
            dto.OrderId = orderId;
            var order = await _orderServices.GetOrderByIdAsync(orderId);

            if (order == null)
                return NotFound($"Order {orderId} not found");

            var createdItem = await _orderItemService.CreateAsync(_mapper.Map<OrderItemDto>(dto));

            return CreatedAtAction(
                nameof(GetOrderItemById),
                new { orderId = orderId, orderItemId = createdItem.Id },
                createdItem
            );
        }

        [HttpGet("{orderId}/items/{orderItemId}")]
        public async Task<IActionResult> GetOrderItemById(Guid orderId, Guid orderItemId)
        {
            var orderItem = await _orderItemService.GetByIdAsync(orderItemId);

            if (orderItem == null || orderItem.OrderId != orderId)
                return NotFound();

            return Ok(orderItem);
        }

        [HttpPut("{orderId}/items/{orderItemId}")]
        public async Task<IActionResult> UpdateOrderItem(Guid orderId, Guid orderItemId, [FromBody] UpdateOrderItemDto updateOrderItemDto)
        {
            await _orderItemService.UpdateAsync(_mapper.Map<UpdateOrderItem>(updateOrderItemDto));

            return NoContent();
        }

        [HttpDelete("{orderId}/items/{orderItemId}")]
        public async Task<IActionResult> DeleteOrderItem(Guid orderId, Guid orderItemId)
        {
            var existingItem = await _orderItemService.GetByIdAsync(orderItemId);
            if (existingItem == null || existingItem.OrderId != orderId)
                return NotFound();

            await _orderItemService.DeleteAsync(orderItemId);


            return NoContent();
        }
    }
}

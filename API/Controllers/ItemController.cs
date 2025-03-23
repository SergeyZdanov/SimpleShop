using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Models.Item;
using Services.Intefraces;
using Services.Models.Item;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemServices _itemServices;
        private readonly IMapper _mapper;

        public ItemController(IItemServices itemServices, IMapper mapper)
        {
            _itemServices = itemServices;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> CreateItem([FromBody] CreateItemDto dto)
        {
            var createdItem = await _itemServices.CreateAsync(_mapper.Map<ItemDto>(dto));
            return CreatedAtAction(nameof(GetItemById), new { id = createdItem.Id }, createdItem);
        }

        [HttpGet("{id}")]
         /*[Authorize(Roles = "Manager")]*/
        public async Task<ActionResult<ItemResponseDto>> GetItemById(Guid id)
        {
            var item = await _itemServices.GetByIdAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _itemServices.GetAllByAsync();
            return Ok(items);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> UpdateItem(Guid id, [FromBody] UpdateItemDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dto.Id != id)
                return BadRequest("Mismatch between route ID and DTO ID");

            await _itemServices.UpdateAsync(_mapper.Map<UpdateItem>(dto));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            await _itemServices.DeleteAsync(id);

            return NoContent();
        }
    }
}

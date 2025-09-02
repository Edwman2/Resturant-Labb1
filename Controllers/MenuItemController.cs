using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_Labb1.DTOs.RequestDTOs;
using Resturant_Labb1.DTOs.ResponseDTOs;
using Resturant_Labb1.Services;
using Resturant_Labb1.Services.IServices;

namespace Resturant_Labb1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _itemService;

        public MenuItemController(IMenuItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MenuItemDTO>>> GetAllMenuItemsAsync()
        {
            var item =  await _itemService.GetAllMenuItemsAsync();
            return Ok(item);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItemDTO>> GetMenuItemById(int id)
        {
            var item = await _itemService.GetMenuItemByIdAsync(id);

            if(item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
        [HttpPost]
        public async Task<ActionResult<MenuItemDTO>> CreateMenuItemAsync([FromBody]MenuItemDTO itemDTO)
        {
            var newItem = await _itemService.CreateMenuItemAsync(itemDTO);

            return CreatedAtAction(nameof(GetMenuItemById), new { id = newItem.ItemId }, newItem);
            
            
        }

        [HttpDelete]
        public async Task<ActionResult<MenuItemDTO>> DeleteMenuItemAsync(int id)
        {
            var deletedItem = await _itemService.DeleteMenuItemAsync(id);

            if(deletedItem == null)
            {
                return NotFound();
            }

            return Ok(deletedItem);
        }
        
    }
}

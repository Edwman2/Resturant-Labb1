using Resturant_Labb1.DTOs.RequestDTOs;
using Resturant_Labb1.DTOs.ResponseDTOs;
using Resturant_Labb1.Models;
using Resturant_Labb1.Repositories.IRepository;
using Resturant_Labb1.Services.IServices;

namespace Resturant_Labb1.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuRepository _menuRepo;

        public MenuItemService(IMenuRepository menuRepo)
        {
            _menuRepo = menuRepo;
        }

        public async Task<CreateMenuItemDTO> CreateMenuItemAsync(CreateMenuItemDTO menuDTO)
        {
            var item = new MenuItem
            {
                Name = menuDTO.Name,
                Price = menuDTO.Price,
                Description = menuDTO.Description
            };

            var newItem = await _menuRepo.AddMenuItemsAsync(item);

            return new CreateMenuItemDTO
            {
                Name = newItem.Name,
                Price = newItem.Price,
                Description = newItem.Description
            };
        }

        public async Task<bool> DeleteMenuItemAsync(int id)
        {
            return await _menuRepo.DeleteMenuItemAsync(id);
        }

        public async Task<List<MenuItemDTO>> GetAllMenuItemsAsync()
        {
            var items = await _menuRepo.GetAllMenuItemsAsync();
            var menuItemDTO = items.Select(i => new MenuItemDTO
            {
                ItemId = i.ItemId,
                Name = i.Name,
                Price = i.Price,
                Description = i.Description
            }).ToList();

            return menuItemDTO;
        }

        public async Task<MenuItemDTO> GetMenuItemByIdAsync(int id)
        {
            var items = await _menuRepo.GetMenuItemByIdAsync(id);
            
            if(items == null)
            {
                return null;
            }

            var item = new MenuItemDTO
            {
                ItemId = items.ItemId,
                Name = items.Name,
                Price = items.Price,
                Description = items.Description
            };

            return item;
        }

        public Task<UpdateMenuItemDTO> UpdateItemAsync()
        {
            throw new NotImplementedException();
        }
    }
}

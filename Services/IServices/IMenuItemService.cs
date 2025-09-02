using Resturant_Labb1.DTOs.RequestDTOs;
using Resturant_Labb1.DTOs.ResponseDTOs;
using Resturant_Labb1.Models;

namespace Resturant_Labb1.Services.IServices
{
    public interface IMenuItemService
    {
        Task<List<MenuItemDTO>> GetAllMenuItemsAsync();
        Task<MenuItemDTO> GetMenuItemByIdAsync(int id);
        Task<MenuItemDTO> CreateMenuItemAsync(CreateMenuItemDTO menuDTO);
        Task<bool> UpdateItemAsync(int id, UpdateMenuItemDTO itemDTO);
        Task<bool> DeleteMenuItemAsync(int id);
    }
}

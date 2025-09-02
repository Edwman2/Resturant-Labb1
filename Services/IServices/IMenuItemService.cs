using Resturant_Labb1.DTOs.RequestDTOs;
using Resturant_Labb1.DTOs.ResponseDTOs;
using Resturant_Labb1.Models;

namespace Resturant_Labb1.Services.IServices
{
    public interface IMenuItemService
    {
        Task<List<MenuItemDTO>> GetAllMenuItemsAsync();
        Task<MenuItemDTO> GetMenuItemByIdAsync();
        Task<CreateMenuItemDTO> CreateMenuItemAsync(CreateMenuItemDTO MenuDTO);
        Task<UpdateMenuItemDTO> UpdateItemAsync();
        Task<bool> DeleteMenuItemAsync(int id);
    }
}

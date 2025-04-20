using Resto.Application.DTOs;
using Resto.Domain.Models;


namespace Resto.Application.Common.Interfaces.Repositories
{
  public interface IMenuRepository
    {
        Task<string> AddMenuItemAsync(string name, string description, decimal price, string category);
        Task<string> UpdateMenuItemAsync(string id, string name, string description, decimal price, string category);
        Task<bool> DeleteMenuItemAsync(string id);
        Task<IEnumerable<MenuDto>> GetAllMenuItemsAsync();
        Task<MenuDto> GetMenuItemByIdAsync(string id);
        Task<IEnumerable<MenuDto>> GetMenuItemsByCategoryAsync(string category);
    }
}

using Resto.Application.Common.Pagination;
using Resto.Application.DTOs;
using Resto.Domain.Models;


namespace Resto.Application.Common.Interfaces.Repositories
{
  public interface IMenuRepository
    {
        Task<string> AddMenuItemAsync(MenuItem menuItem);
        Task<string> UpdateMenuItemAsync(MenuItem menuItem);
        Task<string> DeleteMenuItemAsync(MenuItem menuItem);
        Task<PagedResult<MenuItem>> GetAllMenuItemsAsync(int pageNumber, int pageSize);
        Task<MenuItem> GetMenuItemByIdAsync(string id);
        Task<IEnumerable<MenuItem>> GetMenuItemsByCategoryAsync(string category);
    }
}

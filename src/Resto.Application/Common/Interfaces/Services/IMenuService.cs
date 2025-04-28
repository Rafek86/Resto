using Resto.Application.Common.Pagination;
using Resto.Application.DTOs;
using Resto.Application.Features.MenuItems.Commands.AddMenuItem;
using Resto.Application.Features.MenuItems.Commands.DeleteMenuItem;
using Resto.Application.Features.MenuItems.Commands.UpdateMenuItem;
using Resto.Application.Features.MenuItems.Queries.GetAll;
using Resto.Application.Features.MenuItems.Queries.GetByCategory;

namespace Resto.Application.Common.Interfaces.Services
{
  public interface IMenuService 
    {
        Task<AddMenuItemResult> AddMenuItemAsync(AddMenuItemCommand command);
        Task<UpdateMenuItemResult> UpdateMenuItemAsync(UpdateMenuItemcommand command);
        Task<DeleteMenuItemResult> DeleteMenuItemAsync(DeleteMenuItemCommand command);
        Task<PagedResult<GetAllMenuItemsResult>> GetAllMenuItemsAsync(GetAllMenuItemsQuery query);
        //Task<MenuDto> GetMenuItemByIdAsync(string id);
        Task<IEnumerable<GetByCategoryResult>> GetMenuItemsByCategoryAsync(GetByCategoryQuery query);
    }
}

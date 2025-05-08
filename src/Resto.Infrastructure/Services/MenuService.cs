using Resto.Application.Features.MenuItems.Commands.AddMenuItem;
using Resto.Application.Features.MenuItems.Commands.DeleteMenuItem;
using Resto.Application.Features.MenuItems.Commands.UpdateMenuItem;
using Resto.Application.Features.MenuItems.Queries.GetAll;
using Resto.Application.Features.MenuItems.Queries.GetByCategory;

namespace Resto.Application.Services
{
    public class MenuService(IMenuRepository menuRepository) : IMenuService 
    {
        private readonly IMenuRepository _menuRepository = menuRepository;

        public async Task<AddMenuItemResult> AddMenuItemAsync(AddMenuItemCommand command)
        {
            var itemsInSameCategory = await _menuRepository.GetMenuItemsByCategoryAsync(command.Category);

            if (itemsInSameCategory is not null && itemsInSameCategory.Any(x => x.Name == command.Name))
            {
                throw new ConflictException("Menu item already exists in the same category.");
            }

            var menuItem = MenuItem.Create(
                command.Name,
                command.Description,
                command.Price,
                command.Category,
                command.IsAvailable);

            await _menuRepository.AddMenuItemAsync(menuItem);

            return new AddMenuItemResult(menuItem.Id);
        }

        public async Task<DeleteMenuItemResult> DeleteMenuItemAsync(DeleteMenuItemCommand command)
        {
            if (await _menuRepository.GetMenuItemByIdAsync(command.Id) is not {  } menuItem)
            {
                throw new NotFoundException("MenuItem : " ,command.Id);
            }

            menuItem.Delete(); 

            await _menuRepository.DeleteMenuItemAsync(menuItem);

            return new DeleteMenuItemResult(true);
        }
        public async Task<PagedResult<GetAllMenuItemsResult>> GetAllMenuItemsAsync(GetAllMenuItemsQuery query)
        {

            var result = await _menuRepository.GetAllMenuItemsAsync(query.PageNumber, query.PageSize);

            var mappedItems = result.Items.Select(item =>
                new GetAllMenuItemsResult(
                    new MenuDto(
                        item.Name,
                        item.Description,
                        item.Category,
                        item.Price,
                        item.IsAvailable
                    )
                )
            ).ToList();

            return new PagedResult<GetAllMenuItemsResult>
            {
                Items = mappedItems,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize,
                TotalItems = result.TotalItems
            };
        }
        public async Task<IEnumerable<GetByCategoryResult>> GetMenuItemsByCategoryAsync(GetByCategoryQuery query)
        {
            var result = await _menuRepository.GetMenuItemsByCategoryAsync(query.Category);

            var mappedItems = result.Select(x => new GetByCategoryResult(x.Adapt<MenuDto>()));

            return mappedItems;
        }

        public async Task<UpdateMenuItemResult> UpdateMenuItemAsync(UpdateMenuItemcommand command)
        {
            if( await _menuRepository.GetMenuItemByIdAsync(command.Id) is not { } existingItem)
                throw new NotFoundException("MenuItem : ", command.Id);

            existingItem.Update(
                command.Name,
                command.Description,
                command.Price,
                command.Category,
                command.IsAvailable);

            await _menuRepository.UpdateMenuItemAsync(existingItem);

            return new UpdateMenuItemResult(true);
        }
    }
}

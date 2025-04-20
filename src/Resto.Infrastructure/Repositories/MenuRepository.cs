using Resto.Application.Common.Interfaces;
using Resto.Application.Common.Interfaces.Repositories;
using Resto.Application.DTOs;
using Resto.Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;

namespace Resto.Infrastructure.Repositories
{
    public class MenuRepository(IApplicationDbContext context) : IMenuRepository
    {
        private readonly IApplicationDbContext _context = context;
        private readonly DbSet<MenuItem> _dbSet = context.MenuItems;


        public async Task<string> AddMenuItemAsync(string name, string description, decimal price, string category)
        {
            var menuItem = await _context.MenuItems.FirstOrDefaultAsync(x=>x.Name == name);
           
            if(menuItem is not null)
            {
                throw new DuplicateItemException("Menu item already exists");
            }

            var newMenuItem = new MenuItem
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Description = description,
                Price = price,
                Category = category,
                IsAvailable = true
            };

            _dbSet.Add(newMenuItem);
            await _context.SaveChangesAsync();
            return newMenuItem.Id.ToString();
        }

        public async Task<string> UpdateMenuItemAsync(string id, string name, string description, decimal price, string category)
        {
          if(await _dbSet.FindAsync(id) is not { } existingMenuItem)
            {
                throw new NotFoundException("Menu item", id);
            }
            existingMenuItem.Name = name;
            existingMenuItem.Description = description;
            existingMenuItem.Price = price;
            existingMenuItem.Category = category;
            existingMenuItem.IsAvailable = true;


            _dbSet.Update(existingMenuItem);
            await _context.SaveChangesAsync();
            return existingMenuItem.Id.ToString();
        }

        public async Task<bool> DeleteMenuItemAsync(string id)
        {
            if (await _dbSet.FindAsync(id) is not { } existingMenuItem)
            {
                throw new NotFoundException("Menu item", id);
            }

            _dbSet.Remove(existingMenuItem);
            return true;
        }

        public async Task<IEnumerable<MenuDto>> GetAllMenuItemsAsync()
        {
            return await _dbSet
                  .ProjectToType<MenuDto>().ToListAsync();
        }

        public async Task<MenuDto> GetMenuItemByIdAsync(string id)
        {
         if(await _dbSet.FindAsync(id) is not { } existingMenuItem)
            {
                throw new NotFoundException("Menu item", id);
            }
            return existingMenuItem.Adapt<MenuDto>();
        }
        public async Task<IEnumerable<MenuDto>> GetMenuItemsByCategoryAsync(string category)
        {
            var menuItems = await _dbSet
                .Where(x => x.Category == category)
                .ProjectToType<MenuDto>()
                .ToListAsync();

            if (menuItems is null || !menuItems.Any())
            {
                throw new NotFoundException("Menu items", category);
            }

            return menuItems;
        }

    }
}

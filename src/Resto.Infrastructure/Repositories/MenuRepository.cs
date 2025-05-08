namespace Resto.Infrastructure.Repositories
{
    public class MenuRepository(IApplicationDbContext context) : IMenuRepository
    {
        private readonly IApplicationDbContext _context = context;
        private readonly DbSet<MenuItem> _dbSet = context.MenuItems;

        public async Task<string> AddMenuItemAsync(MenuItem menuItem)
        {
            await _dbSet.AddAsync(menuItem);
            await _context.SaveChangesAsync();
            return menuItem.Id;
        }

        public async Task<string> UpdateMenuItemAsync(MenuItem menuItem)
        {
            _dbSet.Update(menuItem);
            await _context.SaveChangesAsync();
            return menuItem.Id;
        }

        public async Task<string> DeleteMenuItemAsync(MenuItem menuItem)
        {
            _dbSet.Update(menuItem);
            await _context.SaveChangesAsync();
            return menuItem.Id;
        }

        public async Task<PagedResult<MenuItem>> GetAllMenuItemsAsync(int pageNumber, int pageSize)
        {
            var items = await _dbSet
                .OrderBy(x => x.Name)
                .Skip((pageNumber -1 ) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var menuItemCount = await _dbSet.CountAsync();

            var pagedResult = new PagedResult<MenuItem>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = menuItemCount
            };

            return pagedResult;
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(string id)
        {
          return await _dbSet.FirstOrDefaultAsync(m => m.Id ==id && m.IsAvailable);
        }

        public async Task<IEnumerable<MenuItem>> GetMenuItemsByCategoryAsync(string category)
        {
            var items = await _dbSet.Where(x => x.Category == category).ToListAsync();
            return items;
        }
    }
}


namespace Resto.Infrastructure.Repositories
{
    public class IngredientRepository(IApplicationDbContext context) : IIngredientRepository
    {
        private readonly IApplicationDbContext _context = context;
        private readonly DbSet<Ingredient> _dbSet = context.Ingredients;

        public async Task<string> AddIngredientAsync(Ingredient ingredient)
        {
            _dbSet.Add(ingredient);
            await _context.SaveChangesAsync();
            return ingredient.Id;
        }

        public async Task<string> UpdateIngredientAsync(Ingredient ingredient)
        {
            _dbSet.Update(ingredient);
            await _context.SaveChangesAsync();
            return ingredient.Id;
        }

        public async Task<string> DeleteIngredientAsync(Ingredient ingredient)
        {
            _dbSet.Update(ingredient);
            await _context.SaveChangesAsync();
            return ingredient.Id;
        }

        public async Task<PagedResult<Ingredient>> GetAllIngredientsAsync(int pageNumber, int pageSize)
        {
            if(pageNumber < 1 || pageSize < 1)
                throw new ArgumentException("Invalid page number or page size.");

            var items = await _dbSet
               .OrderBy(i => i.Name)
               .Skip((pageNumber - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();

            var totalItems = await _dbSet.CountAsync();
            return new PagedResult<Ingredient>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        public async Task<Ingredient> GetIngredientByIdAsync(string id)
        {
            return await _dbSet
                 .FirstOrDefaultAsync(i => i.Id == id);
        }

    }
}

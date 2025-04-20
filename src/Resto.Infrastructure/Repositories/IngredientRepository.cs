using Resto.Application.Common.Exceptions;
using Resto.Application.Common.Interfaces;
using Resto.Application.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Infrastructure.Repositories
{
    public class IngredientRepository(IApplicationDbContext context) : IIngredientRepository
    {
        private readonly IApplicationDbContext _context = context;
        private readonly DbSet<Ingredient> _dbSet = context.Ingredients;

        public async Task<string> AddIngredientAsync(string Id, string name, int Units)
        {
            if (await _dbSet.FindAsync(Id) is not{ } existingIngredient)
            {
                var ingredient = new Ingredient
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name,
                    Unit = Units
                };
                await _dbSet.AddAsync(ingredient);
                await _context.SaveChangesAsync();
                return ingredient.Id.ToString();
            }

            existingIngredient.Unit += Units;
            await _context.SaveChangesAsync();
            return existingIngredient.Id.ToString();
        }

        public async Task<string> UpdateIngredientAsync(string id, string name, int Units)
        {
            if(await _dbSet.FindAsync(id) is not { } existingIngredient)
            {
                throw new NotFoundException("Ingredient", name);
            }

            existingIngredient.Name = name;
            existingIngredient.Unit = Units;
            _dbSet.Update(existingIngredient);
            await _context.SaveChangesAsync();

            return existingIngredient.Id.ToString();
        }

        public async Task<bool> DeleteIngredientAsync(string id)
        {
            if (await _dbSet.FindAsync(id) is not { } existingIngredient)
            {
                throw new NotFoundException("Ingredient", id);
            }
            _dbSet.Remove(existingIngredient);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
          return await _dbSet.ToListAsync();
        }

        public async Task<Ingredient> GetIngredientByIdAsync(string id)
        {
            if (await _dbSet.FindAsync(id) is not { } existingIngredient)
            {
                throw new NotFoundException("Ingredient", id);
            }
            return existingIngredient;
        }

    }
}

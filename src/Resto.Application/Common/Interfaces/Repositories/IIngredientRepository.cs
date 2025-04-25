using Resto.Application.Common.Pagination;
using Resto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.Interfaces.Repositories
{
   public interface IIngredientRepository
    {
        Task<string> AddIngredientAsync(Ingredient ingredient);
        Task<string> UpdateIngredientAsync(Ingredient ingredient);
        Task<string> DeleteIngredientAsync(Ingredient ingredient);
        Task<PagedResult<Ingredient>> GetAllIngredientsAsync(int pageNumber ,int pageSize);
        Task<Ingredient> GetIngredientByIdAsync(string id);
    }
}

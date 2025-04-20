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
        Task<string> AddIngredientAsync(string Id,string name,int Units);
        Task<string> UpdateIngredientAsync(string id, string name, int Units);
        Task<bool> DeleteIngredientAsync(string id);
        Task<IEnumerable<Ingredient>> GetAllIngredientsAsync();
        Task<Ingredient> GetIngredientByIdAsync(string id);
    }
}

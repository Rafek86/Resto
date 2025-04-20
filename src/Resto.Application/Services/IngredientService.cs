using Resto.Application.Common.Interfaces.Repositories;
using Resto.Application.Common.Interfaces.Services;
using Resto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Services
{
   public class IngredientService(IIngredientRepository ingredientRepository) : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository =ingredientRepository;

        public Task<string> AddIngredientAsync(string Id, string name, int Units)
        {
            return _ingredientRepository.AddIngredientAsync(Id, name, Units);
        }
        public Task<string> UpdateIngredientAsync(string id, string name, int Units)
        {
            return _ingredientRepository.UpdateIngredientAsync(id, name, Units);
        }
        public Task<bool> DeleteIngredientAsync(string id)
        {
            return _ingredientRepository.DeleteIngredientAsync(id);
        }
        public Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
            return _ingredientRepository.GetAllIngredientsAsync();
        }
        public Task<Ingredient> GetIngredientByIdAsync(string id)
        {
            return _ingredientRepository.GetIngredientByIdAsync(id);
        }
    }

}

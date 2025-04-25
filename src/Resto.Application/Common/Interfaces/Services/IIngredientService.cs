using Resto.Application.Common.Pagination;
using Resto.Application.Features.Customers.Commands.CreateCustomer;
using Resto.Application.Features.Customers.Commands.DeleteCustomer;
using Resto.Application.Features.Ingredients.Commands.CreateIngredient;
using Resto.Application.Features.Ingredients.Commands.DeleteIngredient;
using Resto.Application.Features.Ingredients.Commands.UpdateIngredient;
using Resto.Application.Features.Ingredients.Queries.GetAll;
using Resto.Application.Features.Ingredients.Queries.GetById;
using Resto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.Interfaces.Services
{
    public interface IIngredientService
    {
        Task<CreateIngredientResult> AddIngredientAsync(CreateIngredientCommand command);
        Task<UpdateIngredientResult> UpdateIngredientAsync(UpdateIngredientCommand command);
        Task<DeleteIngredientResult> DeleteIngredientAsync(DeleteIngredientCommand command);
        Task<PagedResult<GetIngredientsResult>> GetAllIngredientsAsync(GetIngredientsQuery query);
        Task<GetIngredientByIdResult> GetIngredientByIdAsync(GetIngredientByIdQuery query);
    }
}

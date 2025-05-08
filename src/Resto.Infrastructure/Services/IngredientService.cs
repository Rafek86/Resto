using Resto.Application.Features.Ingredients.Commands.CreateIngredient;
using Resto.Application.Features.Ingredients.Commands.DeleteIngredient;
using Resto.Application.Features.Ingredients.Commands.UpdateIngredient;
using Resto.Application.Features.Ingredients.Queries.GetAll;
using Resto.Application.Features.Ingredients.Queries.GetById;


namespace Resto.Application.Services
{
   public class IngredientService(IIngredientRepository ingredientRepository) : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository =ingredientRepository;

        public async Task<CreateIngredientResult> AddIngredientAsync(CreateIngredientCommand command)
        {
            var ingredient = Ingredient.Create(
                command.Name,
                command.Unit,
                command.RecordThreshold
            );

            await _ingredientRepository.AddIngredientAsync(ingredient);

            return new CreateIngredientResult(ingredient.Id);
        }

        public async Task<UpdateIngredientResult> UpdateIngredientAsync(UpdateIngredientCommand command)
        {
            if (await _ingredientRepository.GetIngredientByIdAsync(command.Id) is not { } ingredient)
                throw new NotFoundException("Ingredient" ,$"{command.Id}");

            ingredient.Update(
                command.Name,
                command.Unit,
                command.RecordThreshold
            );

            await _ingredientRepository.UpdateIngredientAsync(ingredient);

            return new UpdateIngredientResult(true);
        }
        public async Task<DeleteIngredientResult> DeleteIngredientAsync(DeleteIngredientCommand command)
        {
            if (await _ingredientRepository.GetIngredientByIdAsync(command.Id) is not { } ingredient)
                throw new NotFoundException("Ingredient", $"{command.Id}");

            ingredient.Delete();

            await _ingredientRepository.UpdateIngredientAsync(ingredient);

            return new DeleteIngredientResult(true);
        }


        public async Task<PagedResult<GetIngredientsResult>> GetAllIngredientsAsync(GetIngredientsQuery query)
        {
            var ingredientsPaged = await _ingredientRepository.GetAllIngredientsAsync(query.PageNumber, query.PageSize);

            var mappedItems = ingredientsPaged.Items.Select(ings => 
            new GetIngredientsResult (
                new IngredientDto
                (
                 ings.Name,
                 ings.Unit,
                 ings.RecordThreshold,
                 ings.IsAvailable
                )
            )).ToList();

            return new PagedResult<GetIngredientsResult>
            {
                Items = mappedItems,
                TotalItems = ingredientsPaged.TotalItems,
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };
        }


        public async Task<GetIngredientByIdResult> GetIngredientByIdAsync(GetIngredientByIdQuery query)
        {
            if (await _ingredientRepository.GetIngredientByIdAsync(query.Id) is not { } ingredient)
                throw new NotFoundException("Ingredient", $"{query.Id}");

            var dto = ingredient.Adapt<IngredientDto>();
            return new GetIngredientByIdResult(dto);
        }

   }

}

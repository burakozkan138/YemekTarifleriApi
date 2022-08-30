using AutoMapper;
using YemekTarifleriApi.Application.Dto;
using YemekTarifleriApi.Application.Features.Commands.Categories.Create;
using YemekTarifleriApi.Application.Features.Commands.Categories.Update;
using YemekTarifleriApi.Application.Features.Commands.Ingredients.Create;
using YemekTarifleriApi.Application.Features.Commands.Ingredients.Update;
using YemekTarifleriApi.Application.Features.Commands.Recipes.Create;
using YemekTarifleriApi.Application.Features.Commands.Recipes.Update;
using YemekTarifleriApi.Application.Features.Commands.Steps.Create;
using YemekTarifleriApi.Application.Features.Commands.Steps.Update;
using YemekTarifleriApi.Application.Features.Commands.Users.Register;
using YemekTarifleriApi.Application.Features.Commands.Users.Update;
using YemekTarifleriApi.Application.Features.Queries.Categories.GetAllCategories;
using YemekTarifleriApi.Application.Features.Queries.Recipes.GetAllRecipes;
using YemekTarifleriApi.Application.Features.Queries.Recipes.GetRecipeDetail;
using YemekTarifleriApi.Domain.Models;

namespace YemekTarifleriApi.Application.Mappers;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<RegisterCommandRequest, User>().ReverseMap();
    CreateMap<UpdateUserCommandRequest, User>()
      .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));

    CreateMap<CreateCategoryCommandRequest, Category>().ReverseMap();
    CreateMap<GetAllCategoriesQueryResponse, Category>().ReverseMap();
    CreateMap<UpdateCategoryCommandRequest, Category>()
      .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));

    CreateMap<CreateRecipeCommandRequest, Recipe>().ReverseMap();
    CreateMap<UpdateRecipeCommandRequest, Recipe>()
      .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));

    CreateMap<Recipe, GetAllRecipesQueryResponse>().ReverseMap();

    CreateMap<Recipe, GetRecipeDetailQueryResponse>()
      .ForMember(x => x.CategoryName, opts => opts.MapFrom(x => x.Category.Name))
      .ForMember(x => x.CreatedByUserName, opts => opts.MapFrom(x => x.CreatedBy.UserName));

    CreateMap<Ingredient, IngredientDetail>().ReverseMap();
    CreateMap<Step, StepDetail>().ReverseMap();

    CreateMap<CreateIngredientCommandRequest, Ingredient>().ReverseMap();
    CreateMap<UpdateIngredientCommandRequest, Ingredient>()
      .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));

    CreateMap<CreateStepCommandRequest, Step>().ReverseMap();
    CreateMap<UpdateStepCommandRequest, Step>()
      .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));
  }
}
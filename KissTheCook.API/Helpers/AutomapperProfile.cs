using AutoMapper;
using KissTheCook.API.Data;
using KissTheCook.API.DTOs;
using KissTheCook.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KissTheCook.API.Helpers.MappingActions;

namespace KissTheCook.API.Helpers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Recipe, RecipeForDetailedDto>();
            CreateMap<RecipeIngredient, RecipeIngredientForDetailedDto>()
                .AfterMap<RecipeIngredientsToMeasurementQuantity>()
                .AfterMap<RecipeIngredientsToMeasurementUnit>()
                .AfterMap<RecipeIngredientsToIngredient>();
            CreateMap<Recipe, RecipeForListDto>();
            CreateMap<RecipeForPostDto, Recipe>();
            CreateMap<RecipeIngredientForPostDto, RecipeIngredient>();
            CreateMap<Ingredient, IngredientForGetDto>();
            CreateMap<IngredientForPostDto, Ingredient>();
            CreateMap<MeasurementQuantity, MeasurementQuantityForGetDto>();
            CreateMap<MeasurementQuantityForPostDto, MeasurementQuantity>();
            CreateMap<MeasurementUnit, MeasurementUnitForGetDto>();
            CreateMap<MeasurementUnitForPostDto, MeasurementUnit>();
        }
    }
}

using AutoMapper;
using KissTheCook.API.Data;
using KissTheCook.API.DTOs;
using KissTheCook.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KissTheCook.API.Helpers
{
    public class MappingActions
    {/// <summary>
    /// Workaround for dependencies injection into the Automapper Profile
    /// </summary>
        public class RecipeIngredientsToMeasurementQuantity : IMappingAction<RecipeIngredient, RecipeIngredientForDetailedDto>
        {
            private readonly ICookingRepository _cookingRepository;

            public RecipeIngredientsToMeasurementQuantity(ICookingRepository cookingRepository)
            {
                _cookingRepository = cookingRepository;
            }

            public void Process(RecipeIngredient source, RecipeIngredientForDetailedDto destination, ResolutionContext context)
            {
                destination.MeasurementQuantityAmount = _cookingRepository.Find<MeasurementQuantity>(source.MeasurementQuantityId).Amount;
            }
        }

        public class RecipeIngredientsToMeasurementUnit : IMappingAction<RecipeIngredient, RecipeIngredientForDetailedDto>
        {
            private readonly ICookingRepository _cookingRepository;

            public RecipeIngredientsToMeasurementUnit(ICookingRepository cookingRepository)
            {
                _cookingRepository = cookingRepository;
            }

            public void Process(RecipeIngredient source, RecipeIngredientForDetailedDto destination, ResolutionContext context)
            {
                destination.MeasurementUnitDescription = _cookingRepository.Find<MeasurementUnit>(source.MeasurementUnitId).Description;
            }
        }

        public class RecipeIngredientsToIngredient : IMappingAction<RecipeIngredient, RecipeIngredientForDetailedDto>
        {
            private readonly ICookingRepository _cookingRepository;

            public RecipeIngredientsToIngredient(ICookingRepository cookingRepository)
            {
                _cookingRepository = cookingRepository;
            }

            public void Process(RecipeIngredient source, RecipeIngredientForDetailedDto destination, ResolutionContext context)
            {
                destination.IngredientName = _cookingRepository.Find<Ingredient>(source.IngredientId).Name;
            }
        }
    }
}

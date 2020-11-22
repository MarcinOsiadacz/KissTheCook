using AutoMapper;
using KissTheCook.API.Helpers;
using KissTheCook.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KissTheCook.API.Data
{
    public interface ICookingRepository
    {
        /* Generic */
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        T Find<T>(params object[] keyValues) where T : class;
        Task<bool> SaveChanges();

        /* Ingredients */
        Task<IEnumerable<Ingredient>> GetIngredients();
        Task<Ingredient> GetIngredient(int id);

        /* Measurement Units */
        Task<IEnumerable<MeasurementUnit>> GetMeasurementUnits();
        Task<MeasurementUnit> GetMeasurementUnit(int id);

        /* Measurement Quantities */
        Task<IEnumerable<MeasurementQuantity>> GetMeasurementQuantities();
        Task<MeasurementQuantity> GetMeasurementQuantity(int id);

        /* Recipes */
        Task<IEnumerable<Recipe>> GetRecipes(RecipeParams @params);
        Task<Recipe> GetRecipe(int id);
    }
}

using AutoMapper;
using KissTheCook.API.Helpers;
using KissTheCook.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace KissTheCook.API.Data
{
    public class CookingRepository : ICookingRepository
    {
        private readonly KissTheCookDb _db;

        public CookingRepository(KissTheCookDb db)
        {
            _db = db;
        }

        public void Add<T>(T entity) where T : class
        {
            _db.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _db.Remove(entity);
        }

        public T Find<T>(params object[] keyValues) where T : class
        {
            return _db.Find<T>(keyValues);
        }

        public async Task<bool> SaveChanges()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        // Ingredients

        public async Task<Ingredient> GetIngredient(int id)
        {
            return await _db.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Ingredient>> GetIngredients()
        {
            return await _db.Ingredients.ToListAsync();
        }

        // Quantities
        public async Task<IEnumerable<MeasurementQuantity>> GetMeasurementQuantities()
        {
            return await _db.MeasurementQuantities.ToListAsync();
        }

        public async Task<MeasurementQuantity> GetMeasurementQuantity(int id)
        {
            return await _db.MeasurementQuantities.FirstOrDefaultAsync(i => i.Id == id);
        }

        // Units
        public async Task<MeasurementUnit> GetMeasurementUnit(int id)
        {
            return await _db.MeasurementUnits.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<MeasurementUnit>> GetMeasurementUnits()
        {
            return await _db.MeasurementUnits.ToListAsync();
        }

        // Recipes
        public async Task<Recipe> GetRecipe(int id)
        {
            return await _db.Recipes.Include(i => i.RecipeIngredients).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Recipe>> GetRecipes(RecipeParams @params)
        {
            var ingredientsCount = @params.IngredientsSet.Count(); // Verify the number of ingredients in params
            
            IQueryable<int> recipeIds = GetRecipeIdsByIngredient(@params.IngredientsSet.First()); // Get recipes containing first ingredient

            for (int i = 1; i < ingredientsCount; i++) // for the rest of ingredients
                recipeIds = recipeIds.Intersect( //  get common recipe ids for previous
                    GetRecipeIdsByIngredient(@params.IngredientsSet.ElementAt(i))); // and current ingredients

            IList<int> recipeIdsToReturn = new List<int>();

            foreach (var id in recipeIds) // Verify if selected recipe ids do not contain any other ingredients expect these from params
                if (_db.RecipeIngredients.Where(x => x.RecipeId == id).ToList().Count <= ingredientsCount)
                    recipeIdsToReturn.Add(id);

            //var test = await _db.Recipes
            //    .Include(ri => ri.RecipeIngredients)
            //    .Where(r =>
            //             @params.IngredientsSet.IsEquivalentTo(
            //             r.RecipeIngredients.Select(x => x.IngredientId).ToList())
            //        )
            //    .ToListAsync();

            return await _db.Recipes.Where(r => recipeIdsToReturn.Contains(r.Id)).ToListAsync();
       //    return test;
        }

        /// <summary>
        /// Gets Ingredient entity Id as a parameter and returns ids of Recipes containing this ingredient.
        /// </summary>
        private IQueryable<int> GetRecipeIdsByIngredient(int ingredientId)
        {
            return _db.RecipeIngredients.Where(r =>
                    r.Ingredient.Id == ingredientId
                )
                .Select(x => x.RecipeId);
        }

        //private IQueryable<int> GetRecipeIdsByIngredientSet(IList<int> ingredientId)
        //{
        //    return _db.RecipeIngredients.Where(r =>
        //        r.IngredientId.Equals
        //    )
        //    .Select(x => x.RecipeId);
        //}
    }
}

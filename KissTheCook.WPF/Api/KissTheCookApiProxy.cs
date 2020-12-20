using KissTheCook.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KissTheCook.WPF.Api
{
    /// <summary>
    /// Proxy Class for Proxy Design Pattern
    /// </summary>
    public class KissTheCookApiProxy : IKissTheCookApi
    {
        public KissTheCookApi KissTheCookApi = KissTheCookApi.Client;

        public ICollection<IngredientResponseModel> GetIngredients()
        {
            return KissTheCookApi.GetIngredients();
        }

        public RecipeDetailedModel GetRecipeById(int id)
        {
            return KissTheCookApi.GetRecipeById(id);
        }

        public ICollection<RecipeListModel> GetRecipesByIngredients(IList<int> ingredientIds)
        {
            return KissTheCookApi.GetRecipesByIngredients(ingredientIds);
        }
    }
}

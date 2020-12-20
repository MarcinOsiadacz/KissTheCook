using KissTheCook.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KissTheCook.WPF.Api
{
    /// <summary>
    /// Interface for Proxy Design Pattern
    /// </summary>
    public interface IKissTheCookApi
    {
        RecipeDetailedModel GetRecipeById(int id);
        ICollection<RecipeListModel> GetRecipesByIngredients(IList<int> ingredientIds);
        ICollection<IngredientResponseModel> GetIngredients();
    }
}

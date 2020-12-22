using KissTheCook.WPF.Api;
using KissTheCook.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KissTheCook.WPF.Helpers
{
    /// <summary>
    /// Adapter Class for Adapter Design Pattern
    /// </summary>
    public class ApiAdapter : KissTheCookApiProxy, ITargetApi
    {
        public RateRecipeResponseModel OcenPrzepis(int identyfikator, int ocena)
        {
            return base.KissTheCookApi.RateRecipe(identyfikator, ocena);
        }

        public RecipeDetailedModel WczytajPrzepis(int identyfikator)
        {
            return base.KissTheCookApi.GetRecipeById(identyfikator);
        }

        public ICollection<RecipeListModel> WczytajPrzepisyZeSkladnikow(IList<int> identyfikatorySkladnikow)
        {
            return base.GetRecipesByIngredients(identyfikatorySkladnikow);
        }

        public ICollection<IngredientResponseModel> WczytajSkladniki()
        {
            return base.GetIngredients();
        }
    }
}

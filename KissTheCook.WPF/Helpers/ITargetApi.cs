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
    /// Target inferface for Adapter design pattern
    /// </summary>
    public interface ITargetApi
    {
        RecipeDetailedModel WczytajPrzepis(int identyfikator);
        ICollection<RecipeListModel> WczytajPrzepisyZeSkladnikow(IList<int> identyfikatorySkladnikow);
        ICollection<IngredientResponseModel> WczytajSkladniki();
        RateRecipeResponseModel OcenPrzepis(int identyfikator, int ocena);
    }
}

using Caliburn.Micro;
using Flurl;
using Flurl.Http;
using KissTheCook.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KissTheCook.WPF.Helpers
{
    public class KissTheCookApi
    {
        Url Url { get; } = "http://localhost:5000/api/recipes";

        public BindableCollection<RecipeListModel> GetRecipesByIngredients(int[] ingredientsIds)
        {
            var @params = new GetRecipeByIngredientsParams
            {
                IngredientsSet = new int[] { 1, 3 }
            };

            return Url
                .WithHeader("Content-Type", "application/json")
                .SendJsonAsync(
                    HttpMethod.Get,
                    @params
                ).ReceiveJson<BindableCollection<RecipeListModel>>()
                .Result;
        }
    }
}

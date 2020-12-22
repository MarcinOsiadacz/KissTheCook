using Caliburn.Micro;
using Flurl;
using Flurl.Http;
using KissTheCook.WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KissTheCook.WPF.Api
{    
     /// <summary>
     /// API Client implemented as Singleton design pattern
     /// Also RealSubject in Proxy design pattern
     /// </summary>
    public class KissTheCookApi : IKissTheCookApi
    {
        private static readonly Lazy<KissTheCookApi> _client = new Lazy<KissTheCookApi>(() => new KissTheCookApi());

        public static KissTheCookApi Client
        {
            get { return _client.Value; }
        }

        Url BaseUrl { get; } = "http://localhost:5000/api";

        string RecipesEndpointUrl { get; } = "/recipes";
        string IngredientsEndpointUrl { get; } = "/ingredients";

        private KissTheCookApi() { }

        public RecipeDetailedModel GetRecipeById(int id)
        {
            Url url = new Url($"{BaseUrl}{RecipesEndpointUrl}/{id}");

            return url
                .GetJsonAsync<RecipeDetailedModel>()
                .Result;
        }

        public ICollection<RecipeListModel> GetRecipesByIngredients(IList<int> ingredientIds)
        {
            Url url = new Url($"{BaseUrl}{RecipesEndpointUrl}").SetQueryParam("ids", ingredientIds);
            
            return url
                .GetJsonAsync<ICollection<RecipeListModel>>()
                .Result;
        }

        public ICollection<IngredientResponseModel> GetIngredients()
        {
            Url url = new Url($"{BaseUrl}{IngredientsEndpointUrl}");

            return url
                .GetJsonAsync<ICollection<IngredientResponseModel>>()
                .Result;
        }

        public RateRecipeResponseModel RateRecipe(int id, int rateValue)
        {
            Url url = new Url($"{BaseUrl}{RecipesEndpointUrl}/{id}/rate/{rateValue}");

            return url
                .WithHeader("ContentType", "application/json")
                .PutAsync()
                .ReceiveJson<RateRecipeResponseModel>()
                .Result;
        }
    }
}

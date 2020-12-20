using Caliburn.Micro;
using KissTheCook.WPF.Api;
using KissTheCook.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KissTheCook.WPF.ViewModels
{
    public class RecipeDetailedViewModel : Screen
    {
        private RecipeDetailedModel _recipe;
        private KissTheCookApiProxy _apiProxy;

        public KissTheCookApiProxy ApiProxy
        {
            get { return _apiProxy; }
            set { _apiProxy = value; }
        }

        public RecipeDetailedModel Recipe
        {
            get { return _recipe; }
            set { _recipe = value; }
        }

        public RecipeDetailedViewModel(int id)
        {
            ApiProxy = new KissTheCookApiProxy();
            Recipe = ApiProxy.GetRecipeById(id);
        }
    }
}

//    Recipe = new RecipeDetailedModel
//    {
//        Id = 5,
//        Name = "Kanapka z serem, majonezem i pomidorem",
//        Description = "Kanapka z serem, majonezem i pomidorem opis",
//        Rating = 0,
//        RecipeIngredients = new Ingredient[]
//        {
//            new Ingredient
//            {
//                MeasurementQuantityId = 1,
//                MeasurementQuantityAmount = "1",
//                MeasurementUnitId = 1,
//                MeasurementUnitDescription = "Kromka",
//                IngredientId = 3,
//                IngredientName = "Chleb"
//            },
//            new Ingredient
//            {
//                MeasurementQuantityId = 1,
//                MeasurementQuantityAmount = "1",
//                MeasurementUnitId = 1,
//                MeasurementUnitDescription = "Kromka",
//                IngredientId = 3,
//                IngredientName = "Chleb"
//            },
//        }
//};
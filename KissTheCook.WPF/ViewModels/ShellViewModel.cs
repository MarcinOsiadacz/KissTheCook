using Caliburn.Micro;
using KissTheCook.WPF.Api;
using KissTheCook.WPF.Helpers;
using KissTheCook.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KissTheCook.WPF.ViewModels
{
    /// <summary>
    /// Example client for Adapter Design Pattern
    /// </summary>
    public class ShellViewModel : Conductor<object>
    {
        private KissTheCookApiProxy _apiProxy;
        private ITargetApi _api;
        private RecipeListModel _selectedRecipe;
        private BindableCollection<RecipeListModel> _recipes = new BindableCollection<RecipeListModel>();
        private BindableCollection<IngredientListModel> _ingredients = new BindableCollection<IngredientListModel>();
        private BindableCollection<IngredientListModel> _selectedIngredients = new BindableCollection<IngredientListModel>();
        
        public KissTheCookApiProxy ApiProxy
        {
            get { return _apiProxy; }
            set { _apiProxy = value; }
        }
        public RecipeListModel SelectedRecipe
        {
            get { return _selectedRecipe; }
            set
            {
                _selectedRecipe = value;
                NotifyOfPropertyChange(() => SelectedRecipe);
                NotifyOfPropertyChange(() => CanShowRecipeDetails);
            }
        }
        public BindableCollection<RecipeListModel> Recipes
        {
            get
            {
                return _recipes;
            }
            set
            {
                _recipes = value;
            }
        }
        public BindableCollection<IngredientListModel> Ingredients
        {
            get { return _ingredients; }
            set 
            { 
                _ingredients = value;
            }
        }
        public BindableCollection<IngredientListModel> SelectedIngredients
        {
            get
            {
                _selectedIngredients.Clear();
                _selectedIngredients.AddRange(Ingredients.Where(i => i.IsSelected));
                return _selectedIngredients; 
            }
        }

        public ITargetApi Api
        {
            get { return _api; }
            set { _api = value; }
        }

        public ShellViewModel()
        {
            Api = new ApiAdapter();

            var ingredientsList = Api.WczytajSkladniki();
            
            foreach (var i in ingredientsList)
            {
                Ingredients.Add(new IngredientListModel(
                    id: i.Id,
                    name: i.Name
                ));
            }
        }

        public bool CanShowRecipeDetails
        {
            get
            {
                return !(SelectedRecipe == null);
            }
        }

        public void ShowRecipeDetails()
        {
            ActivateItem(new RecipeDetailedViewModel(SelectedRecipe.Id));
        }

        public void LoadRecipes()
        {
            var @params = SelectedIngredients.Select(i => i.Id).ToList();
            var recipesList = Api.WczytajPrzepisyZeSkladnikow(@params);

            Recipes.Clear();
            foreach (var r in recipesList)
                Recipes.Add(r);
        }
    }
}

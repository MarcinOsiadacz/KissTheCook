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
    public class ShellViewModel : Conductor<object>
    {
        private KissTheCookApiProxy _apiProxy;
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
            
        public ShellViewModel()
        {
            ApiProxy = new KissTheCookApiProxy();

            var ingredientsList = ApiProxy.GetIngredients();
            
            foreach (var i in ingredientsList)
            {
                Ingredients.Add(new IngredientListModel(
                    id: i.Id,
                    name: i.Name
                ));
            }
        }

        public void ShowRecipeDetails()
        {
            ActivateItem(new RecipeDetailedViewModel(SelectedRecipe.Id));
        }

        public bool CanLoadRecipes
        {
            get
            {
                return SelectedIngredients.Count == 0;
            }    
        }

        public void LoadRecipes()
        {
            var @params = SelectedIngredients.Select(i => i.Id).ToList();
            var recipesList = ApiProxy.GetRecipesByIngredients(@params);

            foreach (var r in recipesList)
                Recipes.Add(r);
        }
        /*
        private string _firstName = "Marcin";
        private string _lastName;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
        private PersonModel _selectedPerson;

        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Marcin", LastName = "Osiadacz" });
            People.Add(new PersonModel { FirstName = "Nina", LastName = "Baczynska" });
            People.Add(new PersonModel { FirstName = "Abisia", LastName = "Baczynska-Osiadacz" });
        }

        public string FirstName // Property Name must be consitent with x:Name in Xaml you want to bind
        {
            get { return _firstName; }
            set 
            { 
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName); // Notify every listener that property has changed
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string LastName
        {
            get 
            { 
                return _lastName; 
            }
            set 
            { 
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName
        {
            get 
            { 
                return $"{FirstName} {LastName}"; 
            }
        }

        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set 
            { 
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public bool CanClearText(string firstName, string lastName) // Properties as parameters in camelCase to this condition and the actual cleearing method
        {
            if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            else return true;
        }

        public void ClearText(string firstName, string lastName) // Method Name should be consistent with name of the calling button
        {
            FirstName = "";
            LastName = "";
        }

        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }
        */
    }
}

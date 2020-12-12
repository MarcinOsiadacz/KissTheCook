using Caliburn.Micro;
using KissTheCook.WPF.Helpers;
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
        private RecipeListModel _selectedRecipe;

        private BindableCollection<RecipeListModel> _recipes = new BindableCollection<RecipeListModel>();

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

        public RecipeListModel SelectedRecipe
        {
            get { return _selectedRecipe; }
            set 
            { 
                _selectedRecipe = value;
                NotifyOfPropertyChange(() => SelectedRecipe);
            }
        }

        public ShellViewModel()
        {
            /*
            Recipes.Add(new RecipeListModel { Id = 1, Name = "Spaghetti", Description = "Spaghetti description", Rating = 4 });
            Recipes.Add(new RecipeListModel { Id = 2, Name = "Dahl", Description = "Dahl description", Rating = 5 });
            Recipes.Add(new RecipeListModel { Id = 3, Name = "Kanapka z serem", Description = "Kanapka z serem description", Rating = 3 });
            */
            Recipes = new KissTheCookApi().GetRecipesByIngredients(new int[] { 1, 3 });
        }

        /*
        public bool CanShowRecipeDetails(RecipeListModel selectedRecipe) // Properties as parameters in camelCase to this condition and the actual cleearing method
        {
            if (selectedRecipe)
            {
                return false;
            }
            else return true;
        }

        public void ShowRecipeDetails(RecipeListModel selectedRecipe)
        {
            ActivateItem(new RecipeDetailedViewModel(SelectedRecipe.Id));
        }
        */
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

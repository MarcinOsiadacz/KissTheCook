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
    public class RecipeDetailedViewModel : Screen
    {
        private RecipeDetailedModel _recipe;
        private int _recipe_rate;
        private ITargetApi _api;

        public ITargetApi Api
        {
            get { return _api; }
            set { _api = value; }
        }

        public RecipeDetailedModel Recipe
        {
            get { return _recipe; }
            set { _recipe = value; }
        }

        public int RecipeRate
        {
            get 
            { 
                return _recipe_rate; 
            }
            set 
            {
                _recipe_rate = value;
                NotifyOfPropertyChange(() => RecipeRate);

                if (Recipe.Rating != RecipeRate)
                {
                    Recipe.Rating = RecipeRate;
                    Api.OcenPrzepis(Recipe.Id, RecipeRate);
                }
                      
            }
        }

        public RecipeDetailedViewModel(int id)
        {
            Api = new ApiAdapter();

            Recipe = Api.WczytajPrzepis(id);
            RecipeRate = Recipe.Rating;
        }

        public void ExportToFile()
        {
            var filename = $"{Recipe.Name} {DateTime.Now.ToString("yyyyMMddhhmmss")}.txt";

            var exportPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/{filename}";

            ExportToFileFacade.Instance.ExportToJson(Recipe, exportPath);
        }
    }
}
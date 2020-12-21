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

        public void ExportToFile()
        {
            var filename = $"{Recipe.Name} {DateTime.Now.ToString("yyyyMMddhhmmss")}.txt";

            var exportPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/{filename}";

            ExportToFileFacade.Instance.ExportToJson(Recipe, exportPath);
        }
    }
}
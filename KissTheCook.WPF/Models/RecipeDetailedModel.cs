using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KissTheCook.WPF.Models
{
    public class RecipeDetailedModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public Ingredient[] RecipeIngredients { get; set; }
    }

    public class Ingredient
    {
        public int MeasurementQuantityId { get; set; }
        public string MeasurementQuantityAmount { get; set; }
        public int MeasurementUnitId { get; set; }
        public string MeasurementUnitDescription { get; set; }
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
    }
}

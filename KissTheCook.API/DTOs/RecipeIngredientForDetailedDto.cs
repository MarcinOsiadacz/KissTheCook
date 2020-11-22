using KissTheCook.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KissTheCook.API.DTOs
{
    public class RecipeIngredientForDetailedDto
    {
        public int MeasurementQuantityId { get; set; }
        public string MeasurementQuantityAmount { get; set; }
        public int MeasurementUnitId { get; set; }
        public string MeasurementUnitDescription { get; set; }
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
    }
}

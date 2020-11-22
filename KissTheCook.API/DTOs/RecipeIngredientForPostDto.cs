using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KissTheCook.API.DTOs
{
    public class RecipeIngredientForPostDto
    {
        public int MeasurementQuantityId { get; set; }
        public int MeasurementUnitId { get; set; }
        public int IngredientId { get; set; }
    }
}

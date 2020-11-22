using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace KissTheCook.API.Models
{
    public class MeasurementQuantity : AbstractEntity
    {
        [Required]
        public string Amount { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}

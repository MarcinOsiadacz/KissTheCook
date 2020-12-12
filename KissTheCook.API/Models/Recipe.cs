using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KissTheCook.API.Models
{
    public class Recipe : AbstractEntity
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        [Range(1,5)]
        public int Rating { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}

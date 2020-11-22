using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KissTheCook.API.DTOs
{
    public class RecipeForPostDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<RecipeIngredientForPostDto> RecipeIngredients { get; set; }
    }
}

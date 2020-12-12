using KissTheCook.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KissTheCook.API.DTOs
{
    public class RecipeForDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public ICollection<RecipeIngredientForDetailedDto> RecipeIngredients { get; set; }
    }
}

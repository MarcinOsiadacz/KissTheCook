using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KissTheCook.API.DTOs
{
    public class RecipeForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

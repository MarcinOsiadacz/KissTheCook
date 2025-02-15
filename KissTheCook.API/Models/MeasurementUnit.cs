﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KissTheCook.API.Models
{
    public class MeasurementUnit : AbstractEntity
    {
        [Required]
        public string Description { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}

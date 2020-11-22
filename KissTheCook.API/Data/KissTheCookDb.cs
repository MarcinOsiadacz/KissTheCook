using KissTheCook.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KissTheCook.API.Data
{
    public class KissTheCookDb : DbContext
    {
        public KissTheCookDb(DbContextOptions<KissTheCookDb> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<MeasurementQuantity> MeasurementQuantities { get; set; }
        public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeIngredient>().HasKey(e => new
            {
                e.RecipeId,
                e.MeasurementQuantityId,
                e.MeasurementUnitId,
                e.IngredientId
            });
        }
    }
}

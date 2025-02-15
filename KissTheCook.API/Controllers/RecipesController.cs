﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KissTheCook.API.Data;
using KissTheCook.API.DTOs;
using KissTheCook.API.Helpers;
using KissTheCook.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KissTheCook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly ICookingRepository _cookingRepository;
        private readonly IMapper _mapper;

        public RecipesController(ICookingRepository cookingRepository, IMapper mapper)
        {
            _cookingRepository = cookingRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// This GET method provides recipes based on the list of provided Ingredient Ids.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>Recipes consisting of the igredients provided as parameter</returns>
        [HttpGet]
        public async Task<IActionResult> GetRecipes([FromQuery]IList<int> ids)
        {
            var recipes = await _cookingRepository.GetRecipes(ids);

            var recipesToReturn = _mapper.Map<IEnumerable<RecipeForListDto>>(recipes);
            
            return Ok(recipesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipe(int id)
        {
            var recipe = await _cookingRepository.GetRecipe(id);

            var recipeToReturn = _mapper.Map<RecipeForDetailedDto>(recipe);

            return Ok(recipeToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipe([FromBody]RecipeForPostDto recipeForPostDto)
        {
            var recipe = _mapper.Map<Recipe>(recipeForPostDto);

            _cookingRepository.Add(recipe);

            if (!ModelState.IsValid) 
                return BadRequest("Invalid data provided.");

            if (await _cookingRepository.SaveChanges())
            {
                var recipeToReturn = _mapper.Map<RecipeForDetailedDto>(recipe);
                return Ok(recipeToReturn);
            }

            return BadRequest("Failed to add Recipe");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(int id, [FromBody]RecipeForPostDto recipeForUpdateDto)
        {
            var recipeFromRepository = await _cookingRepository.GetRecipe(id);

            _mapper.Map(recipeForUpdateDto, recipeFromRepository);

            if (!ModelState.IsValid)
                return BadRequest("Invalid data provided.");

            if (await _cookingRepository.SaveChanges())
            {
                return Ok(new
                {
                    message = $"Recipe {id} updated successfully"
                });
            }

            return BadRequest($"Updating recipe {id} failed on save");
        }

        [HttpPut("{id}/rate/{ratingValue}")]
        public async Task<IActionResult> RateRecipe(int id, int ratingValue)
        {
            var recipeFromRepository = await _cookingRepository.GetRecipe(id);

            recipeFromRepository.Rating = ratingValue;

            if (!ModelState.IsValid)
                return BadRequest("Invalid data provided.");

            if (await _cookingRepository.SaveChanges())
            {
                return Ok(new
                {
                    message = $"Recipe {id} rated successfully"
                });
            }

            return BadRequest($"Rating recipe {id} failed on save");
        }
    }
}

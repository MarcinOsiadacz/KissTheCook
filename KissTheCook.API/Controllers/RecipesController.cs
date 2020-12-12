using System;
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
        
        [HttpGet]
        public async Task<IActionResult> GetRecipes([FromBody]RecipeParams @params)
        {
            var recipes = await _cookingRepository.GetRecipes(@params);

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
    }
}

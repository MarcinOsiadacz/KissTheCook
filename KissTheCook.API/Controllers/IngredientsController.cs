using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KissTheCook.API.Data;
using KissTheCook.API.DTOs;
using KissTheCook.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KissTheCook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly ICookingRepository _cookingRepository;
        private readonly IMapper _mapper;

        public IngredientsController(ICookingRepository cookingRepository, IMapper mapper)
        {
            _cookingRepository = cookingRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetIngredients()
        {
            var ingredients = await _cookingRepository.GetIngredients();
            return Ok(_mapper.Map<IEnumerable<IngredientForGetDto>>(ingredients));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIngredient(int id)
        {
            var ingredient = await _cookingRepository.GetIngredient(id);
            return Ok(_mapper.Map<IngredientForGetDto>(ingredient));
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredient([FromBody]IngredientForPostDto ingredientforPostDto)
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientforPostDto);

            _cookingRepository.Add(ingredient);

            if (await _cookingRepository.SaveChanges())
            {
                var ingredientToReturn = _mapper.Map<IngredientForGetDto>(ingredient);
                return Ok(ingredientToReturn);
            }

            return BadRequest("Failed to add Ingredient");
        }
    }
}

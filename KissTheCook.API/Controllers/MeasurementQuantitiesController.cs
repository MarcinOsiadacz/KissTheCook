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
    public class MeasurementQuantitiesController : ControllerBase
    {
        private readonly ICookingRepository _cookingRepository;
        private readonly IMapper _mapper;

        public MeasurementQuantitiesController(ICookingRepository cookingRepository, IMapper mapper)
        {
            _cookingRepository = cookingRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMeasurementQuantities()
        {
            var quantities = await _cookingRepository.GetMeasurementQuantities();
            return Ok(_mapper.Map<IEnumerable<MeasurementQuantityForGetDto>>(quantities));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeasurementQuantity(int id)
        {
            var quantity = await _cookingRepository.GetMeasurementQuantity(id);
            return Ok(_mapper.Map<MeasurementQuantityForGetDto>(quantity));
        }

        [HttpPost]
        public async Task<IActionResult> AddMeasurementQuantity([FromBody]MeasurementQuantityForPostDto quantityforPostDto)
        {
            var quantity = _mapper.Map<MeasurementQuantity>(quantityforPostDto);

            _cookingRepository.Add(quantity);

            if (await _cookingRepository.SaveChanges())
            {
                var quantityToReturn = _mapper.Map<MeasurementQuantityForGetDto>(quantity);
                return Ok(quantityToReturn);
            }

            return BadRequest("Failed add Measurement Quantity");
        }
    }
}

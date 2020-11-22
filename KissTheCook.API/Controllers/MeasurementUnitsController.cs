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
    public class MeasurementUnitsController : ControllerBase
    {
        private readonly ICookingRepository _cookingRepository;
        private readonly IMapper _mapper;

        public MeasurementUnitsController(ICookingRepository cookingRepository, IMapper mapper)
        {
            _cookingRepository = cookingRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMeasurementUnits()
        {
            var units = await _cookingRepository.GetMeasurementUnits();
            return Ok(_mapper.Map<IEnumerable<MeasurementUnitForGetDto>>(units));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeasurementUnit(int id)
        {
            var unit = await _cookingRepository.GetMeasurementUnit(id);
            return Ok(_mapper.Map<MeasurementUnitForGetDto>(unit));
        }

        [HttpPost]
        public async Task<IActionResult> AddMeasurementUnit([FromBody]MeasurementUnitForPostDto unitforPostDto)
        {
            var unit = _mapper.Map<MeasurementUnit>(unitforPostDto);

            _cookingRepository.Add(unit);

            if (await _cookingRepository.SaveChanges())
            {
                var unitToReturn = _mapper.Map<MeasurementUnitForGetDto>(unit);
                return Ok(unitToReturn);
            }

            return BadRequest("Failed add Measurement Unit");
        }
    }
}

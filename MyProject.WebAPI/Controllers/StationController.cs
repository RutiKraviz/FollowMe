﻿using Microsoft.AspNetCore.Mvc;
using MyProject.Common.DTOs;
using MyProject.Services.Interfaces;
using MyProject.WebAPI.Models;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;
        public StationController(IStationService stationInterface)
        {
            _stationService = stationInterface;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StationDTO>> Get(int id)
        {
            var station = await _stationService.GetByIdAsync(id);
            if (station == null)
                return NotFound();
            return station;
        }
        [HttpPost]
        public async Task<StationDTO> Post([FromBody] StationModel stationModel)
        {
            return await _stationService.AddAsync(new StationDTO() { Id = stationModel.Id, Latitude = stationModel.Latitude, Longitude = stationModel.Longitude });
        }
        [HttpPut]
        public async Task<StationDTO> Update([FromBody] StationModel stationModle)
        {
            return await _stationService.UpdateAsync(new StationDTO() { Id = stationModle.Id, Latitude = stationModle.Latitude, Longitude =stationModle.Longitude });
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _stationService.DeleteAsync(id);
            return NoContent();
        }
    }
}

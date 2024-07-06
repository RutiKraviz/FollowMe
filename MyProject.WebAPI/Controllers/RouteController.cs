using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Services.Interfaces;
using MyProject.WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;
        private readonly IStationService _stationService;
        private readonly IMapper _mapper;

        public RouteController(IRouteService routeService, IStationService stationService, IMapper mapper)
        {
            _routeService = routeService;
            _stationService = stationService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RouteDTO>> Get(int id)
        {
            var route = await _routeService.GetByIdAsync(id);
            if (route == null)
            {
                return NotFound();
            }

            // Ensure the stations are included
            var stations = await _stationService.GetByRouteIdAsync(route.Id);
            route.Stations = _mapper.Map<List<StationDTO>>(stations);

            return route;
        }

        [HttpPost]
        public async Task<ActionResult<RouteDTO>> Post([FromBody] RouteModel routeModel)
        {
            // Create the route and add it to the database
            RouteDTO routeDTO = new RouteDTO();
            var createdRoute = await _routeService.AddAsync(routeDTO);

            // Add the stations to the database with the created RouteId
            List<StationDTO> stations = new List<StationDTO>();
            foreach (var stationModel in routeModel.Stations)
            {
                StationDTO stationDTO = new StationDTO
                {
                    FullAddress = stationModel.FullAddress,
                    RouteId = createdRoute.Id, // Link the station to the created route
                    Lan = stationModel.Lan,
                    Lat = stationModel.Lat
                };
                var createdStation = await _stationService.AddAsync(stationDTO);
                stations.Add(createdStation);
            }

            // Update the created route with the list of created stations
            createdRoute.Stations = stations;
            return CreatedAtAction(nameof(Get), new { id = createdRoute.Id }, createdRoute);
        }

        [HttpPut]
        public async Task<ActionResult<RouteDTO>> Update([FromBody] RouteModel routeModel)
        {
            // Update the route
            RouteDTO routeDTO = new RouteDTO { Id = routeModel.Id };
            var updatedRoute = await _routeService.UpdateAsync(routeDTO);

            // Update the stations with the existing RouteId
            List<StationDTO> stations = new List<StationDTO>();
            foreach (var stationModel in routeModel.Stations)
            {
                StationDTO stationDTO = new StationDTO
                {
                    FullAddress = stationModel.FullAddress,
                    RouteId = updatedRoute.Id, // Link the station to the route
                    Lan = stationModel.Lan,
                    Lat = stationModel.Lat
                };
                var updatedStation = await _stationService.UpdateAsync(stationDTO);
                stations.Add(updatedStation);
            }

            // Ensure the updated route includes the updated stations
            updatedRoute.Stations = stations;
            return Ok(updatedRoute);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _routeService.DeleteAsync(id);
            return NoContent();
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Services.Interfaces;
using MyProject.WebAPI.Models;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;
        private readonly IRouteService _routeService;
        private readonly IMapper _mapper;

        public StationController(IStationService stationService, IMapper mapper, IRouteService routeService)
        {
            _stationService = stationService;
            _routeService = routeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationDTO>>> GetAll()
        {
            var stations = await _stationService.GetAllAsync();
            return Ok(stations);
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
            return await _stationService.AddAsync(new StationDTO() { FullAddress = stationModel.FullAddress, RouteId = stationModel.RouteId, Lan = stationModel.Lan, Lat = stationModel.Lat });
        }

        [HttpGet("Route/{id}")]
        public async Task<ActionResult<RouteDTO>> Login(int id)
        {
            var station = await _stationService.GetByIdAsync(id);
            if (station == null)
                return NotFound();
            int RouteId = station.RouteId;
            var route = await _routeService.GetByIdAsync(RouteId);
            if (route == null)
            {
                return NotFound();
            }
            var stations = await _stationService.GetByRouteIdAsync(route.Id);
            route.Stations = _mapper.Map<List<StationDTO>>(stations);
            return route;
        }

        [HttpPut]
        public async Task<StationDTO> Update([FromBody] StationModel stationModel)
        {
            return await _stationService.UpdateAsync(new StationDTO() { FullAddress = stationModel.FullAddress, RouteId = stationModel.RouteId, Lan = stationModel.Lan, Lat = stationModel.Lat });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _stationService.DeleteAsync(id);
            return NoContent();
        }
    }
}
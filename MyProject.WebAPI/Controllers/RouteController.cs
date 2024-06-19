using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.WebAPI.Models;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController: ControllerBase
    {
        private readonly IRouteService _routeService;
        private readonly IMapper _mapper;
        public RouteController(IRouteService routeService, IMapper mapper)
        {
            _mapper = mapper;
           _routeService = routeService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RouteDTO>> Get(int id)
        {
            var route = await _routeService.GetByIdAsync(id);
            if(route == null)
            {
                return NotFound();
            }
            return route;
        }
        [HttpPost]
        public async Task<RouteDTO> Post([FromBody] RouteModel routeModel)
        {
            return await _routeService.AddAsync(_mapper.Map<RouteDTO>(routeModel));
        }
        [HttpPut]
        public async Task<RouteDTO> Update([FromBody] RouteModel routeModel)
        {
            return await _routeService.UpdateAsync(_mapper.Map<RouteDTO>(routeModel));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _routeService.DeleteAsync(id);
            return NoContent();
        }
    }
}

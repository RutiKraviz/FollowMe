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
        private readonly IRouteInterface _routeService;
        public RouteController(IRouteInterface routeInterface)
        {
           _routeService = routeInterface;
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
            return await _routeService.AddAsync(new RouteDTO() {  Id = routeModel.Id, Stations = routeModel.Stations });
        }
        [HttpPut]
        public async Task<RouteDTO> Update([FromBody] RouteModel routeModel)
        {
            return await _routeService.UpdateAsync(new RouteDTO() { Id = routeModel.Id, Stations = routeModel.Stations });
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _routeService.DeleteAsync(id);
            return NoContent();
        }
    }
}

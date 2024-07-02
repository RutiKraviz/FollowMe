using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper _mapper;
        public StationController(IStationService stationService, IMapper mapper)
        {
            _stationService = stationService;
            _mapper = mapper;
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
            return await _stationService.AddAsync(new StationDTO() {FullAddress = stationModel.FullAddress});
        }
        [HttpPut]
        public async Task<StationDTO> Update([FromBody] StationModel stationModel)
        {
            return await _stationService.UpdateAsync(new StationDTO() { FullAddress = stationModel.FullAddress });
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _stationService.DeleteAsync(id);
            return NoContent();
        }
    }
}

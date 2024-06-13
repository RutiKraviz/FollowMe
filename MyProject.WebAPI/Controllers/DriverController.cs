using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using MyProject.Services.Interfaces;
using MyProject.WebAPI.Models;


namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController: ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly IMapper _mapper;
        public DriverController(IDriverService driverService, IMapper mapper)
        {
            _driverService = driverService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<DriverDTO>> Get(int id)
        {
            var driver = await _driverService.GetByIdAsync(id);
            if (driver == null)
                return NotFound();
            return driver;
        }
        [HttpPost]
        public async Task<DriverDTO> Post([FromBody] DriverModel driverModel)
        {
            return await _driverService.AddAsync(_mapper.Map<DriverDTO>(driverModel)) ;   
        }
        [HttpPut]
        public async Task<DriverDTO> Update([FromBody] DriverModel driverModel)
        {
            return await _driverService.UpdateAsync(_mapper.Map<DriverDTO>(driverModel));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _driverService.DeleteAsync(id);
            return NoContent();
        }
    }
}
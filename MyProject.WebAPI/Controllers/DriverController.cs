using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Common.DTOs;
using MyProject.Services.Interfaces;
using MyProject.WebAPI.Models;
using System.Threading.Tasks;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly IMapper _mapper;

        public DriverController(IDriverService driverService, IMapper mapper)
        {
            _driverService = driverService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
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
            var driverDto = _mapper.Map<DriverDTO>(new DriverDTO()
            {
                Id = driverModel.Id,
                FirstName = driverModel.FirstName,
                LastName = driverModel.LastName,
                Email = driverModel.Email,
                PassWord = driverModel.PassWord,
                RoleId = 1,
                RouteId = driverModel.RouteId,
            });
            return await _driverService.AddAsync(driverDto);
        }

        [HttpPut]
        public async Task<DriverDTO> Update([FromBody] DriverModel driverModel)
        {
            var driverDto = _mapper.Map<DriverDTO>(new DriverDTO()
            {
                Id = driverModel.Id,
                FirstName = driverModel.FirstName,
                LastName = driverModel.LastName,
                Email = driverModel.Email,
                PassWord = driverModel.PassWord,
                RoleId = 1,
                RouteId = driverModel.RouteId,
            });
            return await _driverService.UpdateAsync(driverDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _driverService.DeleteAsync(id);
            return NoContent();
        }
    }
}

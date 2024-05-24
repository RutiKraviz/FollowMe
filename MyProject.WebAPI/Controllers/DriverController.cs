using Microsoft.AspNetCore.Mvc;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using MyProject.Services.Interraces;
using MyProject.WebAPI.Models;


namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController: ControllerBase
    {
        private readonly IDriverinterface _driverService;
        public DriverController(IDriverinterface driverService)
        {
            _driverService = driverService;
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
            return await _driverService.AddAsync(new DriverDTO() {Id = driverModel.Id, FirstName = driverModel.FirstName, LastName = driverModel.LastName, Address = driverModel.Address, City = driverModel.City, Email = driverModel.Email, UserId = driverModel.UserId }) ;   
        }
        [HttpPut]
        public async Task<DriverDTO> Update([FromBody] DriverModel driverModel)
        {
            return await _driverService.UpdateAsync(new DriverDTO() { Id = driverModel.Id, FirstName = driverModel.FirstName, LastName = driverModel.LastName, Address = driverModel.Address, City = driverModel.City, Email = driverModel.Email, UserId = driverModel.UserId });
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _driverService.DeleteAsync(id);
            return NoContent();
        }
    }
}
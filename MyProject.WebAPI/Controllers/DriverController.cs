using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Common.DTOs;
using MyProject.Services.Interfaces;
using MyProject.WebAPI.Models;

[ApiController]
[Route("api/[controller]")]
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
        try
        {
            var driver = await _driverService.GetByIdAsync(id);
            return Ok(driver);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<DriverDTO>> Post([FromBody] DriverModel driverModel)
    {
        //var driverDto = _mapper.Map<DriverDTO>(driverModel);
        var addedDriver = await _driverService.AddAsync(new DriverDTO()
        {
            Id = driverModel.Id,
            FirstName = driverModel.FirstName,
            LastName = driverModel.LastName,
            Email = driverModel.Email,
            PassWord = driverModel.PassWord,
            RoleId = 2,
            RouteId = driverModel.RouteId,
        });
        return CreatedAtAction(nameof(Get), new { id = addedDriver.Id }, addedDriver);
    }

    [HttpPut]
    public async Task<ActionResult<DriverDTO>> Update([FromBody] DriverModel driverModel)
    {
        var driverDto = _mapper.Map<DriverDTO>(new DriverDTO()
        {
            Id = driverModel.Id,
            FirstName = driverModel.FirstName,
            LastName = driverModel.LastName,
            Email = driverModel.Email,
            PassWord = driverModel.PassWord,
            RoleId = 2,
            RouteId = driverModel.RouteId,
        });
        var updatedDriver = await _driverService.UpdateAsync(driverDto);
        return Ok(updatedDriver);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _driverService.DeleteAsync(id);
        return NoContent();
    }
}

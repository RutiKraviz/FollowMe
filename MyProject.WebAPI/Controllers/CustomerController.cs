using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Common.DTOs;
using MyProject.Services.Interfaces;
using MyProject.WebAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDTO>> Get(int id)
    {
        try
        {
            var customer = await _customerService.GetByIdAsync(id);
            return Ok(customer);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDTO>> Post([FromBody] CustomerModel customerModel)
    {
        var customerDto = _mapper.Map<CustomerDTO>(new CustomerDTO()
        {
            Id = customerModel.Id,
            FirstName = customerModel.FirstName,
            LastName = customerModel.LastName,
            Email = customerModel.Email,
            PassWord = customerModel.PassWord,
            RoleId = 2,
            StationId = customerModel.StationId,
        });
        var addedCustomer = await _customerService.AddAsync(customerDto);
        return CreatedAtAction(nameof(Get), new { id = addedCustomer.Id }, addedCustomer);
    }

    [HttpPut]
    public async Task<ActionResult<CustomerDTO>> Update([FromBody] CustomerModel customerModel)
    {
        var customerDto = _mapper.Map<CustomerDTO>(new CustomerDTO()
        {
            Id = customerModel.Id,
            FirstName = customerModel.FirstName,
            LastName = customerModel.LastName,
            Email = customerModel.Email,
            PassWord = customerModel.PassWord,
            RoleId = 2,
            StationId = customerModel.StationId,
        });
        var updatedCustomer = await _customerService.UpdateAsync(customerDto);
        return Ok(updatedCustomer);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _customerService.DeleteAsync(id);
        return NoContent();
    }
}

using Microsoft.AspNetCore.Mvc;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.WebAPI.Models;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CosumerContoller: ControllerBase
    {
        private readonly ICoustemerInterface _cosumerService;

        public CosumerContoller(ICoustemerInterface coustemerInterface)
        {
            _cosumerService = coustemerInterface;
        }
        [HttpGet]
        public async Task<ActionResult<CostumerDTO>> Get(int id)
        {
            var coustemer = await _cosumerService.GetByIdAsync(id);
            if (coustemer == null)
                return NotFound();
            return coustemer;
        }
        [HttpPost]
        public async Task<CostumerDTO> Post([FromBody] CostumerModel coustemrModel)
        {
            return await _cosumerService.AddAsync(new CostumerDTO() { Id = coustemrModel.Id, FirstName = coustemrModel.FirstName, LastName = coustemrModel.LastName, City = coustemrModel.City, Address = coustemrModel.Address, Email = coustemrModel.Email, UserId = coustemrModel.UserId });
        }
        [HttpPut]
        public async Task<CostumerDTO> Update([FromBody] CostumerModel costumerModel)
        {
            return await _cosumerService.UpdateAsync(new CostumerDTO() { Id = costumerModel.Id, FirstName = costumerModel.FirstName, LastName = costumerModel.LastName, City = costumerModel.City, Address = costumerModel.Address, Email = costumerModel.Email, UserId = costumerModel.UserId });
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _cosumerService.DeleteAsync(id);
            return NoContent();
        }
    }
}

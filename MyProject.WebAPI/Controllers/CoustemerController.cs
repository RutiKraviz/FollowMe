using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.WebAPI.Models;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoustemerController : ControllerBase
    {
        private readonly ICoustemerService _costumerService;
        private readonly IMapper _mapper;

        public CoustemerController(ICoustemerService coustemerInterface, IMapper mapper)
        {
            _costumerService = coustemerInterface;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<CoustemerDTO>> Get(int id)
        {
            var coustemer = await _costumerService.GetByIdAsync(id);
            if (coustemer == null)
                return NotFound();
            return coustemer;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<CoustemerDTO>> Post(CoustemerLoginModel login)
        {
            var coustemer = await _costumerService.Login(login.Username, login.Password);
            if (coustemer == null)
                return NotFound();
            return coustemer;
        }
        [HttpPost]
        public async Task<CoustemerDTO> Post([FromBody] CoustemerModel coustemrModel)
        {
            return await _costumerService.AddAsync(_mapper.Map<CoustemerDTO>(coustemrModel));
        }
        [HttpPut]
        public async Task<CoustemerDTO> Update([FromBody] CoustemerModel costumerModel)
        {
            return await _costumerService.UpdateAsync(_mapper.Map<CoustemerDTO>(costumerModel));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _costumerService.DeleteAsync(id);
            return NoContent();
        }
    }
}

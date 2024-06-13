using AutoMapper;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Services
{
    public class CoustemerService : ICoustemerService
    {
        private readonly ICoustemerRepository _coustemerRepository;
        private readonly IMapper _mapper;

        public CoustemerService(ICoustemerRepository coustemerRepository, IMapper mapper)
        {
            _coustemerRepository = coustemerRepository;
            _mapper = mapper;
        }
        public async Task<CoustemerDTO> AddAsync(CoustemerDTO costumer)
        {
            return _mapper.Map<CoustemerDTO>(await _coustemerRepository.AddAsync(_mapper.Map<Coustemer>(costumer)));
        }

        public async Task DeleteAsync(int id)
        {
            await _coustemerRepository.DeleteAsync(id);
        }

        public async Task<CoustemerDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<CoustemerDTO>(await _coustemerRepository.GetByIdAsync(id));
        }

        public async Task<CoustemerDTO> Login(string name, string password)
        {
            return _mapper.Map<CoustemerDTO>(await _coustemerRepository.Login(name,password));
        }

        public async Task<CoustemerDTO> UpdateAsync(CoustemerDTO coustemer)
        {
            return _mapper.Map<CoustemerDTO>(await _coustemerRepository.UpdateAsync(_mapper.Map<Coustemer>(coustemer)));
        }
    }
}

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
    public class CostumerService: ICoustemerInterface
    {
        private readonly ICoustemerRepository _coustemerRepository;
        private readonly IMapper _mapper;

        public CostumerService(ICoustemerRepository coustemerRepository, IMapper mapper)
        {
            _coustemerRepository = coustemerRepository;
            _mapper = mapper;
        }
        public async Task<CostumerDTO> AddAsync(CostumerDTO costumer)
        {
            return _mapper.Map<CostumerDTO>(await _coustemerRepository.AddAsync(costumer.Id, costumer.FirstName, costumer.lastName, costumer.Address, costumer.City, costumer.Email));
        }

        public async Task DeleteAsync(int id)
        {
            await _coustemerRepository.DeleteAsync(id);
        }

        public async Task<CostumerDTO> GetByIdAsync(int id)
        {
           return _mapper.Map<CostumerDTO>(await _coustemerRepository.GetByIdAsync(id));
        }

        public async Task<CostumerDTO> UpdateAsync(CostumerDTO coustemer)
        {
            return _mapper.Map<CostumerDTO>(await _coustemerRepository.UpdateAsync(_mapper.Map<Costumer>(coustemer)));
        }
    }
}

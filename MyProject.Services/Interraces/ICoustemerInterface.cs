using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface ICoustemerInterface
    {
        Task<CostumerDTO> GetByIdAsync(int id);

        Task<CostumerDTO> AddAsync(CostumerDTO costumer);

        Task<CostumerDTO> UpdateAsync(CostumerDTO coustemer);
        
        Task DeleteAsync(int id);
    }
}

using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface ICoustemerService
    {
        Task<CoustemerDTO> GetByIdAsync(int id);
        Task<CoustemerDTO> Login(string name,string Password);

        Task<CoustemerDTO> AddAsync(CoustemerDTO costumer);

        Task<CoustemerDTO> UpdateAsync(CoustemerDTO coustemer);
        
        Task DeleteAsync(int id);
    }
}

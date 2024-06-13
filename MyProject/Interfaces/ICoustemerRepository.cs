using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface ICoustemerRepository
    {
        Task<Coustemer> GetByIdAsync(int id);
        Task<Coustemer> Login(string name, string password);

        Task<Coustemer> AddAsync(Coustemer coustemer);

        Task<Coustemer> UpdateAsync(Coustemer coustemer);
        
        Task DeleteAsync(int id);
    }
}

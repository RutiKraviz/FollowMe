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
        Task<Costumer> GetByIdAsync(int id);

        Task<Costumer> AddAsync(int id, string firstName, string lastName, string address, string city, string email);

        Task<Costumer> UpdateAsync(Costumer coustemer);
        
        Task DeleteAsync(int id);
    }
}

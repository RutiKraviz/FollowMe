using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MyProject.Repositories.Interfaces
{
    public interface IStationRepository
    {
        Task<Station> GetByIdAsync(int id);

        Task<Station> AddAsync(int id, string address,int RouteId);

        Task<Station> UpdateAsync(Station station);

        Task DeleteAsync(int id);
    }
}

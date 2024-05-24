using MyProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Interraces
{
    public interface IUserInterface
    {
        Task<UserDTO> GetByIdAsync(int id);

        Task<UserDTO> AddAsync(UserDTO user);

        Task<UserDTO> UpdateAsync(UserDTO user);

        Task DeleteAsync(int id);
    }
}

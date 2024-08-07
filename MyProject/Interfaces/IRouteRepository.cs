﻿using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface IRouteRepository
    {
        Task<Route> GetByIdAsync(int id);

        Task<Route> AddAsync(int id, List<Station> stations, string startTime);

        Task<Route> UpdateAsync(Route route);

        Task DeleteAsync(int id);
    }
}

using Microsoft.Extensions.DependencyInjection;
using MyProject.Repositories;
using MyProject.Repositories.Interfaces;
using MyProject.Services.Interfaces;
using MyProject.Services.Services;


namespace MyProject.Services
{
    public static class Extentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Mapping));
            services.AddRepositories();
            services.AddScoped<ICoustemerService, CoustemerService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStationService, StationService>();
            services.AddScoped<IRouteService, RouteService>();


            return services;
        }
    }
}

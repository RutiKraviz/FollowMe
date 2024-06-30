using AutoMapper;
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
            
            services.AddRepositories();
            //services.AddScoped(typeof(ICoustemerService),typeof(CoustemerService));
            //services.AddScoped(typeof(IDriverService), typeof(DriverService));
            //services.AddScoped(typeof(IUserService), typeof(UserService));
            //services.AddScoped(typeof(IStationService), typeof(StationService));
            //services.AddScoped(typeof(IRouteService), typeof(RouteService));

            services.AddScoped<ICoustemerService, CoustemerService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStationService, StationService>();
            services.AddScoped<IRouteService, RouteService>();

            //services.AddDbContext<MyProject.Context.MyDbContext> ();            //var mapping = new MapperConfiguration(mc =>            //{            //    mc.AddProfile(new Mapping());            //});            //IMapper mapper = mapping.CreateMapper();            //services.AddSingleton(mapper);

            services.AddAutoMapper(typeof(Mapping));

            return services;
        }
    }
}

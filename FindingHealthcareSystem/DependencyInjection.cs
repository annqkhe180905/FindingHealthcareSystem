using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Repositories.Interfaces;
using Repositories.Repositories;
using Services.Interfaces;
using Services.Mappers;
using Services.Services;
using DataAccessObjects.Interfaces;
using DataAccessObjects.DAOs;
using Services;

namespace FindingHealthcareSystem
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericDAO<>), typeof(GenericDAO<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IFacilityTypeService, FacilityTypeService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ILocationService, LocationService>(); 
            services.AddScoped<IFacilityDao, FacilityDao>();
            services.AddScoped<IFacilityRepository, FacilityRepository>();


            return services;
        }
    }
}

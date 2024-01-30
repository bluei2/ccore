using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CCore.Dtos.Mapping;
namespace CCore.Api
{
    public static class ServiceExtension
    {
        public static void ConfigureMapping(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
            var mapperConfig = new MapperConfiguration(map =>
            {
                map.AddProfile<MappingProfile>();
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }
    }
}

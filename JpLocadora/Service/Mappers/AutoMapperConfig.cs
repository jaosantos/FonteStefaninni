using AutoMapper;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Service.Dto;
using System.Collections.Generic;

namespace Service.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper mapper;
        public static void Configure(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GeneroDto, Genero>();
                cfg.CreateMap< List<GeneroDto>, List<Genero>>();
                cfg.CreateMap<Genero, GeneroDto>();
                cfg.CreateMap< List<Genero>, List<GeneroDto>>();
                cfg.CreateMap<FilmeDto, Filme>();
                cfg.CreateMap<List<FilmeDto>, List<Filme>>();
                cfg.CreateMap<Filme, FilmeDto>();
                cfg.CreateMap< List<Filme>, List<FilmeDto>>();

            });
            mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

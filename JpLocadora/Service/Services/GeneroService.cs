using AutoMapper;
using Domain.Models;
using Repository.Interfaces;
using Service.Dto;
using Service.Interfaces;
using System.Collections.Generic;

namespace Service.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IRepository<Genero> _repositoryGenero;
        private readonly IMapper _mapper;

        public GeneroService(IRepository<Genero> repositoryGenero,
                             IMapper mapper)
        {
            _repositoryGenero = repositoryGenero;
            _mapper = mapper;
        }

        public List<GeneroDto> ConsultaListaGeneros()
        {
            var retorno = _mapper.Map<List<GeneroDto>>(_repositoryGenero.GetAll());
            return retorno; 
        }

        public GeneroDto ConsultaGenero(int id)
        {
            var retorno = _repositoryGenero.GetById(id);
            return _mapper.Map<GeneroDto>(retorno);
        }

        public string InsereGenero(GeneroDto generoDto)
        {
            var genero = _mapper.Map<Genero>(generoDto);

            _repositoryGenero.Add(genero);

            return "Genero Incluido com sucesso";
        }

        public string AlteraGenero(GeneroDto generoDto)
        {
            var genero = _mapper.Map<Genero>(generoDto);

            _repositoryGenero.Update(genero);
            return "Genero alterado com sucesso";
        }

        public string DeleteGenero(int id)
        {
            var genero = _repositoryGenero.GetById(id);
            _repositoryGenero.Remove(genero);
            return "Deletado com sucesso";
        }
    }
}

using AutoMapper;
using Domain.Models;
using Repository.Interfaces;
using Service.Dto;
using Service.Interfaces;
using System.Collections.Generic;

namespace Service.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IRepository<Filme> _repositoryFilme;
        private readonly IMapper _mapper;

        public FilmeService(IRepository<Filme> repositoryFilme,
                             IMapper mapper)
        {
            _repositoryFilme = repositoryFilme;
            _mapper = mapper;
        }

        public List<FilmeDto> ConsultaListaFilmes()
        {
            var teste = _repositoryFilme.GetAll();
            var retorno = _mapper.Map<List<FilmeDto>>(teste);
            return retorno;
        }

        public FilmeDto ConsultaFilme(int id)
        {
            var retorno = _repositoryFilme.GetById(id);
            return _mapper.Map<FilmeDto>(retorno);
        }

        public string InsereFilme(FilmeDto FilmeDto)
        {
            var Filme = _mapper.Map<Filme>(FilmeDto);

            _repositoryFilme.Add(Filme);

            return "Filme Incluido com sucesso";
        }

        public string AlteraFilme(FilmeDto FilmeDto)
        {
            var Filme = _repositoryFilme.GetById(FilmeDto.Id.Value);
            Filme.Diretor = FilmeDto.Diretor;
            Filme.Ano = FilmeDto.Ano;
            Filme.GeneroId = FilmeDto.GeneroId;
            Filme.Titulo = FilmeDto.Titulo;
            Filme.Sinopse = FilmeDto.Sinopse;

            _repositoryFilme.Update(Filme);
            return "Filme alterado com sucesso";
        }

        public string DeleteFilme(int id)
        {
            var Filme = _repositoryFilme.GetById(id);
            _repositoryFilme.Remove(Filme);
            return "Deletado com sucesso";
        }
    }
}

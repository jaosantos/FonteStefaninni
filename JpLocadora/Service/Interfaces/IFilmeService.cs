using Service.Dto;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IFilmeService
    {
        List<FilmeDto> ConsultaListaFilmes();

        FilmeDto ConsultaFilme(int id);

        string InsereFilme(FilmeDto FilmeDto);

        string AlteraFilme(FilmeDto FilmeDto);

        string DeleteFilme(int id);
    }
}

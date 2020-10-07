using Service.Dto;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IGeneroService
    {
        List<GeneroDto> ConsultaListaGeneros();

        GeneroDto ConsultaGenero(int id);

        string InsereGenero(GeneroDto GeneroDto);

        string AlteraGenero(GeneroDto GeneroDto);

        string DeleteGenero(int id);
    }
}

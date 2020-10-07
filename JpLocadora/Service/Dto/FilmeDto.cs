using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class FilmeDto
    {
        public int? Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string Sinopse { get; set; }
        public int Ano { get; set; }
        public int GeneroId { get; set; }
    }
}

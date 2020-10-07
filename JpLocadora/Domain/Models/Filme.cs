namespace Domain.Models
{
    public class Filme : Entidade
    {
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string Sinopse { get; set; }
        public int Ano { get; set; }
        public int GeneroId { get; set; }
        public virtual Genero Genero { get; set; }
    }
}

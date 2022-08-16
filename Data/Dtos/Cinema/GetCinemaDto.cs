using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos
{
    public class GetCinemaDto
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public Gerente Gerente { get; set; }    
    }
}

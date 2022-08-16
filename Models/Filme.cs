using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Filme
    {
        internal static Filme? filme;

        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo título é obrigatório")]//Obrigatorio informar um titulo
        public string Titulo { get; set; }
        [Required(ErrorMessage ="O campo diretor é obrigatório")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O genero não pode passar de 30 caracteres")]// Limitante de caracteres
        public string Genero { get; set; }
        [Range(1,600, ErrorMessage = "A duração deve ter no mínimo 1 minuto e no máximo 600 minutos")] //A duração deve estar entre 1 e 600
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}

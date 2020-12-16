using System.ComponentModel.DataAnnotations;
namespace bethehero_api.Models
{
    public class Incident
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Título do incidente é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A descrição do incidente é obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O valor do incidente é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="O valor deve ser maior que zero.")]
        public string Valor { get; set; }
        public int OngId { get; set;}

        public Ong Ong { get; set;}


       
    }
}

using System.ComponentModel.DataAnnotations;

namespace bethehero_api.Models
{
    public class Ong
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da ong é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail para contato é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Whatsapp para contato é obrigatório")]

        public string Whatsapp { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio")]

        public string City { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(2, ErrorMessage = "A sigla do estado deve ocnter duas casas.")]

        public string Uf { get; set; }
    }
}

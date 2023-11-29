using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projeto_final.Models
{
    [Table("Cidade")]
    public class Cidade_
    {
        [Column("CidadeId")]
        [Display(Name = "Código da cidade")]
        public int Id { get; set; }

        [Column("CidadeNome")]
        [Display(Name = "Nome da cidade")]
        public string CidadeNome { get; set; } = string.Empty;

        [ForeignKey("EstadoId")]
        [Display(Name = "Estado")]
        public int EstadoId { get; set;}
        public Estado? Estado { get; set;}
    }
}

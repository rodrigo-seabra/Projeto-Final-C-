using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projeto_final.Models
{
    [Table("Estado")]
    public class Estado
    {
        [Column("EstadoId")]
        [Display(Name = "Código do Estado")]
        public int Id { get; set; }

        [Column("EstadoNome")]
        [Display(Name = "Nome do Estado")]
        public string EstadoNome { get; set; } = string.Empty;

        [ForeignKey("PaisId")]
        [Display(Name = "País")]
        public int PaisId { get; set; }
        public Pais? Pais { get; set; }
    }
}

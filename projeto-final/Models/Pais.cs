using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projeto_final.Models
{
    [Table("Pais")]
    public class Pais
    {
        [Column("PaisId")]
        [Display(Name = "Código do país")]
        public int Id { get; set; }

        [Column("PaisNome")]
        [Display(Name = "Nome do país")]
        public string PaisNome { get; set; } = string.Empty;
    }
}

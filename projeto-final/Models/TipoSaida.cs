using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projeto_final.Models
{
    [Table("TipoSaida")]
    public class TipoSaida
    {
        [Column("TipoSaidaId")]
        [Display(Name = "Cód. do tipo de saida")]
        public int Id { get; set; }

        [Column("TipoSaidaDescricao")]
        [Display(Name = "Descrição da saida")]
        public string TipoSaidaDescricao { get; set; } = string.Empty;
    }
}

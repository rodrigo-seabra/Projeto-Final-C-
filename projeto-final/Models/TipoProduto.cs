using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projeto_final.Models
{
    [Table("TipoProduto")]
    public class TipoProduto
    {
        [Column("TipoProdutoId")]
        [Display(Name = "Cód. Tipo de Produto")]
        public int Id { get; set; }

        [Column("TipoProdutoDescricao")]
        [Display(Name = "Descrição do tipo de produto")]
        public string TipoProdutoDescricao { get; set; } = string.Empty;
    }
}

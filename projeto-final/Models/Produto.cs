using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projeto_final.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Column("ProdutoId")]
        [Display(Name = "Código do produto")]
        public int Id { get; set; }

        [Column("ProdutoNome")]
        [Display(Name = "Nome do produto")]
        public string ProdutoNome { get; set; } = string.Empty;

        [Column("ProdutoEstoque")]
        [Display(Name = "Quantidade de produtos em estoque")]
        public int ProdutoEstoque { get; set; }

        [ForeignKey("TipoProdutoId")]
        [Display(Name = "Tipo de produto")]
        public int TipoProdutoId { get; set; }
        public TipoProduto? TipoProduto { get; set; }

        [ForeignKey("FonecedorId")]
        [Display(Name = "Fornecedor")]
        public int FornecedorId { get; set; }
        public Fornecedor? Fornecedor { get; set; }
    }
}

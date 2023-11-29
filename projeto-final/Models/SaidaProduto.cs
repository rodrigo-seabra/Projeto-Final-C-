using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projeto_final.Models
{
    [Table("SaidaProduto")]
    public class SaidaProduto
    {
        [Column("SaidaProdutoId")]
        [Display(Name = "Cód. de saida dos produtos")]
        public int Id { get; set; }

        [Column("SaidaProdutoData")]
        [Display(Name = "Data de saida")]
        public DateTime SaidaProdutoData { get; set; }

        [Column("SaidaProdutoQuantidade")]
        [Display(Name = "Quantidade de saida")]
        public int SaidaProdutoQuantidade { get; set; }

        [ForeignKey("ProdutoId")]
        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        [ForeignKey("UsuarioId")]
        [Display(Name = "Usuário")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        [ForeignKey("ClienteId")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [ForeignKey("TipoSaidaId")]
        [Display(Name = "Tipo de saida")]
        public int TipoSaidaId { get; set;}
        public TipoSaida? TipoSaida { get; set;}


    }
}

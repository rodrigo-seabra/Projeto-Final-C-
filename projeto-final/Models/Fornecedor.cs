using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projeto_final.Models
{
    [Table("Fornecedor")]
    public class Fornecedor
    {
        [Column("FornecedorId")]
        [Display(Name = "Código do fornecedor")]
        public int Id { get; set; }

        [Column("FornecedorNome")]
        [Display(Name = "Nome do fornecedor")]
        public string FornecedorNome { get; set; } = string.Empty;

        [Column("FornecedorEmail")]
        [Display(Name = "Email do fornecedor")]
        public string FornecedorEmail { get; set; } = string.Empty;

        [Column("FornecedorCnpj")]
        [Display(Name = "CNPJ do fornecedor")]
        public string FornecedorCnpj { get; set; } = string.Empty;
    }
}

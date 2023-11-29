using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projeto_final.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Column("ClienteId")]
        [Display(Name = "Código do cliente")]
        public int Id { get; set; }

        [Column("ClienteNome")]
        [Display(Name = "Nome do cliente")]
        public string ClienteNome { get; set; } = string.Empty;

        [Column("ClienteDataNascimento")]
        [Display(Name = "Data de nascimento do cliente")]
        public DateTime ClienteDataNascimento { get; set; }

        [Column("ClienteCpf")]
        [Display(Name = "CPF do cliente")]
        public string ClienteCpf { get; set; } = string.Empty;

        [Column("ClienteEndereco")]
        [Display(Name = "Endereço do cliente")]
        public string ClienteEndereco { get; set; } = string.Empty;

        [Column("ClienteNumeroCasa")]
        [Display(Name = "Número da casa do cliente")]
        public string ClienteNumeroCasa {  get; set; } = string.Empty;

        [Column("ClienteBairro")]
        [Display(Name = "Bairro do cliente")]
        public string ClienteBairro {  get; set; } = string.Empty;

        [Column("ClienteCep")]
        [Display(Name = "CEP do cliente")]
        public string ClienteCep { get; set; } = string.Empty;

        [Column("ClienteTelefone")]
        [Display(Name = "Telefone do cliente")]
        public string ClienteTelefone {  get; set; } = string.Empty;

        [ForeignKey("CidadeId")]
        [Display(Name = "Cidade")]
        public int CidadeId {  get; set; }
        public Cidade? Cidade { get; set; }
    }
}

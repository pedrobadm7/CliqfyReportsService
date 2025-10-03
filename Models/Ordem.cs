using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CliqfyReportsService.Models
{
    [Table("ordem")]
    public class Ordem
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("cliente")]
        public string Cliente { get; set; } = string.Empty;

        [Column("descricao")]
        public string Descricao { get; set; } = string.Empty;

        [Column("status")]
        public string Status { get; set; } = string.Empty;

        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [Column("data_conclusao")]
        public DateTime? DataConclusao { get; set; }

        [Column("criado_por_id")]
        public Guid CriadoPorId { get; set; }

        [Column("responsavel_id")]
        public Guid? ResponsavelId { get; set; }
    }
}
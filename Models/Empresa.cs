using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace RotaLimpa.api.Models
{
    
    [Table("Empresa")]
    public class Empresa
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_Empresa")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("nome_empresa")]
        [Comment("Nome da empresa")]
        [NotNull]
        public string Nome { get; set; }

        [Required]
        [StringLength(14)]
        [Column("cnpj")]
        [NotNull]
        public string CNPJ { get; set; }

    }
}

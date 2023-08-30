using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RotaLimpa.api.Models
{
    [Index(nameof(Id), IsUnique = true)]
    [PrimaryKey(nameof(Id))]
    [Table("funcionario")]

    public class Funcionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_funcionario")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Empresa")]
        [Column("id_Empresa")]
        [NotNull]
        public int Id_Empresa { get; set; }
        public virtual Empresa Empresa { get; set; }

        [Required]
        [StringLength(100)]
        [Column("nome")]
        [NotNull]
        public string Nome { get; set; }

        [Required]
        [StringLength(14)]
        [Column("cpf")]
        [NotNull]
        public string CPF { get; set; }

        [Required]
        [StringLength(100)]
        [Column("tipo_funcionario")]
        [NotNull]
        public string Tipo_Funcionario { get; set; }
    }
}
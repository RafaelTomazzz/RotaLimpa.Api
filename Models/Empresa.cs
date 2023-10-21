using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Index(nameof(DcEmpresa), IsUnique = true)]
    [PrimaryKey(nameof(Id))]
    [Table("Empresa")]
    public class Empresa
    {
        public ICollection<Colaborador>? Colaboradores { get; set; }
        public ICollection<Setor>? Setores { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        [NotNull]
        public string? Nome { get; set; }

        [Required]
        [StringLength(18)]
        [Column("Dc_Empresa")]
        [Comment("CNPJ")]
        [NotNull]
        public string? DcEmpresa { get; set; }

        [Required]
        [Column("St_empresa")]
        [Comment("SITUAÇÃO DA EMPRESA")]
        [NotNull]
        public int StEmpresa { get; set; }

        [Required]
        [Column("Di_empresa")]
        [Comment("DATA DE INCLUSÃO")]
        [NotNull]
        public DateTime DiEmpresa { get; set; }

        [Required]
        [Column("Da_empresa")]
        [Comment("DATA DA ULTIMA ALTERAÇÃO")]
        [NotNull]
        public DateTime DaEmpresa { get; set; }

    }
}
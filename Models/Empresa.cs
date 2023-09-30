using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Index(nameof(Dc_Empresa), IsUnique = true)]
    [PrimaryKey(nameof(Id))]
    [Table("Empresas")]
    public class Empresa
    {
        public ICollection<Colaborador>? Colaboradores { get; set; }
        public ICollection<Setor>? Setores { get; set; }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        [Column("Nome")]
        [NotNull]
        public string? Nome { get; set; }

        [Required]
        [StringLength(18)]
        [Column("dc_empresa")]
        [Comment("CNPJ")]
        [NotNull]
        public string? Dc_Empresa { get; set; }

        [Required]
        [Column("st_empresa")]
        [Comment("SITUAÇÃO DA EMPRESA")]
        [NotNull]
        public int St_Empresa { get; set; }

        [Required]
        [Column("di_empresa")]
        [Comment("DATA DE INCLUSÃO")]
        [NotNull]
        public DateTime Di_Empresa { get; set; }

        [Required]
        [Column("da_empresa")]
        [Comment("DATA DA ULTIMA ALTERAÇÃO")]
        [NotNull]
        public DateTime Da_Empresa { get; set; }
        
        
        
    }
}
using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Index(nameof(id), IsUnique = true)]
    [PrimaryKey(nameof(id))]
    [Table("Colaboradores")]
    public class Colaboradores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id {get; set; }

        //public Empresas Id_Empresa { get; set; }

        [Required]
        [StringLength(40)]
        [Column("nome")]
        [NotNull]
        public string Nome { get; set;}

        [Required]
        [StringLength(14)]
        [Column("dcColaborador")]
        [Comment("CPF do colaborador")]
        [NotNull]
        public string Dc_Colaborador { get; set; }
        
        [Required]
        [StringLength(1)]
        [Column("stColaborador")]
        [Comment("Setor do colaborador")]
        public string St_Colaborador { get; set; }    
        }
}
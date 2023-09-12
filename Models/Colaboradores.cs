using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.Models
{
    [Index(nameof(Id), IsUnique = true)]
    [PrimaryKey(nameof(Id))]
    [Table("Colaboradores")]
    public class Colaboradores
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id {get; set; }

        [Required]
        [ForeignKey("Empresas")]
        [Column("Id_Empresa")]
        [NotNull]
        public Empresas Empresa_Id { get; set; }
        public virtual Empresas Empresas { get; set; }

        [Required]
        [StringLength(60)]
        [Column("Nome")]
        [NotNull]
        public string Nome { get; set;}

        [Required]
        [StringLength(14)]
        [Column("dbColaborador")]
        [NotNull]
        public string Dc_Colaborador { get; set; }
        
        [Required]
        [StringLength(1)]
        [Column("stColaborador")]
        public string St_Colaborador { get; set; }    
        }
}
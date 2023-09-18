using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Index(nameof(Id), IsUnique = true)]
    [PrimaryKey(nameof(Id))]
    [Table("Colaboradores")]
    public class Colaborador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id {get; set; }

        [Required]
        [ForeignKey("idEmpresa")]
        public int Empresa_Id { get; set; }
        public virtual Empresa Empresas { get; set; }

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
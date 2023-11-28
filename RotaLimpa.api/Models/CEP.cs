using System;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RotaLimpa.Api.Models
{
    [Table("CEP")]
    [PrimaryKey(nameof(Id))]
    public class CEP
    {
        public ICollection<Rua>? Ruas { get; set; }
        public ICollection<Ocorrencia>? Ocorrencias { get; set; }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Cep")]
        [StringLength(8)]
        public string Cep { get; set; }

        [Required]
        [StringLength(25)]
        [Column("Logradouro")]
        public string Logradouro { get; set; }
        
        [Required]
        [StringLength(60)]
        [Column("Endereço")]
        public string Endereco { get; set; }
        
        [Required]
        [StringLength(35)]
        [Column("Bairro")]
        public string Bairro { get; set; }

        [Required]
        [StringLength(35)]
        [Column("Cidade")]
        public string Cidade { get; set; }

        [Required]
        [StringLength(2)]
        [Column("UF", TypeName="CHAR")]
        public string UF { get; set; }

        [Required]
        [StringLength(25)]
        [Column("latitude")]
        public string Latitude { get; set; }
        
        [Required]
        [StringLength(25)]
        [Column("longitude")]
        public string Longitude { get; set; }
    }
}

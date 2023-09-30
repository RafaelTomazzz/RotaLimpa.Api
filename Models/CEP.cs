using System;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
=======
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
>>>>>>> origin/Rafael

namespace RotaLimpa.Api.Models
{
    [Index(nameof(Id_Cep), IsUnique = true)]
    [PrimaryKey(nameof(Id_Cep))]
    [Table("CEP")]
    [PrimaryKey(nameof(Cep))]
    public class CEP
    {
<<<<<<< HEAD

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idCep")]
        [NotNull]
        public int Id_Cep { get; set; }

        [Required]
        [StringLength(8)]
        [Column("cep")]
=======
        public ICollection<Rua>? Ruas { get; set; }
        
        [Key]
        [Column("Cep")]
        [StringLength(8)]
>>>>>>> origin/Rafael
        public string Cep { get; set; }

        [Required]
        [StringLength(25)]
        [Column("Logradouro")]
        public string Logradouro { get; set; }
<<<<<<< HEAD

=======
        
>>>>>>> origin/Rafael
        [Required]
        [StringLength(60)]
        [Column("endereço")]
        public string Endereco { get; set; }
<<<<<<< HEAD

=======
        
>>>>>>> origin/Rafael
        [Required]
        [StringLength(35)]
        [Column("bairro")]
        public string Bairro { get; set; }

        [Required]
        [StringLength(35)]
        [Column("cidade")]
        public string Cidade { get; set; }

        [Required]
        [StringLength(2)]
        [Column("uf")]
        public string UF { get; set; }

        [Required]
        [StringLength(25)]
        [Column("latitude")]
        public string Latitude { get; set; }
<<<<<<< HEAD

=======
        
>>>>>>> origin/Rafael
        [Required]
        [StringLength(25)]
        [Column("longitude")]
        public string Longitude { get; set; }
    }
}

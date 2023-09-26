using System;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RotaLimpa.Api.Models
{
    [Table("CEP")]
    [PrimaryKey(nameof(Cep))]
    public class CEP
    {
        public ICollection<Rua>? Ruas { get; set; }
        
        [Key]
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}

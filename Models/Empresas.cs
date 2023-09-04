using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Table("Empresas")]
    public class Empresas
    {
        [Key]
        public int Id_Empresa { get; set; }
        public string nmEmpresa { get; set; }
        public string dcEmpresa { get; set; }
        public int stEmpresa { get; set; }
        public DateTime diEmpresa { get; set; }
        public DateTime daEmpresa { get; set; }
        
        
        
    }
}
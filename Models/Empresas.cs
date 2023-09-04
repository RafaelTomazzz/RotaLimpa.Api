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
        public string Nm_Empresa { get; set; }
        public string Dc_Empresa { get; set; }
        public int St_Empresa { get; set; }
        public DateTime Di_Empresa { get; set; }
        public DateTime Da_Empresa { get; set; }
        
        
        
    }
}
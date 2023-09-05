using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Table("Colaboradores")]
    public class Colaboradores
    {
        [Key]
        public int Id_Colaborador {get; set; }
        public Empresas Id_Empresa { get; set; }
        public string Nm_Colaborador { get; set;}
        public string Dc_Colaborador { get; set; }
        public string St_Colaborador { get; set; }    }
}
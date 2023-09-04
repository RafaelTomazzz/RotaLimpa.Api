using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RotaLimpa.Api.Models;

namespace RotaLimpa.api.Models
{
    [Table("Colaboradores")]
    public class Colaboradores
    {
        [Key]
        public int Id_Colaboradores {get; set; }
        public Empresas Id_Empresa { get; set; }
        public string nmColaborador { get; set;}
        public string dcColaborador { get; set; }
        public string stColaborador { get; set; }    }
}
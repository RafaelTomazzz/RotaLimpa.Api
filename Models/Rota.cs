using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RotaLimpa.Api.Models
{
    [Table("Rotas")]
    [PrimaryKey(nameof(Id))]
    public class Rota
    {
        [Key]
        public int Id { get; set; }
        public Colaborador Id_Colaborador { get; set; }
        public Periodo Id_Periodo { get; set; }
        public Setor Id_Setor { get; set; }
        public int Dt_Rota { get; set; }
        public int Tm_Rota { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace RotaLimpa.Api.Models
{
    [Table("HistoLonginMotorista")]
    [PrimaryKey(nameof(Id))]
    public class HisLoginM
    {
        [Key]
        [Column("Historico_Login")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Id_Motorista")]
        public int IdMotorista { get; set; }
        [NotMapped]
        public Motorista Motorista { get; set; }

        public DateTime DataHora { get; set; } = DateTime.Now;

    }
}

using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Index(nameof(Id), IsUnique = true)]
    [PrimaryKey(nameof(Id))]
    [Table("Colaborador")]
    public class Colaborador
    {
        public ICollection<Setor>? Setores { get; set; }
        public ICollection<Rota>? Rotas { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int EmpresaId { get; set; }
        [NotMapped]
        public Empresa Empresa { get; set; }

        [Required]
        [StringLength(60)]
        [NotNull]
        public string Nome { get; set; }

        [Required]
        [StringLength(14)]
        [NotNull]
        public string DcColaborador { get; set; }

        [Required]
        [StringLength(1)]
        public string StColaborador { get; set; }

        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] Foto { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? DataAcesso { get; set; }
        [NotMapped] // using System.ComponentModel.DataAnnotations.Schema
        public string PasswordString { get; set; }
        public List<Colaborador> Colaboradores { get; set; }//using System.Collections.Generic;
        public string Perfil { get; set; }
        public string Email { get; set; }

        [NotMapped]
        public string Token {get;set;}
        
    }
}
using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RotaLimpa.Api.DTO;
using RotaLimpa.Api.DTO.Builder;

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
        public Empresa? Empresa { get; set; }

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
        public string StColaborador { get; set; } = "1";

        public Colaborador()
        {}

        public Colaborador(int id)
        {
            Id = id;
        }
        public Colaborador(int id, int empresaId)
        {
            Id = id;
            EmpresaId = empresaId; 
        }

        public Colaborador(int id, int empresaId, string nome)
        {
            Id = id;
            EmpresaId = empresaId; 
            Nome = nome;
        }
        public Colaborador(int id, int empresaId, string nome, string dc)
        {
            Id = id;
            EmpresaId = empresaId; 
            Nome = nome;
            DcColaborador = dc;
        }

        public ColaboradorDTO ToColaborador()
        {
            ColaboradorDTO colaboradorDTO = new ColaboradorDTOBuilder()
                .WithId(Id)
                .WithEmpresaId(EmpresaId)
                .WithDc(Nome)
                .WithDc(DcColaborador)
                .Builder();
            
            return colaboradorDTO;
        }
    }
}
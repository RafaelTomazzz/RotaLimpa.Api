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
        public ICollection<HisLoginC>? HisLoginCs { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Id_Empresa")]
        public int IdEmpresa { get; set; }
        [NotMapped]
        public Empresa? Empresa { get; set; }

        [Required]
        [StringLength(20)]
        [Column("Primeiro_Nome")]
        [NotNull]
        public string PNome { get; set; }

        [Required]
        [StringLength(20)]
        [Column("Sobre_Nome")]
        [NotNull]
        public string SNome { get; set; }

        [Comment("Data de inserção do Colaborador")]
        [Column("Di_Colaborador")]
        public DateTime Di_Colaborador { get; set; } = DateTime.Now;

        [Required]
        [Column("St_Colaborador")]
        [StringLength(1)]
        public string StColaborador { get; set; } = "1";

<<<<<<< HEAD
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
=======
        [Required]
        [Column("CPF")]
        [StringLength(15)]
        [NotNull]
        public string Cpf { get; set; }

        [Required]
        [Column("RG")]
        [StringLength(15)]
        [NotNull]
        public string Rg { get; set; }

        private string Chave { get; set; }
        private string IV { get; set; }

        [Required]
        [Column("Login")]
        [StringLength(7)]
        [NotNull]
        public string Login { get; set; }

        [Required]
        [Column("Senha")]
        [StringLength(12)]
        [NotNull]
        public string Senha { get; set; }
>>>>>>> c49f4579b08f8aa3e7038406c689384e2329085d
    }
}
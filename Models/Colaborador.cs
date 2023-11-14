using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotaLimpa.Api.Models
{
    [Index(nameof(IdColaborador), IsUnique = true)]
    [PrimaryKey(nameof(IdColaborador))]
    [Table("Colaborador")]
    public class Colaborador
    {
        public ICollection<Setor>? Setores { get; set; }
        public ICollection<Rota>? Rotas { get; set; }
        public ICollection<HisLoginC>? HisLoginCs { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_Colaborador")]
        public int IdColaborador { get; set; }

        [Required]
        [ForeignKey("Id_Empresa")]
        public int IdEmpresa { get; set; }

        [NotMapped]
        public Empresa Empresa { get; set; }

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
    }
}
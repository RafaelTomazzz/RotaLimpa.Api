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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_Colaborador")]
        public int IdColaborador { get; set; }

        [Required]
        [ForeignKey("Id_Empresa")]
        public int EmpresaId { get; set; }

        [NotMapped]
        public Empresa Empresa { get; set; }

        [Required]
        [StringLength(60)]
        [NotNull]
        public string Nome { get; set; }

        [Comment("Data de inserção do Motorista")]
        [Column("Di_Motorista")]
        public DateTime Di_Colaborador { get; set; } = DateTime.Now;

        [Required]
        [Column("St_Colaborador")]
        [StringLength(1)]
        public string StColaborador { get; set; }

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

        public string Chave { get; set; }
        public string IV { get; set; }

        [Required]
        [Column("Login")]
        [StringLength(20)]
        [NotNull]
        public string Login { get; set; }

        [Required]
        [Column("Senha")]
        [StringLength(12)]
        [NotNull]
        public string Senha { get; set; }

        [Required]
        [Column("Historico_Login")]
        [StringLength(25)]
        [NotNull]
        public string His_Login { get; set; }
    }
}
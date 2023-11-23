using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RotaLimpa.Api.DTO;
using RotaLimpa.Api.DTO.Builder;

namespace RotaLimpa.Api.Models
{
    [Index(nameof(DcEmpresa), IsUnique = true)]
    [PrimaryKey(nameof(Id))]
    [Table("Empresa")]
    public class Empresa
    {
        public ICollection<Colaborador>? Colaboradores { get; set; }
        public ICollection<Setor>? Setores { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        [NotNull]
        public string? Nome { get; set; }

        [Required]
        [StringLength(18)]
        [Column("Dc_Empresa")]
        [Comment("CNPJ")]
        [NotNull]
        public string? DcEmpresa { get; set; }

        [Required]
        [Column("St_empresa")]
        [Comment("SITUAÇÃO DA EMPRESA")]
        [NotNull]
        public string StEmpresa { get; set; } = "1";

        [Required]
        [Column("Di_empresa")]
        [Comment("DATA DE INCLUSÃO")]
        [NotNull]
        public DateTime DiEmpresa { get ; private set ; } = DateTime.Now;

        [Required]
        [Column("Da_empresa")]
        [Comment("DATA DA ULTIMA ALTERAÇÃO")]
        public DateTime? DaEmpresa { get; set; } = DateTime.Now;

        public Empresa() 
        { }

        public Empresa(int id)
        {
            Id = id;
        }

        public Empresa(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Empresa(int id, string nome, string dcEmpresa)
        {
            Id = id;
            Nome = nome;
            DcEmpresa = dcEmpresa;
        }
        
        public EmpresaDTO ToEmpresa()
        {
            EmpresaDTO empresaDTO = new EmpresaDTOBuilder()
                .WithId(Id) 
                .WithNome(Nome)
                .WithDcEmpresa(DcEmpresa)
                .Build();
            return empresaDTO;
        }
        
    }
}
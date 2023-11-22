using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RotaLimpa.Api.Models.Enum;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.DTO;
using RotaLimpa.Api.DTO.Builder;

namespace RotaLimpa.Api.Models
{
    [Table("Setor")]
    [PrimaryKey(nameof(Id))]
    public class Setor
    {
        public ICollection<Rota>? Rotas { get; set; }
        public ICollection<RelatorioFinal>? RelatoriosFinais { get; set; }
        public ICollection<SetorVeiculo>? SetorVeiculos { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Id_Colaborador")]
        public int IdColaborador { get; set; }
        public Colaborador? Colaborador { get; set; }
        
        [Required]
        [ForeignKey("Id_Empresa")]
        public int IdEmpresa { get; set; }
        [NotMapped]
        public Empresa? Empresa { get; set; }

        public TiposServico TipoServico { get; set; }
        [Column("Di_Setor")]
        public DateTime DiSetor { get; private set; } = DateTime.Now;
        [Column("Da_Setor")]
        public DateTime? DaSetor { get; set; }
        [Column("St_Setor")]
        public string StSetor { get; set; } = "1";

                public Setor()
        {}

        public Setor(int id)
        {
            Id = id;
        }
        public Setor(int id, int idcolaborador)
        {
            Id = id;
            IdColaborador = idcolaborador;
        }
        public Setor(int id, int idcolaborador, int idempresa)
        {
            Id = id;
            IdColaborador = idcolaborador;
            IdEmpresa = idempresa;
        }
        public Setor(int id, int idcolaborador, int idempresa, TiposServico tipoServico)
        {
            Id = id;
            IdColaborador = idcolaborador;
            IdEmpresa = idempresa;
            TipoServico = tipoServico;
        }
        public SetorDTO ToSetor()
        {
            SetorDTO setorDTO = new SetorDTOBuilder()
                .WithId(Id)
                .WithIdColaborador(IdColaborador)
                .WithIdEmpresa(IdEmpresa)
                .WithTipoServico(TipoServico)
                .Build();
            return setorDTO;
        }
    }
}

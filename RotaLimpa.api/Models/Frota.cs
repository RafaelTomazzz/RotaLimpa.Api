using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.DTO;
using RotaLimpa.Api.DTO.Builder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RotaLimpa.Api.Models
{
    [Table("Frota")]
    public class Frota
    {
        public ICollection<SetorVeiculo>? SetorVeiculos { get; set; }
        public ICollection<Trajeto>? Trajetos { get; set; } 
        [Key]
        [Column("Id")]
        public int IdVeiculo { get; set; }
        [Comment("placa do veiculo")]
        [Column("P_Veiculo")]
        [StringLength(9)]
        public string PVeiculo { get; set; }
        [Comment("Tamanho do ve�culo")]
        [Column("Tmn_Veiculo")]
        public double TmnVeiculo { get; set; }
        [Column("Di_Veiculo")]
        public DateTime DiVeiculo { get; set; } = DateTime.Now;
        [Column("St_Veiculo")]
        public string StVeiculo { get; set; } = "1";
        public Kilometragem? Kilometragem { get; internal set; }

        public Frota()
        {
        }

        public Frota(int idveiculo)
        {
            IdVeiculo = idveiculo;
        }

        public Frota(int idveiculo, string placa)
        {
            IdVeiculo = idveiculo;
            PVeiculo = placa;
        }

        public Frota(int idveiculo, string placa, double tamanho)
        {
            IdVeiculo = idveiculo;
            PVeiculo = placa;
            TmnVeiculo = tamanho;
        }

        public Frota(int idveiculo, string placa, double tamanho, Kilometragem kilometragem)
        {
            IdVeiculo = idveiculo;
            PVeiculo = placa;
            TmnVeiculo = tamanho;
            Kilometragem = kilometragem;
        }

        public FrotaDTO ToFrota()
        {
            FrotaDTO frotaDTO = new FrotaDTOBuilder()
            .WithId(IdVeiculo)
            .WithPlaca(PVeiculo)
            .WithTamanho(TmnVeiculo)
            .WithKilometragem(Kilometragem)
            .Build();

            return frotaDTO;
        }
    }
}

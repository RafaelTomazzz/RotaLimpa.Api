using RotaLimpa.Api.Models;

namespace RotaLimpa.Api.DTO
{
    public class FrotaDTO
    {
        public int IdVeiculo { get; set; }
        public string PVeiculo { get; set; }
        public double TmnVeiculo { get; set; }
        public Kilometragem Kilometragem { get; set; }
    }
}
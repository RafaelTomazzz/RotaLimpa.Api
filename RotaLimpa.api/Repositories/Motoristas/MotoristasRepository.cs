using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories.Interfaces;

namespace RotaLimpa.Api.Repositories
{
    public class MotoristasRepository : IMotoristasRepository
    {
        private readonly DataContext _context;
        public MotoristasRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Motorista>> GetAllMotoristasAsync()
        {
            IEnumerable<Motorista> motorista = await _context.Motoristas.ToListAsync();
            return motorista;
        }

        public async Task<Motorista> GetMotoristaByIdAsync(int id)
        {
            return await _context.Motoristas.FirstOrDefaultAsync(m => m.Id == id);
        }
        
        public async Task CreateMotoristaAsync(Motorista motorista)
        {
            await _context.AddAsync(motorista);
        }

        public async Task RemoveMotorista(Motorista motorista)
        {
            _context.Motoristas.Remove(motorista);
        }

        public async Task<int> ObterUltimoNumeroLoginAsync()
        {
            List<int> listaDeLogin = await _context.Motoristas
                .Select(m => int.Parse(m.Login.Substring(0, 3)))
                .ToListAsync();

            int MaxLogin = listaDeLogin.Max();


            return MaxLogin;
        }

        public async Task<Motorista> GetMotoristaByCPFAsync(string cpf)
        {
            return await _context.Motoristas.FirstOrDefaultAsync(m => m.Cpf == cpf);
        }

        public async Task<DateTime> BuscarUltimaCriacao()
        {
            DateTime ultimaDate = await _context.Motoristas.MaxAsync(m => m.Di_Motorista);
            return ultimaDate;
        }
    }
}

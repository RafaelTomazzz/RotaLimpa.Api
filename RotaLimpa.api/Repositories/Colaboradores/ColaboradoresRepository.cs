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
    public class ColaboradoresRepository : IColaboradoresRepository
    {
        private readonly DataContext _context;
        public ColaboradoresRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Colaborador>> GetAllColaboradoresAsync()
        {
            IEnumerable<Colaborador> colaborador = await _context.Colaboradores.ToListAsync();
            return colaborador;
        }

        public async Task<Colaborador> GetColaboradorByIdAsync(int id)
        {
            return await _context.Colaboradores.FirstOrDefaultAsync(f => f.Id == id);
        }
        
        public async Task CreateColaboradorAsync(Colaborador colaborador)
        {
            await _context.AddAsync(colaborador);
        }

        public async Task RemoveColaborador(Colaborador colaborador)
        {
            _context.Colaboradores.Remove(colaborador);
        }

        public async Task<int> ObterUltimoNumeroLoginAsync()
        {
            List<int> listaDeLogin = await _context.Colaboradores
                .Select(m => int.Parse(m.Login.Substring(0, 3)))
                .ToListAsync();

            int MaxLogin = listaDeLogin.Max();


            return MaxLogin;
        }

        public async Task<Colaborador> GetColaboradorByCPFAsync(string cpf)
        {
            return await _context.Colaboradores.FirstOrDefaultAsync(f => f.Cpf == cpf);
        }

        public async Task<DateTime> BuscarUltimaCriacao()
        {
            DateTime ultimaDate = await _context.Colaboradores.MaxAsync(m => m.Di_Colaborador);
            return ultimaDate;
        }

    }
}

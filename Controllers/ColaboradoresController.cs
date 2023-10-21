using System;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RpgApi.Utils;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace RotaLimpa.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ColaboradoresController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public ColaboradoresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Colaborador> lista = await _context.Colaboradores.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Colaborador novocolaborador)
        {
            try
            {
                if (string.IsNullOrEmpty(novocolaborador.DcColaborador))
                {
                    return BadRequest("A descrição do colaborador é obrigatória.");
                }

                await _context.Colaboradores.AddAsync(novocolaborador);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetById", new { id = novocolaborador.Id }, novocolaborador);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }


        private string CriarToken(Colaborador colaborador)
        {
            List<Claim> claims = new List<Claim>
        {
        new Claim(ClaimTypes.NameIdentifier, colaborador.Id.ToString()),
        new Claim(ClaimTypes.Name, colaborador.Username)
        };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("ConfiguracaoToken:Chave").Value));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private async Task<bool> ColaboradorExistente(string username)
        {
            if (await _context.Colaboradores.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarColaborador(Colaborador user)
        {
            try
            {
                if (await ColaboradorExistente(user.Username))
                    throw new System.Exception("Nome de colaborador já existe");

                // Chame CriarPasswordHash para criar o hash da senha
                Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);

                user.PasswordString = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;

                await _context.Colaboradores.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [AllowAnonymous]
        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarColaborador(Colaborador credenciais)
        {
            try
            {
                Colaborador colaborador = await _context.Colaboradores
                    .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if (colaborador == null)
                {
                    throw new System.Exception("Colaborador não encontrado.");
                }
                else if (!Criptografia.VerificarPasswordHash(credenciais.PasswordString, colaborador.PasswordHash, colaborador.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else
                {
                    colaborador.DataAcesso = System.DateTime.Now;
                    _context.Colaboradores.Update(colaborador);
                    await _context.SaveChangesAsync(); // Confirma a alteração no banco

                    colaborador.PasswordHash = null;
                    colaborador.PasswordSalt = null;
                    colaborador.Token = CriarToken(colaborador);
                    return Ok(colaborador);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Método para alteração de Senha.
        [HttpPut("AlterarSenha")]
        public async Task<IActionResult> AlterarSenhaUsuario(Colaborador credenciais)
        {
            try
            {
                Colaborador colaborador = await _context.Colaboradores //Busca o usuário no banco através do login
                   .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if (colaborador == null) //Se não achar nenhum usuário pelo login, retorna mensagem.
                    throw new System.Exception("Usuário não encontrado.");

                Criptografia.CriarPasswordHash(credenciais.PasswordString, out byte[] hash, out byte[] salt);
                colaborador.PasswordHash = hash; //Se o usuário existir, executa a criptografia (linha 122)
                colaborador.PasswordSalt = salt; //guardando o hash e o salt nas propriedades do usuário (linhas 123/124)

                _context.Colaboradores.Update(colaborador);
                int linhasAfetadas = await _context.SaveChangesAsync(); //Confirma a alteração no banco
                return Ok(linhasAfetadas); //Retorna as linhas afetadas (Geralmente sempre 1 linha msm)
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

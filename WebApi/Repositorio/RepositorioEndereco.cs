using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Contexto;
using WebApi.Entidades;
using WebApi.Interfaces;


namespace WebApi.Repositorio
{
    public class RepositorioEndereco : IEndereco
    {

        private readonly DbContextOptions<Context> _optionsBuilder;

        public RepositorioEndereco()
        {
            _optionsBuilder = new DbContextOptions<Context>();
        }


        public async Task AtualizacaoEndereco(Endereco Endereco)
        {
            using (var banco = new Context(_optionsBuilder))
            {
                banco.Endereco.Update(Endereco);
                await banco.SaveChangesAsync();
            }
        }


        public async Task DeletarEndereco(int IdEndereco)
        {
            using (var banco = new Context(_optionsBuilder))
            {
                var Endereco = await banco.Endereco.FindAsync(IdEndereco);
                banco.Endereco.Remove(Endereco);
                await banco.SaveChangesAsync();
            }
        }

        public async Task CadastroEndereco(Endereco Endereco)
        {
            using (var banco = new Context(_optionsBuilder))
            {
                await banco.Endereco.AddAsync(Endereco);
                await banco.SaveChangesAsync();
            }
        }

        public async Task<Endereco> ConsultarEnderecoPorId(int IdEndereco)
        {
            using (var banco = new Context(_optionsBuilder))
            {
                var Endereco = await banco.Endereco.FindAsync(IdEndereco);
                return Endereco;
            }
        }

        public async Task<Endereco> ConsultarEnderecoPorNome(string Logradouro)
        {
            using (var banco = new Context(_optionsBuilder))
            {
                var Endereco = await banco.Endereco.Where(c => c.Logradouro.Contains(Logradouro)).FirstOrDefaultAsync();
                return Endereco;
            }
        }


        public async Task<List<Endereco>> ListarEnderecos()
        {
            using (var banco = new Context(_optionsBuilder))
            {
                var Endereco = await banco.Endereco.ToListAsync();
                return Endereco;
            }
        }
    }
}

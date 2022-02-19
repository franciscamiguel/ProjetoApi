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
    public class RepositorioCliente : ICliente
    {

        private readonly DbContextOptions<Context> _optionsBuilder;

        public RepositorioCliente()
        {
            _optionsBuilder = new DbContextOptions<Context>();
        }


        public async Task AtualizacaoCliente(Cliente cliente)
        {          
            using (var banco = new Context(_optionsBuilder))
            {         
                banco.Cliente.Update(cliente);
                await banco.SaveChangesAsync();
            }
        }


        public async Task DeletarCliente(int IdCliente)
        {
            using (var banco = new Context(_optionsBuilder))
            {
                var cliente = await banco.Cliente.FindAsync(IdCliente);
                banco.Cliente.Remove(cliente);
                await banco.SaveChangesAsync();
            }
        }

        public async Task CadastroCliente(Cliente cliente)
        {           
            using (var banco = new Context(_optionsBuilder))
            {             
                await banco.Cliente.AddAsync(cliente);

                await banco.SaveChangesAsync();

                foreach (var endereco in cliente.Enderecos)
                {
                    endereco.ClientId = cliente.Id;
                    await banco.Endereco.AddAsync(endereco);
                }

                await banco.SaveChangesAsync();
            }
        }

        public async Task<Cliente> ConsultarClientePorId(int IdCliente)
        {
            using (var banco = new Context(_optionsBuilder))
            {
                var cliente = await banco.Cliente.FindAsync(IdCliente);
                var listaEnderecoCliente = await banco.Endereco.Where(c => c.ClientId.Equals(cliente.Id)).ToListAsync();

                    cliente.Enderecos = new List<Endereco>();
                    cliente.Enderecos.AddRange(listaEnderecoCliente);
            
                return cliente;
            }
        }

        public async Task<Cliente> ConsultarClientePorNome(string Nome)
        {
            using (var banco = new Context(_optionsBuilder))
            {
                var cliente = await banco.Cliente.Where(c=>c.Nome.Contains(Nome)).FirstOrDefaultAsync();
                var listaEnderecoCliente = await banco.Endereco.Where(c => c.ClientId.Equals(cliente.Id)).ToListAsync();
              
                    cliente.Enderecos = new List<Endereco>();
                    cliente.Enderecos.AddRange(listaEnderecoCliente);
               
                return cliente;
            }
        }


        public async Task<List<Cliente>> ListarClientes()
        {
            using (var banco = new Context(_optionsBuilder))
            {
                var cliente = await banco.Cliente.ToListAsync();
                return cliente;
            }
        }   
    }
}

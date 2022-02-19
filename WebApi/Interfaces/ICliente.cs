using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entidades;


namespace WebApi.Interfaces
{
    public interface ICliente
    {
        Task CadastroCliente(Cliente cliente);

        Task AtualizacaoCliente(Cliente cliente);
             
        Task DeletarCliente(int IdCliente);

        Task<List<Cliente>> ListarClientes();

        Task<Cliente> ConsultarClientePorId(int IdCliente);

        Task<Cliente> ConsultarClientePorNome(string Nome);



    }
}

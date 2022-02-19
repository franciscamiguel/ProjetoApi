using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entidades;


namespace WebApi.Interfaces
{
    public interface IEndereco
    {
        Task CadastroEndereco(Endereco Endereco);

        Task AtualizacaoEndereco(Endereco Endereco);
             
        Task DeletarEndereco(int IdEndereco);

        Task<List<Endereco>> ListarEnderecos();

        Task<Endereco> ConsultarEnderecoPorId(int IdEndereco);

        Task<Endereco> ConsultarEnderecoPorNome(string Logradouro);



    }
}

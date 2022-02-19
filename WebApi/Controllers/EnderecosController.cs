using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entidades;
using WebApi.Interfaces;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {

        public readonly IEndereco _IEndereco;

        public EnderecosController(IEndereco Endereco)
        {
            _IEndereco = Endereco;
        }


        [HttpPost("/CadastroEndereco")]

        public async Task CadastroEndereco(Endereco Endereco)
        {
            await _IEndereco.CadastroEndereco(Endereco);
        }

        [HttpPost("/AtualizacaoEndereco")]

        public async Task AtualizacaoEndereco(Endereco Endereco)
        {
            await _IEndereco.AtualizacaoEndereco(Endereco);
        }

        [HttpPost("/DeletarEndereco")]
        public async Task DeletarEndereco(int idEndereco)
        {
            await _IEndereco.DeletarEndereco(idEndereco);
        }


        [HttpGet("/ConsultarEnderecoPorId")]
        public async Task<Endereco> ConsultarEnderecoPorId(int idEndereco)
        {
            return await _IEndereco.ConsultarEnderecoPorId(idEndereco);
        }

        [HttpGet("/ConsultarEnderecoPorNome")]
        public async Task<Endereco> ConsultarEnderecoPorNome(string logradouro)
        {
           return  await _IEndereco.ConsultarEnderecoPorNome(logradouro);
        }

        [HttpGet("/ListarEnderecos")]
        public async Task<List<Endereco>> ListarEnderecos()
        {
          return await _IEndereco.ListarEnderecos();
        }




    }
}

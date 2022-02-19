using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entidades;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        public readonly ICliente _ICliente;
        public readonly IMapper _mapper;

        public ClientesController(ICliente cliente, IMapper mapper)
        {
            _ICliente = cliente;
            _mapper = mapper;
        }


        [HttpPost("/CadastroCliente")]

        public async Task CadastroCliente(ClienteViewModel cliente)
        {
            var clienteMap = _mapper.Map<Cliente>(cliente);

            await _ICliente.CadastroCliente(clienteMap);
        }

        [HttpPost("/AtualizacaoCliente")]

        public async Task AtualizacaoCliente(ClienteUpdateViewModel cliente)
        {
            var clienteMap = _mapper.Map<Cliente>(cliente);

            await _ICliente.AtualizacaoCliente(clienteMap);
        }

        [HttpPost("/DeletarCliente")]
        public async Task DeletarCliente(int idCliente)
        {
            await _ICliente.DeletarCliente(idCliente);
        }


        [HttpGet("/ConsultarClientePorId")]
        public async Task<Cliente> ConsultarClientePorId(int idCliente)
        {
           return  await _ICliente.ConsultarClientePorId(idCliente);
        }

        [HttpGet("/ConsultarClientePorNome")]
        public async Task<Cliente> ConsultarClientePorNome(string nome)
        {
            return await _ICliente.ConsultarClientePorNome(nome);
        }

        [HttpGet("/ListarClientes")]
        public async Task<List<Cliente>> ListarClientes()
        {
            return await _ICliente.ListarClientes();
        }




    }
}

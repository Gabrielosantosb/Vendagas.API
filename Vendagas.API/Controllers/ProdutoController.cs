﻿using Microsoft.AspNetCore.Mvc;
using Vendagas.API.Application.Services.Empresa;
using Vendagas.API.Application.Services.Produto;
using Vendagas.API.ORM.Model.Empresa;
using Vendagas.API.ORM.Model.Produto;

namespace Vendagas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }




        [HttpGet("get-all-produtos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllEmpresas()
        {
            try
            {
                var produtos = _produtoService.GetAllProdutos();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar empresas: {ex.Message}");
            }
        }


        [HttpPost("create-produto/{empresaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateEmpresa(int empresaId, ProdutoModelRequest produtoRequest)
        {
            try
            {
                var newProduto = _produtoService.CreateProduto(empresaId, produtoRequest);
                return Ok(newProduto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar produto: {ex.Message}");
            }
        }
    }
}
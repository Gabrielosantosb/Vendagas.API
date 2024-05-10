using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vendagas.API.Application.Services.Empresa;
using Vendagas.API.ORM.Entity;
using Vendagas.API.ORM.Model.Empresa;

namespace Vendagas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService ?? throw new ArgumentNullException(nameof(empresaService));
        }

        [HttpGet("get-all-empresas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllEmpresas()
        {
            try
            {
                var empresas = _empresaService.GetAllEmpresas();
                return Ok(empresas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar empresas: {ex.Message}");
            }
        }

        [HttpPost("create-empresa/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateEmpresa(int userId, CreateEmpresaModel empresa)
        {
            try
            {
                var novaEmpresa = _empresaService.CreateEmpresa(userId, empresa);
                return CreatedAtAction(nameof(GetEmpresaById), new { id = novaEmpresa.EmpresaId }, novaEmpresa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar empresa: {ex.Message}");
            }
        }

        [HttpGet("get-empresa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetEmpresaById(int id)
        {
            try
            {
                var empresa = _empresaService.GetEmpresaById(id);
                if (empresa == null)
                {
                    return NotFound($"Empresa com o ID {id} não encontrada");
                }
                return Ok(empresa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar empresa: {ex.Message}");
            }
        }

        [HttpPut("update-empresa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateEmpresa(int id, CreateEmpresaModel updatedEmpresa)
        {
            try
            {
                var empresaExistente = _empresaService.GetEmpresaById(id);
                if (empresaExistente == null)
                {
                    return NotFound($"Empresa com o ID {id} não encontrada");
                }
                var empresaAtualizada = _empresaService.UpdateEmpresa(id, updatedEmpresa);
                return Ok(empresaAtualizada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar empresa: {ex.Message}");
            }
        }

        [HttpDelete("delete-empresa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteEmpresa(int id)
        {
            try
            {
                var empresaExistente = _empresaService.GetEmpresaById(id);
                if (empresaExistente == null)
                {
                    return NotFound($"Empresa com o ID {id} não encontrada");
                }
                var empresaExcluida = _empresaService.DeleteEmpresa(id);
                return Ok(empresaExcluida);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir empresa: {ex.Message}");
            }
        }
    }
}

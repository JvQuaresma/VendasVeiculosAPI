using Microsoft.AspNetCore.Mvc;
using VeiculosAPI.DTOs;
using VeiculosAPI.Models;
using VeiculosAPI.Servicos;
using VeiculosAPI.Servicos.Interfaces;

namespace VeiculosAPI.Controllers {
    public class LojasController : ControllerBase {

        private readonly ILojaServico _lojaServico;

        public LojasController(ILojaServico lojaServico) {

            _lojaServico = lojaServico;

        }

        [HttpPost("loja")]
        public async Task<IActionResult> AdicionarLoja([FromBody]LojaRegisterDto lojaRegisterDto) {
            try {
                var loja = await _lojaServico.AdicionarLoja(lojaRegisterDto);
                return CreatedAtAction("ObterLoja", new { id = loja.Id }, loja);

            } catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("loja/{id}")]
        public async Task<IActionResult> ObterLoja([FromRoute]int id) {
            var loja = await _lojaServico.ObterLoja(id);
            if (loja == null) {
                return NotFound();
            }
            return Ok(loja);
        }

        [HttpGet("lojas")]
        public async Task<IActionResult> ObterTodasLojas() {
            var lojas = await _lojaServico.ObterTodasLojas();
            return Ok(lojas);
        }

        [HttpPut("atualizarLoja")]
        public async Task<IActionResult> AtualizarVeiculo([FromBody]LojaDto lojaDto) {
            try {
                var loja = await _lojaServico.AtualizarLoja(lojaDto);
                return Ok(loja);

            } catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deletarLoja/{id}")]
        public async Task<IActionResult> DeletarLoja(int id) {
            try {
                var loja = await _lojaServico.DeletarLoja(id);
                return Ok(loja);

            } catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }

    }
}

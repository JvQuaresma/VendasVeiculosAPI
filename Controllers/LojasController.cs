using Microsoft.AspNetCore.Mvc;
using VeiculosAPI.DTOs;
using VeiculosAPI.Servicos;
using VeiculosAPI.Servicos.Interfaces;

namespace VeiculosAPI.Controllers {
    public class LojasController : ControllerBase {

        private readonly ILojaServico _lojaServico;

        public LojasController(ILojaServico lojaServico) {

            _lojaServico = lojaServico;

        }

        [HttpPost("loja")]
        public IActionResult AdicionarLoja(LojaDto lojaDto) {
            try {
                var loja = _lojaServico.AdicionarLoja(lojaDto);
                return CreatedAtAction("ObterLoja", new { id = loja.Id }, loja);

            } catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("loja/{id}")]
        public IActionResult ObterLoja(int id) {
            var loja = _lojaServico.ObterLoja(id);
            if (loja == null) {
                return NotFound();
            }
            return Ok(loja);
        }

        [HttpGet("lojas")]
        public IActionResult ObterTodasLojas() {
            var lojas = _lojaServico.ObterTodasLojas();
            return Ok(lojas);
        }

        [HttpPut("atualizarLoja/{id}")]
        public IActionResult AtualizarVeiculo(int id, LojaDto lojaDto) {
            try {
                _lojaServico.AtualizarLoja(id, lojaDto);
                return NoContent();

            } catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deletarLoja/{id}")]
        public IActionResult DeletarLoja(int id) {
            try {
                _lojaServico.DeletarLoja(id);
                return NoContent();

            } catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }

    }
}

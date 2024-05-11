using Microsoft.AspNetCore.Mvc;
using VeiculosAPI.DTOs;
using VeiculosAPI.Servicos.Interfaces;

namespace VeiculosAPI.Controllers {
    public class VeiculosController : ControllerBase {

        private readonly IVeiculoServico _veiculoServico;

        public VeiculosController(IVeiculoServico veiculoServico) {
            _veiculoServico = veiculoServico;
        }

        [HttpPost("veiculo")]
        public IActionResult AdicionarVeiculo(VeiculoDto veiculoDto) {
            try {

                var veiculo = _veiculoServico.AdicionarVeiculo(veiculoDto);
                return CreatedAtAction("ObterVeiculo", new { id = veiculo.Id }, veiculo);

            } catch (Exception ex) {

                return BadRequest(ex.Message);

            }
        }

        [HttpGet("veiculos")]
        public IActionResult ObterTodosVeiculos(int page = 1) {
            var veiculos = _veiculoServico.ObterTodosVeiculos(page);
            return Ok(veiculos);
        }

        [HttpGet("veiculo/{id}")]
        public IActionResult ObterVeiculo(int id) {
            var veiculo = _veiculoServico.ObterVeiculo(id);
            if (veiculo == null) {
                return NotFound();
            }
            return Ok(veiculo);
        }

        [HttpPut("atualizarVeiculo/{id}")]
        public IActionResult AtualizarVeiculo(int id, VeiculoDto veiculoDto) {
            try {
                _veiculoServico.AtualizarVeiculo(id, veiculoDto);
                return NoContent();

            } catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deletarVeiculo/{id}")]
        public IActionResult DeletarVeiculo(int id) {
            try {
                _veiculoServico.DeletarVeiculo(id);
                return NoContent();

            } catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }

    }
}

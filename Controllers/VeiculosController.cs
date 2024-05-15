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
        public async Task<IActionResult> AdicionarVeiculo([FromBody]VeiculoRegisterDto veiculoRegisterDto) {
            try {

                var veiculo = await _veiculoServico.AdicionarVeiculo(veiculoRegisterDto);
                return CreatedAtAction("ObterVeiculo", new { id = veiculo.Id }, veiculo);

            } catch (Exception ex) {

                return BadRequest(ex.Message);

            }
        }

        [HttpGet("veiculos")]
        public async Task<IActionResult> ObterTodosVeiculos(int page = 1) {
            var veiculos = await _veiculoServico.ObterTodosVeiculos(page);
            return Ok(veiculos);
        }

        [HttpGet("veiculo/{id}")]
        public async Task<IActionResult> ObterVeiculo(int id) {
            var veiculo = await _veiculoServico.ObterVeiculo(id);
            if (veiculo == null) {
                return NotFound();
            }
            return Ok(veiculo);
        }

        [HttpPut("atualizarVeiculo")]
        public async Task<IActionResult> AtualizarVeiculo([FromBody] VeiculoDto veiculoDto) {
            try {
                await _veiculoServico.AtualizarVeiculo(veiculoDto);
                return NoContent();

            } catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deletarVeiculo/{id}")]
        public async Task<IActionResult> DeletarVeiculo(int id) {
            try {
                await _veiculoServico.DeletarVeiculo(id);
                return NoContent();

            } catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }

    }
}

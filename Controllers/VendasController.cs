using Microsoft.AspNetCore.Mvc;
using VeiculosAPI.DTOs;
using VeiculosAPI.Servicos.Interfaces;

namespace VeiculosAPI.Controllers {
    public class VendasController : ControllerBase{

        private readonly IVendaServico _vendaServico;

        public VendasController(IVendaServico vendaServico) {
            _vendaServico = vendaServico;
        }

        [HttpPost("venda")]
        public async Task<IActionResult> VenderVeiculo([FromBody] VendaDto vendaDto) {
            try {
                var venda = await _vendaServico.VenderVeiculo(vendaDto);
                return CreatedAtAction("ObterVenda", new { id = venda.Id }, venda);

            } catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("venda/{id}")]
        public async Task<IActionResult> ObterVenda([FromRoute]int id) {
            var venda = await _vendaServico.ObterVenda(id);
            if (venda == null) {
                return NotFound();

            }

            return Ok(venda);
        }

        [HttpGet("vendas")]
        public async Task<IActionResult> ObterTodasVendas(int page = 1) {
            var vendas = await _vendaServico.ObterTodasVendas(page);

            return Ok(vendas);
        }
    }
}

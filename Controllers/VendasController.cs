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
        public IActionResult VenderVeiculo([FromBody] VendaDto vendaDto) {
            try {
                var venda = _vendaServico.VenderVeiculo(vendaDto);
                return CreatedAtAction("ObterVenda", new { id = venda.Id }, venda);

            } catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("venda/{id}")]
        public IActionResult ObterVenda([FromRoute]int id) {
            var venda = _vendaServico.ObterVenda(id);
            if (venda == null) {
                return NotFound();

            }

            return Ok(venda);
        }

        [HttpGet("vendas")]
        public IActionResult ObterTodasVendas(int page = 1) {
            var vendas = _vendaServico.ObterTodasVendas(page);

            return Ok(vendas);
        }
    }
}

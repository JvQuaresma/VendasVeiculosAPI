using Microsoft.AspNetCore.Mvc;
using VeiculosAPI.DTOs.Loja;
using VeiculosAPI.DTOs.Venda;
using VeiculosAPI.Servicos.Interfaces;
using VeiculosAPI.ViewModels;

namespace VeiculosAPI.Controllers
{
    public class VendasController : ControllerBase{

        private readonly IVendaServico _vendaServico;

        public VendasController(IVendaServico vendaServico) {
            _vendaServico = vendaServico;
        }

        [HttpPost("venda")]
        public async Task<ActionResult<ResponseViewModel<VendaResponseDto>>> VenderVeiculo([FromBody] VendaUpdateDto vendaDto) {
            try {
                var venda = await _vendaServico.VenderVeiculo(vendaDto);
                return CreatedAtAction("ObterVenda", new { id = venda.Id }, venda);

            } catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("venda/{id}")]
        public async Task<ActionResult<ResponseViewModel<VendaResponseDto>>> ObterVenda([FromRoute]int id) {
            var venda = await _vendaServico.ObterVenda(id);
            if (venda == null) {
                return NotFound();

            }

            return Ok(venda);
        }

        [HttpGet("vendas")]
        public async Task<ActionResult<ResponseViewModel<List<VendaResponseDto>>>> ObterTodasVendas(int page = 1) {
            var vendas = await _vendaServico.ObterTodasVendas(page);

            return Ok(vendas);
        }
    }
}

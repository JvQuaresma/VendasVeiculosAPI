using Microsoft.AspNetCore.Mvc;
using Veiculos.Domain.DTOs.Sale;
using Veiculos.Domain.Interfaces.Services;
using Veiculos.Domain.ViewModels;

namespace VeiculosAPI.Controllers
{
    public class SalesController : ControllerBase{

        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService) {
            _saleService = saleService;
        }

        [HttpPost("sale")]
        public async Task<ActionResult<ResponseViewModel<SaleResponseDto>>> VenderVeiculo([FromBody] SaleUpdateDto saleDto) {
            try {
                var sale = await _saleService.SellVehicle(saleDto);
                return CreatedAtAction("GetSale", new { id = sale.Id }, sale);

            } catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("sale/{id}")]
        public async Task<ActionResult<ResponseViewModel<SaleResponseDto>>> GetSale([FromRoute]int id) {
            var sale = await _saleService.GetSale(id);
            if (sale == null) {
                return NotFound();

            }

            return Ok(sale);
        }

        [HttpGet("sales")]
        public async Task<ActionResult<ResponseViewModel<List<SaleResponseDto>>>> GetAllSales(int page = 1) {
            var sales = await _saleService.GetAllSales(page);

            return Ok(sales);
        }
    }
}

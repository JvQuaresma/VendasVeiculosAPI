using Microsoft.AspNetCore.Mvc;
using VeiculosAPI.DTOs.Veiculo;
using VeiculosAPI.Servicos.Interfaces;
using VeiculosAPI.ViewModels;

namespace VeiculosAPI.Controllers
{
    public class VeiculosController : ControllerBase {

        private readonly IVeiculoServico _veiculoServico;

        public VeiculosController(IVeiculoServico veiculoServico) {
            _veiculoServico = veiculoServico;
        }

        [HttpPost("veiculo")]
        public async Task<ActionResult<ResponseViewModel<VeiculoResponseDto>>> AdicionarVeiculo([FromBody]VeiculoRegisterDto veiculoRegisterDto) {
            try {
            
                return Ok(new ResponseViewModel(true,"Sucesso!", await _veiculoServico.AdicionarVeiculo(veiculoRegisterDto)));

            } catch (Exception ex) {

                return BadRequest(new ResponseViewModel(false, ex.Message, null));

            }
        }

        [HttpGet("veiculos")]
        public async Task<ActionResult<ResponseViewModel<List<VeiculoResponseDto>>>> ObterTodosVeiculos(int page = 1) {
            try {
               
                return Ok(new ResponseViewModel(true,"Sucesso!", await _veiculoServico.ObterTodosVeiculos(page)));

            }catch (Exception ex) {

                return BadRequest(new ResponseViewModel(false, ex.Message, null));
            }

        }

        [HttpGet("veiculo/{id}")]
        public async Task<ActionResult<ResponseViewModel<VeiculoResponseDto>>> ObterVeiculo(int id) {
            try {
                var veiculo = await _veiculoServico.ObterVeiculo(id);
                if (veiculo == null) {
                    return NotFound();
                }

                return Ok(new ResponseViewModel(true,"Sucesso!",veiculo));

            }catch(Exception ex) {

                return BadRequest(new ResponseViewModel(false, ex.Message, null));
            }

        }

        [HttpPut("atualizarVeiculo")]
        public async Task<ActionResult<ResponseViewModel<VeiculoResponseDto>>> AtualizarVeiculo([FromBody] VeiculoUpdateDto veiculoDto) {
            try {
                
                return Ok(new ResponseViewModel(true,"Sucesso!", await _veiculoServico.AtualizarVeiculo(veiculoDto)));

            } catch (Exception ex) {

                return BadRequest(new ResponseViewModel(false, ex.Message, null));
            }
        }

        [HttpDelete("deletarVeiculo/{id}")]
        public async Task<ActionResult<ResponseViewModel<VeiculoResponseDto>>> DeletarVeiculo(int id) {
            try {
                
                return Ok(new ResponseViewModel(true,"Sucesso!", await _veiculoServico.DeletarVeiculo(id)));

            } catch (Exception ex) {

                return BadRequest(new ResponseViewModel(false, ex.Message, null));
            }
        }

    }
}

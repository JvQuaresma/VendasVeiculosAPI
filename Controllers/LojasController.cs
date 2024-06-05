using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using VeiculosAPI.DTOs.Loja;
using VeiculosAPI.DTOs.Veiculo;
using VeiculosAPI.Models;
using VeiculosAPI.Servicos;
using VeiculosAPI.Servicos.Interfaces;
using VeiculosAPI.ViewModels;

namespace VeiculosAPI.Controllers
{
    public class LojasController : ControllerBase {

        private readonly ILojaServico _lojaServico;

        public LojasController(ILojaServico lojaServico) {

            _lojaServico = lojaServico;

        }

        [HttpPost("loja")]
        public async Task<ActionResult<ResponseViewModel<LojaResponseDto>>> AdicionarLoja([FromBody]LojaRegisterDto lojaRegisterDto) {
            try { 
                
                return Ok(new ResponseViewModel(true,"Sucesso!",await _lojaServico.AdicionarLoja(lojaRegisterDto)));

            } catch (Exception ex) {

                return BadRequest(new ResponseViewModel(false,ex.Message,null));
            }
        }

        [HttpGet("loja/{id}")]
        public async Task<ActionResult<ResponseViewModel<LojaResponseDto>>> ObterLoja([FromRoute]int id) {
            try {
                var loja = await _lojaServico.ObterLoja(id);
                if (loja == null) {
                    return NotFound();
                }

                return Ok(new ResponseViewModel(true,"Sucesso!", loja));

            }catch(Exception ex) {
                return BadRequest(new ResponseViewModel(false, ex.Message, null));

            }
            
        }

        [HttpGet("lojas")]
        public async Task<ActionResult<ResponseViewModel<List<LojaResponseDto>>>> ObterTodasLojas() {

            return Ok(new ResponseViewModel(true, "Sucesso!", await _lojaServico.ObterTodasLojas()));

        }

        [HttpPut("atualizarLoja")]
        public async Task<ActionResult<ResponseViewModel<LojaResponseDto>>> AtualizarVeiculo([FromBody]LojaUpdateDto lojaDto) {
            try {
                
                return Ok(new ResponseViewModel(true, "Sucesso!", await _lojaServico.AtualizarLoja(lojaDto)));

            } catch (Exception ex) {

                return BadRequest(new ResponseViewModel(false,ex.Message,null));
            }
        }

        [HttpDelete("deletarLoja/{id}")]
        public async Task<ActionResult<ResponseViewModel<LojaResponseDto>>> DeletarLoja(int id) {
            try {
                
                return Ok(new ResponseViewModel(true,"Sucesso!", await _lojaServico.DeletarLoja(id)));

            } catch (Exception ex) {

                return BadRequest(new ResponseViewModel(false,ex.Message,null));
            }
        }

    }
}

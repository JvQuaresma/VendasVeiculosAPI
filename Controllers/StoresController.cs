using Microsoft.AspNetCore.Mvc;
using Veiculos.Domain.DTOs.Store;
using Veiculos.Domain.Interfaces.Services;
using Veiculos.Domain.ViewModels;

namespace VeiculosAPI.Controllers
{
    public class StoresController : ControllerBase {

        private readonly IStoreService _storeService;

        public StoresController(IStoreService storeService) {

            _storeService = storeService;

        }

        [HttpPost("store")]
        public async Task<ActionResult<ResponseViewModel<StoreResponseDto>>> AddStore([FromBody]StoreRegisterDto storeRegisterDto) {
            try { 
                
                return Ok(new ResponseViewModel(true,"Sucesso!",await _storeService.AddStore(storeRegisterDto)));

            } catch (Exception ex) {

                return BadRequest(new ResponseViewModel(false,ex.Message,null));
            }
        }

        [HttpGet("store/{id}")]
        public async Task<ActionResult<ResponseViewModel<StoreResponseDto>>> GetStore([FromRoute]int id) {
            try {
                var store = await _storeService.GetStore(id);
                if (store == null) {
                    return NotFound();
                }

                return Ok(new ResponseViewModel(true,"Sucesso!", store));

            }catch(Exception ex) {
                return BadRequest(new ResponseViewModel(false, ex.Message, null));

            }
            
        }

        [HttpGet("stores")]
        public async Task<ActionResult<ResponseViewModel<List<StoreResponseDto>>>> GetAllStores() {

            return Ok(new ResponseViewModel(true, "Sucesso!", await _storeService.GetAllStores()));

        }

        [HttpPut("updateStore")]
        public async Task<ActionResult<ResponseViewModel<StoreResponseDto>>> UpdateStore([FromBody]StoreUpdateDto storeDto) {
            try {
                
                return Ok(new ResponseViewModel(true, "Sucesso!", await _storeService.UpdateStore(storeDto)));

            } catch (Exception ex) {

                return BadRequest(new ResponseViewModel(false,ex.Message,null));
            }
        }

        [HttpDelete("deleteStore/{id}")]
        public async Task<ActionResult<ResponseViewModel<StoreResponseDto>>> DeleteStore(int id) {
            try {
                
                return Ok(new ResponseViewModel(true,"Sucesso!", await _storeService.DeleteStore(id)));

            } catch (Exception ex) {

                return BadRequest(new ResponseViewModel(false,ex.Message,null));
            }
        }

    }
}

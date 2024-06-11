using Microsoft.AspNetCore.Mvc;
using Veiculos.Domain.DTOs.Vehicle;
using Veiculos.Domain.Interfaces.Services;
using Veiculos.Domain.ViewModels;

namespace VeiculosAPI.Controllers
{
    public class VehiclesController : ControllerBase {

        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService) {
            _vehicleService = vehicleService;
        }

        [HttpPost("vehicle")]
        public async Task<ActionResult<ResponseViewModel<VehicleResponseDto>>> AddVehicle([FromBody]VehicleRegisterDto vehicleRegisterDto) {
            try {
            
                return Ok(new ResponseViewModel(true,"Sucesso!", await _vehicleService.AddVehicle(vehicleRegisterDto)));

            } catch (Exception ex) {

                return BadRequest(new ResponseViewModel(false, ex.Message, null));

            }
        }

        [HttpGet("vehicles")]
        public async Task<ActionResult<ResponseViewModel<List<VehicleResponseDto>>>> GetAllVehicles(int page = 1) {
            try {
               
                return Ok(new ResponseViewModel(true,"Sucesso!", await _vehicleService.GetAllVehicles(page)));

            }catch (Exception ex) {

                return BadRequest(new ResponseViewModel(false, ex.Message, null));
            }

        }

        [HttpGet("vehicles/{id}")]
        public async Task<ActionResult<ResponseViewModel<VehicleResponseDto>>> GetVehicle(int id) {
            try {
                var vehicle = await _vehicleService.GetVehicle(id);
                if (vehicle == null) {
                    return NotFound();
                }

                return Ok(new ResponseViewModel(true,"Sucesso!",vehicle));

            }catch(Exception ex) {

                return BadRequest(new ResponseViewModel(false, ex.Message, null));
            }

        }

        [HttpPut("updateVehicle")]
        public async Task<ActionResult<ResponseViewModel<VehicleResponseDto>>> UpdateVehicle([FromBody] VehicleUpdateDto vehicleDto) {
            try {
                
                return Ok(new ResponseViewModel(true,"Sucesso!", await _vehicleService.UpdateVehicle(vehicleDto)));

            } catch (Exception ex) {

                return BadRequest(new ResponseViewModel(false, ex.Message, null));
            }
        }

        [HttpDelete("deleteVehicle/{id}")]
        public async Task<ActionResult<ResponseViewModel<VehicleResponseDto>>> DeleteVehicle(int id) {
            try {
                
                return Ok(new ResponseViewModel(true,"Sucesso!", await _vehicleService.DeleteVehicle(id)));

            } catch (Exception ex) {

                return BadRequest(new ResponseViewModel(false, ex.Message, null));
            }
        }

    }
}

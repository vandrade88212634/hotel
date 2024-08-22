using Hotel.WebApi.Models;
using Common.Utils.Resources;
using Dominio.Servicio.Servicios.Interfaces;
using Dominio.Servicio.DTO;

using Microsoft.AspNetCore.Mvc;
using Azure;
using Dominio.Servicio.Servicios;


namespace Hotel.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController: ControllerBase
    {

        #region Members
        private readonly IReservasServices _reservasServices;
        #endregion Members

        #region Builder
        public ReservasController(IReservasServices reservasServices)
        {

            _reservasServices = reservasServices;

        }
        #endregion Builder

        [HttpPost("BuscaHabitacion")]
        public async Task<IActionResult> BuscaHabitacion(BuscaHabitacionDto busqueda)
        {

            List<HabitacionesDto> result = _reservasServices.BuscaHabitacion(busqueda);

            ResponseModel<List<HabitacionesDto>> response = new ResponseModel<List<HabitacionesDto>>()
            {
                IsSuccess = true,
                Messages = GeneralMessages.SussefullyProcess,
                Result = result
            };

            return Ok(response);
        }

        [HttpGet("GetAllReservas")]
        public async Task<IActionResult> GetAllReservas()
        {

            List<ReservasDto> result = _reservasServices.GetAllReservas();

            ResponseModel<List<ReservasDto>> response = new ResponseModel<List<ReservasDto>>()
            {
                IsSuccess = true,
                Messages = GeneralMessages.SussefullyProcess,
                Result = result
            };

            return Ok(response);
        }


        [HttpGet("GetDetalleReservas/{idReserva}")]
        public async Task<IActionResult> GetDetalleReservas(int idReserva)
        {

            DetalleReservaTotalDto result = _reservasServices.GetDetalleReservas(idReserva);

            ResponseModel<DetalleReservaTotalDto> response = new ResponseModel<DetalleReservaTotalDto>()
            {
                IsSuccess = true,
                Messages = GeneralMessages.SussefullyProcess,
                Result = result
            };

            return Ok(response);
        }


        [HttpPost("insertReserva")]

        public async Task<IActionResult> insertReserva(ReservasDto reserva)
        {
            ReservasDto result = _reservasServices.insertReserva(reserva);

            ResponseModel<ReservasDto> response = new ResponseModel<ReservasDto>()
            {
                IsSuccess = (bool)result.IsSuccess,
                Messages = result.Message,
                Result = result
            };

            return Ok(response);
        }






    }
}

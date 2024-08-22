using Hotel.WebApi.Models;
using Common.Utils.Resources;
using Dominio.Servicio.Servicios.Interfaces;
using Dominio.Servicio.DTO;

using Microsoft.AspNetCore.Mvc;
using Azure;


namespace Hotel.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController :ControllerBase
    {
        #region Members
        private readonly IHotelServices _hotelServices;
        #endregion Members

        #region Builder
        public HotelController(IHotelServices hotelServices)
        {

            _hotelServices = hotelServices;

        }
        #endregion Builder


        #region Methods

        [HttpGet("GetAllHotelsbyCity/{idCity}")]
        public async Task<IActionResult> GetAllHotelsbyCity(int idCity)
        {

            List<HotelDto> result = _hotelServices.GetAllHotelsbyCity(idCity);

            ResponseModel<List<HotelDto>> response = new ResponseModel<List<HotelDto>>()
            {
                IsSuccess = true,
                Messages = GeneralMessages.SussefullyProcess,
                Result = result
            };

            return Ok(response);
        }

        [HttpGet("GetAllHotelsbyId/{idHotel}")]
        public async Task<IActionResult> GetAllHotelsbyId(int idHotel)
        {

            List<HotelDto> result = _hotelServices.GetAllHotelsbyCity(idHotel);

            ResponseModel<List<HotelDto>> response = new ResponseModel<List<HotelDto>>()
            {
                IsSuccess = true,
                Messages = GeneralMessages.SussefullyProcess,
                Result = result
            };

            return Ok(response);
        }

        [HttpPost("InsertHotel")]
        
        public async Task<IActionResult> InsertHotel(HotelDto hotel)
        { 
            HotelDto result = _hotelServices.InsertHotel(hotel);

        ResponseModel<HotelDto> response = new ResponseModel<HotelDto>()
        {
            IsSuccess = (bool)result.IsSuccess,
            Messages = result.Message,
            Result = result
        };

            return Ok(response);
         }

       


        [HttpPost("EditHotel")]
        public async Task<IActionResult> EditHotel(HotelDto hotel)
        {
            HotelDto result = _hotelServices.EditHotel(hotel);

            ResponseModel<HotelDto> response = new ResponseModel<HotelDto>()
            {
                IsSuccess = (bool)result.IsSuccess,
                Messages = result.Message,
                Result = result
            };

            return Ok(response);
        }

        [HttpPost("ActivaDesactivaHotel")]
        public async Task<IActionResult> ActivaDesactivaHotel(HotelDto hotel)
        {
            HotelDto result = _hotelServices.ActivaDesactivaHotel(hotel,hotel.Activo);

            ResponseModel<HotelDto> response = new ResponseModel<HotelDto>()
            {
                IsSuccess = (bool)result.IsSuccess,
                Messages = result.Message,
                Result = result
            };

            return Ok(response);
        }

        [HttpGet("GetAllHabitacionesbyHotel/{idHotel}")]
        public async Task<IActionResult> GetAllHabitacionesbyHotel(int idHotel)
        {

            List<HabitacionesDto> result = _hotelServices.GetAllHabitacionesbyHotel(idHotel);

            ResponseModel<List<HabitacionesDto>> response = new ResponseModel<List<HabitacionesDto>>()
            {
                IsSuccess = true,
                Messages = GeneralMessages.SussefullyProcess,
                Result = result
            };

            return Ok(response);
        }

        [HttpGet("GetAllHabitacionesbyTipo/{idTipo}")]
        public async Task<IActionResult> GetAllHabitacionesbyTipo(int idTipo)
        {

            List<HabitacionesDto> result = _hotelServices.GetAllHabitacionesbyTipo(idTipo);

            ResponseModel<List<HabitacionesDto>> response = new ResponseModel<List<HabitacionesDto>>()
            {
                IsSuccess = true,
                Messages = GeneralMessages.SussefullyProcess,
                Result = result
            };

            return Ok(response);
        }

        [HttpPost("InsertHabitacion")]

        public async Task<IActionResult> InsertHabitacion(HabitacionesDto habitacion)
        {
            HabitacionesDto result = _hotelServices.InsertHabitacion(habitacion);

            ResponseModel<HabitacionesDto> response = new ResponseModel<HabitacionesDto>()
            {
                IsSuccess = (bool)result.IsSuccess,
                Messages = result.Message,
                Result = result
            };

            return Ok(response);
        }




        [HttpPost("EditHabitacion")]
        public async Task<IActionResult> EditHabitacion(HabitacionesDto habitacion)
        {
            HabitacionesDto result = _hotelServices.EditHabitacion(habitacion);

            ResponseModel<HabitacionesDto> response = new ResponseModel<HabitacionesDto>()
            {
                IsSuccess = (bool)result.IsSuccess,
                Messages = result.Message,
                Result = result
            };

            return Ok(response);
        }

        [HttpPost("ActivaDesactivaHabitacion")]
        public async Task<IActionResult> ActivaDesactivaHabitacion(HabitacionesDto habitacion)
        {
            HabitacionesDto result = _hotelServices.ActivaDesactivaHabitacion(habitacion, habitacion.Activo);

            ResponseModel<HabitacionesDto> response = new ResponseModel<HabitacionesDto>()
            {
                IsSuccess = (bool)result.IsSuccess,
                Messages = result.Message,
                Result = result
            };

            return Ok(response);
        }


        #endregion Methods

    }
}

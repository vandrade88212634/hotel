using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.WebApi.Controllers;
using Dominio.Servicio.Servicios.Interfaces;
using Dominio.Servicio.DTO;
using Hotel.WebApi.Models;
using Common.Utils.Resources;

namespace hotel.UnitTest.Controladores
{
    public class HotelControllerTests
    {
        private readonly Mock<IHotelServices> _mockHotelServices;
        private readonly HotelController _hotelController;

        public HotelControllerTests()
        {
            _mockHotelServices = new Mock<IHotelServices>();
            _hotelController = new HotelController(_mockHotelServices.Object);
        }

        [Fact]
        public async Task GetAllHotelsbyCity_ShouldReturnOkResult_WithListOfHotels()
        {
            // Arrange
            int cityId = 1;
            var hotelList = new List<HotelDto>
            {
                new HotelDto { IdHotel = 1, RazonSocial = "Hotel A", Activo = 1 },
                new HotelDto { IdHotel = 2, RazonSocial = "Hotel B", Activo = 1 }
            };
            _mockHotelServices.Setup(service => service.GetAllHotelsbyCity(cityId)).Returns(hotelList);

            // Act
            var result = await _hotelController.GetAllHotelsbyCity(cityId);

            // Xunit.Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            var response = Xunit.Assert.IsType<ResponseModel<List<HotelDto>>>(okResult.Value);
            Xunit.Assert.True(response.IsSuccess);
            Xunit.Assert.Equal(GeneralMessages.SussefullyProcess, response.Messages);
            Xunit.Assert.Equal(hotelList.Count, response.Result.Count);
        }

        [Fact]
        public async Task GetAllHotelsbyId_ShouldReturnOkResult_WithListOfHotels()
        {
            // Arrange
            int hotelId = 1;
            var hotelList = new List<HotelDto>
            {
                new HotelDto { IdHotel = hotelId, RazonSocial = "Hotel A", Activo = 1 }
            };
            _mockHotelServices.Setup(service => service.GetAllHotelsbyCity(hotelId)).Returns(hotelList);

            // Act
            var result = await _hotelController.GetAllHotelsbyId(hotelId);

            // Xunit.Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            var response = Xunit.Assert.IsType<ResponseModel<List<HotelDto>>>(okResult.Value);
            Xunit.Assert.True(response.IsSuccess);
            Xunit.Assert.Equal(GeneralMessages.SussefullyProcess, response.Messages);
            Xunit.Assert.Equal(hotelList.Count, response.Result.Count);
        }

        [Fact]
        public async Task InsertHotel_ShouldReturnOkResult_WithInsertedHotel()
        {
            // Arrange
            var hotel = new HotelDto { IdHotel = 1, RazonSocial = "Hotel A", Activo = 1 };
            _mockHotelServices.Setup(service => service.InsertHotel(hotel)).Returns(hotel);

            // Act
            var result = await _hotelController.InsertHotel(hotel);

            // Xunit.Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            var response = Xunit.Assert.IsType<ResponseModel<HotelDto>>(okResult.Value);
            Xunit.Assert.True(response.IsSuccess);
            Xunit.Assert.Equal(hotel, response.Result);
        }

        [Fact]
        public async Task EditHotel_ShouldReturnOkResult_WithEditedHotel()
        {
            // Arrange
            var hotel = new HotelDto { IdHotel = 1, RazonSocial = "Hotel A", Activo = 1 };
            _mockHotelServices.Setup(service => service.EditHotel(hotel)).Returns(hotel);

            // Act
            var result = await _hotelController.EditHotel(hotel);

            // Xunit.Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            var response = Xunit.Assert.IsType<ResponseModel<HotelDto>>(okResult.Value);
            Xunit.Assert.True(response.IsSuccess);
            Xunit.Assert.Equal(hotel, response.Result);
        }

        [Fact]
        public async Task ActivaDesactivaHotel_ShouldReturnOkResult_WithHotelStatusChanged()
        {
            // Arrange
            var hotel = new HotelDto { IdHotel = 1, Activo = 0 };
            _mockHotelServices.Setup(service => service.ActivaDesactivaHotel(hotel, hotel.Activo)).Returns(hotel);

            // Act
            var result = await _hotelController.ActivaDesactivaHotel(hotel);

            // Xunit.Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            var response = Xunit.Assert.IsType<ResponseModel<HotelDto>>(okResult.Value);
            Xunit.Assert.True(response.IsSuccess);
            Xunit.Assert.Equal(hotel, response.Result);
        }

        [Fact]
        public async Task GetAllHabitacionesbyHotel_ShouldReturnOkResult_WithListOfHabitaciones()
        {
            // Arrange
            int hotelId = 1;
            var habitacionesList = new List<HabitacionesDto>
            {
                new HabitacionesDto { IdHabitaciones = 1, Numero = "101", Activo = 1 },
                new HabitacionesDto { IdHabitaciones = 2, Numero = "102", Activo = 1 }
            };
            _mockHotelServices.Setup(service => service.GetAllHabitacionesbyHotel(hotelId)).Returns(habitacionesList);

            // Act
            var result = await _hotelController.GetAllHabitacionesbyHotel(hotelId);

            // Xunit.Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            var response = Xunit.Assert.IsType<ResponseModel<List<HabitacionesDto>>>(okResult.Value);
            Xunit.Assert.True(response.IsSuccess);
            Xunit.Assert.Equal(GeneralMessages.SussefullyProcess, response.Messages);
            Xunit.Assert.Equal(habitacionesList.Count, response.Result.Count);
        }

        [Fact]
        public async Task GetAllHabitacionesbyTipo_ShouldReturnOkResult_WithListOfHabitaciones()
        {
            // Arrange
            int tipoId = 1;
            var habitacionesList = new List<HabitacionesDto>
            {
                new HabitacionesDto { IdHabitaciones = 1, Numero = "101", Activo = 1 },
                new HabitacionesDto { IdHabitaciones = 2, Numero = "102", Activo = 1 }
            };
            _mockHotelServices.Setup(service => service.GetAllHabitacionesbyTipo(tipoId)).Returns(habitacionesList);

            // Act
            var result = await _hotelController.GetAllHabitacionesbyTipo(tipoId);

            // Xunit.Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            var response = Xunit.Assert.IsType<ResponseModel<List<HabitacionesDto>>>(okResult.Value);
            Xunit.Assert.True(response.IsSuccess);
            Xunit.Assert.Equal(GeneralMessages.SussefullyProcess, response.Messages);
            Xunit.Assert.Equal(habitacionesList.Count, response.Result.Count);
        }

        [Fact]
        public async Task InsertHabitacion_ShouldReturnOkResult_WithInsertedHabitacion()
        {
            // Arrange
            var habitacion = new HabitacionesDto { IdHabitaciones = 1, Numero = "101", Activo = 1 };
            _mockHotelServices.Setup(service => service.InsertHabitacion(habitacion)).Returns(habitacion);

            // Act
            var result = await _hotelController.InsertHabitacion(habitacion);

            // Xunit.Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            var response = Xunit.Assert.IsType<ResponseModel<HabitacionesDto>>(okResult.Value);
            Xunit.Assert.True(response.IsSuccess);
            Xunit.Assert.Equal(habitacion, response.Result);
        }

        [Fact]
        public async Task EditHabitacion_ShouldReturnOkResult_WithEditedHabitacion()
        {
            // Arrange
            var habitacion = new HabitacionesDto { IdHabitaciones = 1, Numero = "101", Activo = 1 };
            _mockHotelServices.Setup(service => service.EditHabitacion(habitacion)).Returns(habitacion);

            // Act
            var result = await _hotelController.EditHabitacion(habitacion);

            // Xunit.Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            var response = Xunit.Assert.IsType<ResponseModel<HabitacionesDto>>(okResult.Value);
            Xunit.Assert.True(response.IsSuccess);
            Xunit.Assert.Equal(habitacion, response.Result);
        }

        [Fact]
        public async Task ActivaDesactivaHabitacion_ShouldReturnOkResult_WithHabitacionStatusChanged()
        {
            // Arrange
            var habitacion = new HabitacionesDto { IdHabitaciones = 1, Activo = 0 };
            _mockHotelServices.Setup(service => service.ActivaDesactivaHabitacion(habitacion, habitacion.Activo)).Returns(habitacion);

            // Act
            var result = await _hotelController.ActivaDesactivaHabitacion(habitacion);

            // Xunit.Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            var response = Xunit.Assert.IsType<ResponseModel<HabitacionesDto>>(okResult.Value);
            Xunit.Assert.True(response.IsSuccess);
            Xunit.Assert.Equal(habitacion, response.Result);
        }
    }
}

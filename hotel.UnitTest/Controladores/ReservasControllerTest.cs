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
    public class ReservasControllerTests
    {
        private readonly Mock<IReservasServices> _mockReservasServices;
        private readonly ReservasController _reservasController;

        public ReservasControllerTests()
        {
            _mockReservasServices = new Mock<IReservasServices>();
            _reservasController = new ReservasController(_mockReservasServices.Object);
        }

        [Fact]
        public async Task BuscaHabitacion_ShouldReturnOkResult_WithListOfHabitaciones()
        {
            // Arrange
            var busqueda = new BuscaHabitacionDto { /* inicializa las propiedades necesarias */ };
            var habitacionesList = new List<HabitacionesDto>
            {
                new HabitacionesDto { IdHabitaciones = 1, Numero = "101", Activo = 1 },
                new HabitacionesDto { IdHabitaciones = 2, Numero = "102", Activo = 1 }
            };
            _mockReservasServices.Setup(service => service.BuscaHabitacion(busqueda)).Returns(habitacionesList);

            // Act
            var result = await _reservasController.BuscaHabitacion(busqueda);

            // Xunit.Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            var response = Xunit.Assert.IsType<ResponseModel<List<HabitacionesDto>>>(okResult.Value);
            Xunit.Assert.True(response.IsSuccess);
            Xunit.Assert.Equal(GeneralMessages.SussefullyProcess, response.Messages);
            Xunit.Assert.Equal(habitacionesList.Count, response.Result.Count);
        }

        [Fact]
        public async Task GetAllReservas_ShouldReturnOkResult_WithListOfReservas()
        {
            // Arrange
            var reservasList = new List<ReservasDto>
            {
                new ReservasDto { IdReservas = 1, IdHotel = 1 },
                new ReservasDto { IdReservas = 2, IdHotel = 2}
            };
            _mockReservasServices.Setup(service => service.GetAllReservas()).Returns(reservasList);

            // Act
            var result = await _reservasController.GetAllReservas();

            // Xunit.Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            var response = Xunit.Assert.IsType<ResponseModel<List<ReservasDto>>>(okResult.Value);
            Xunit.Assert.True(response.IsSuccess);
            Xunit.Assert.Equal(GeneralMessages.SussefullyProcess, response.Messages);
            Xunit.Assert.Equal(reservasList.Count, response.Result.Count);
        }

        [Fact]
        public async Task GetDetalleReservas_ShouldReturnOkResult_WithDetalleReserva()
        {
            // Arrange
            int reservaId = 1;
            var detalleReserva = new DetalleReservaTotalDto { };
            _mockReservasServices.Setup(service => service.GetDetalleReservas(reservaId)).Returns(detalleReserva);

            // Act
            var result = await _reservasController.GetDetalleReservas(reservaId);

            // Xunit.Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            var response = Xunit.Assert.IsType<ResponseModel<DetalleReservaTotalDto>>(okResult.Value);
            Xunit.Assert.True(response.IsSuccess);
            Xunit.Assert.Equal(GeneralMessages.SussefullyProcess, response.Messages);
            Xunit.Assert.Equal(detalleReserva, response.Result);
        }

        [Fact]
        public async Task InsertReserva_ShouldReturnOkResult_WithInsertedReserva()
        {
            // Arrange
            var reserva = new ReservasDto { IdReservas = 1, IdHotel = 1 };
            _mockReservasServices.Setup(service => service.insertReserva(reserva)).Returns(reserva);

            // Act
            var result = await _reservasController.insertReserva(reserva);

            // Xunit.Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            var response = Xunit.Assert.IsType<ResponseModel<ReservasDto>>(okResult.Value);
            Xunit.Assert.True(response.IsSuccess);
            Xunit.Assert.Equal(reserva, response.Result);
        }
    }
}

